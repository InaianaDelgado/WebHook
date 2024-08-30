using Newtonsoft.Json;

namespace WebHook.Models
{
    public class ResponseWebHookGitHub
    {
        [JsonProperty()]
        public string UserName { get; set; }
        public string Repository { get; set; }
        public List<IssueResponse> Issues { get; set; }
        public List<ContributorResponse> Contributors { get; set; }
    }
}
