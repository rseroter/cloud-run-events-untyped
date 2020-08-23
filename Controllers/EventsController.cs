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
            Console.WriteLine("POST endpoint called");

            string s = JsonSerializer.Serialize(receivedEvent);

            //see if custom event with "message" root property, and has encoded "body" property
            using(JsonDocument d = JsonDocument.Parse(s)){

                JsonElement root = d.RootElement;
                if(root.TryGetProperty("message", out JsonElement msg)) {
                    Console.WriteLine("Custom event detected");

                    JsonElement data = msg.GetProperty("data");
                    Console.WriteLine("Data value is: " + data.GetString());
                }
            }



            
            Console.WriteLine("Data: " + s);
        }
    }
}
