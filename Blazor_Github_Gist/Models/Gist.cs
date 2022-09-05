namespace Blazor_Github_Gist.Models
{
    public class Gist
    {
        public string url { get; set; } = string.Empty;
        public string forks_url { get; set; } = string.Empty;
        public string commits_url { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string node_id { get; set; } = string.Empty;
        public string git_pull_url { get; set; } = string.Empty;
        public string git_push_url { get; set; } = string.Empty;
        public string html_url { get; set; } = string.Empty;
        public List<GistFile> FileList { get; set; } = new List<GistFile>();
        public bool _public { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string description { get; set; } = string.Empty;
        public int comments { get; set; }
        public User user { get; set; }
        public string comments_url { get; set; } = string.Empty;
        public Owner owner { get; set; }
        public bool truncated { get; set; }
        public bool ShowFiles { get; set; } = false;
        public List<Gist> Forks { get; set; }
        public bool ShowForks { get; set; } = false;
    }

    public class User
    {
        public string login { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string avatar_url { get; set; } = string.Empty;
        public string gravatar_id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }

}
