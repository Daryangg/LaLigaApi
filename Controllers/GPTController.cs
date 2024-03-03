using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace LaligaInformationApi.Controllers
{
    [Route("api/GPTController")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        private readonly OpenAIAPI _openAi;
        public GPTController(IOptions<OpenAIOptions> options)
        {
            string apiKey = options.Value.ApiKey;
            _openAi = new OpenAIAPI(apiKey);
        }

        [Authorize]
        [HttpGet]
        [Route("/askChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            try
            {
                var completionRequest = new CompletionRequest
                {
                    Prompt = query,
                    Model = OpenAI_API.Models.Model.Davinci,
                    TopP = 0.1,
                    MaxTokens = 100
                };

                var completions = await _openAi.Completions.CreateCompletionAsync(completionRequest);
                
                    var stringBuilder = new StringBuilder();
                    foreach (var completion in completions.Completions)
                    {
                        stringBuilder.Append(completion.Text);
                    }
                    return Ok(stringBuilder.ToString());
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An exception occurred processing the request: {ex.Message}");
            }
        }
    }
    public class OpenAIOptions
    {
        public string ApiKey = "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";
    }
}

