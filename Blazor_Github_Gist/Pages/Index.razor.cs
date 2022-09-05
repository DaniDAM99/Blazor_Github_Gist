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
            User = "anders";
            GistsList = await _restService.GetGist(User);
            StateHasChanged();
        }

        public void ShowGistFile(Gist gist)
        {
            gist.ShowFiles = !gist.ShowFiles;
            StateHasChanged();
        }
    }
}
