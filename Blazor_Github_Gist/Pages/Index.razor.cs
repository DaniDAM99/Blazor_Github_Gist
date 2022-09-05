using Blazor_Github_Gist.Models;
using Blazor_Github_Gist.Services.Rest;
using Microsoft.AspNetCore.Components;

namespace Blazor_Github_Gist.Pages
{
    public partial class Index
    {
        [Inject]
        private IRestService _restService { get; set; }
        private List<Gist> GistsList = new List<Gist>();
        private string User { get; set; } = String.Empty;

        public async Task GetGist()
        {
            if (string.IsNullOrEmpty(User))
                return;
            GistsList.Clear();
            GistsList = await _restService.GetGist(User);
            StateHasChanged();
        }

        public void ShowGistFile(Gist gist)
        {
            gist.ShowFiles = !gist.ShowFiles;
            gist.ShowForks = false;
            StateHasChanged();
        }

        public async void GetForksList(Gist gist)
        {
            gist.ShowForks = !gist.ShowForks;
            gist.ShowFiles = false;
            if (gist.Forks == null)
            {
                gist.Forks = await _restService.GetForks(gist.id);
                gist.Forks = gist.Forks.OrderByDescending(x => x.created_at).ToList();
            }
            StateHasChanged();
        }

        public async void ShowFileData(GistFile file)
        {
            if(file.data == null)
            {
                file.data = await _restService.GetFileData(file.raw_url);
            }
            file.showData = !file.showData;
            StateHasChanged();
        }
    }
}
