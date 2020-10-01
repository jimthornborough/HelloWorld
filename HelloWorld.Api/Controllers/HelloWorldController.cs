using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Common;

namespace HelloWorld.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HelloWorldDTO GetMessage()
        {
            return new HelloWorldDTO { MessageText = "Hello World" };
        }

        [HttpPost]
        public ActionResult<HelloWorldDTO> SaveMessage(HelloWorldDTO helloWorldDTO)
        {
            // TO DO: Write To Database

            return new HelloWorldDTO { Id = 100, MessageText = helloWorldDTO.MessageText };
        }
    }
}
