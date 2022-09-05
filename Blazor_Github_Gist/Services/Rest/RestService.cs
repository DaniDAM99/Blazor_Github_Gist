using Blazor_Github_Gist.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Blazor_Github_Gist.Services.Rest
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;

        public RestService(HttpClient httpClient)
        {
            this._client = httpClient;
        }

        public async Task<List<Gist>> GetGist(string user)
        {

            _client.DefaultRequestHeaders.Add("User-Agent", "DaniDAM99");
            var content = await GetStringAsync($"users/{user}/gists");

            List<Gist> gists_list = new List<Gist>();

            if(!string.IsNullOrEmpty(content))
                gists_list = JsonConvert.DeserializeObject<List<Gist>>(content);

            if (gists_list == null)
                gists_list = new List<Gist>();

            GetGistFiles(content, gists_list);

            return gists_list;
        }

        public async Task<List<Gist>> GetForks(string id)
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "DaniDAM99");
            var json = await GetStringAsync($"gists/{id}/forks");
            List<Gist> forks = new List<Gist>();

            if(!string.IsNullOrEmpty(json))
                forks = JsonConvert.DeserializeObject<List<Gist>>(json);

            if(forks == null)
                forks = new List<Gist>();

            return forks;
        }

        public async Task<string> GetFileData(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private async Task<string> GetStringAsync(string url)
        {
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return "";

            return content;
        }
        
        // Get the gist files from the json and insert them in the Gist list of the object
        private void GetGistFiles(string json, List<Gist> gistList)
        {
            if (String.IsNullOrEmpty(json) || gistList.Count == 0)
                return;

            dynamic raw_data = JsonConvert.DeserializeObject<dynamic>(json);
            int git_index = 0;
            foreach (var gist in raw_data)
            {
                var files = gist.files;
                foreach (JProperty data in files)
                {
                    var properties_list = data.Value.Children().ToList();
                    string js = "{";
                    foreach (var property in properties_list)
                    {
                        if (properties_list.Last() != property)
                            js += property.ToString().Trim() + ",";
                        else
                            js += property.ToString().Trim();
                    }
                    js += "}";

                    var file = JsonConvert.DeserializeObject<GistFile>(js);
                    if (file != null)
                    {
                        if (gistList[git_index].FileList == null)
                            gistList[git_index].FileList = new List<GistFile>();

                        gistList[git_index].FileList.Add(file);
                    }
                }
                git_index++;
            }
        }
    }
}