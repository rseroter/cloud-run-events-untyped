using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CloudNative.CloudEvents;
using System.Text.Json;

namespace core_sample_api.Controllers
{
    [ApiController]
    [Route("")]
    public class Eventsontroller : ControllerBase
    {

        private readonly ILogger<Eventsontroller> _logger;

        public Eventsontroller(ILogger<Eventsontroller> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post(object receivedEvent)
        {
            //[FromBody] CloudEvent

            string s = JsonSerializer.Serialize(receivedEvent);

            Console.WriteLine("POST endpoint called");
            Console.WriteLine("Data: " + s);
        }
    }
}
