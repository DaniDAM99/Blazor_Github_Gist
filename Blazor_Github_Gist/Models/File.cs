using System.Collections.ObjectModel;

namespace Blazor_Github_Gist.Models
{
    public class GistFile
    {
        public string filename { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string language { get; set; } = string.Empty;
        public string raw_url { get; set; } = string.Empty;
        public int size { get; set; }
    }
}
