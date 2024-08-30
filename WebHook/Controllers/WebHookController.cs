using Microsoft.AspNetCore.Mvc;
using Octokit;
using WebHook.Models;

namespace WebHook.Controllers
{
    [ApiController]
    [Route("api/github")]
    public class WebHookController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ReceiverWebhook _receiverWebhook;
        public WebHookController(IConfiguration config, ReceiverWebhook receiverWebhook)
        {
            _config = config;
            _receiverWebhook = receiverWebhook;
        }

        [HttpGet("repository/issues")]
        public async Task<IActionResult> GetRepositoryIssues(string user, string repository)
        {
            try
            {
                var issues = _receiverWebhook.SendRequest(user, repository, _config.GetValue<string>("WebHookTemporary:Token"));

                return Ok(issues);
            }
            catch (NotFoundException)
            {
                return NotFound("Repositório não encontrado no GitHub.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao acessar as issues: {ex.Message}");
            }
        }
    }
}