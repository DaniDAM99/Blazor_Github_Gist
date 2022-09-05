using Blazor_Github_Gist.Models;

namespace Blazor_Github_Gist.Services.Rest
{
    public interface IRestService
    {
        public Task<List<Gist>> GetGist(string user);
    }
}
