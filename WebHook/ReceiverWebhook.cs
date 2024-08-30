using Octokit;
using WebHook.Interfaces;
using WebHook.Models;

namespace WebHook
{
    public class ReceiverWebhook : IReceiveWebhook
    {
        public async Task<string> SendRequest(string user, string repository, string token)
        {
            var github = new GitHubClient(new ProductHeaderValue("GitHubWebhookExample"));

            if (!string.IsNullOrEmpty(token))
            {
                var tokenAuth = new Credentials(token);
                github.Credentials = tokenAuth;
            }

            //var contributors = await github.Repository.GetAllContributors(user, repository);
            var issues = await github.Issue.GetAllForRepository(user, repository);

            throw new NotImplementedException();
        }

        public ResponseWebHookGitHub Response(IList<ContributorResponse> contributors, IList<IssueResponse> issues)
        {
            return new ResponseWebHookGitHub
            {

            };
        }
    }
}