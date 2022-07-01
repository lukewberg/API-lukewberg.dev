using API_lukewberg.dev.Models.Payloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace API_lukewberg.dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] AuthPayload model)
        {
            try
            {
                Payload payload = await ValidateAsync(model.id, new ValidationSettings { 
                    Audience = new[] {$"{_configuration.GetSection("Authentication:Google:ClientId").Value}"}
                });

                return new JsonResult(payload);
            }
            catch
            {
                return new JsonResult("");
            }
        }
    }
}
