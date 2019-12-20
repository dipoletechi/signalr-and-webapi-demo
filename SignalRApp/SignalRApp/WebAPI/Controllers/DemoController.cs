using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {        
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]      
        public object Post([FromBody]ChatModel chatmodel)
        {
            Console.WriteLine(chatmodel.Message);
            return chatmodel.Message;
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome to signalR demo";
        }
    }
}
