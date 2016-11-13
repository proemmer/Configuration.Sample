using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Configuration.Sample.Configuration;

namespace Configuration.Sample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IOptionsMonitor<MySettings> _settings;
        public IOptions<MySettings> Options { get; set; }

        public ValuesController(IOptions<MySettings> options, IOptionsMonitor<MySettings> settings)
        {
            _settings = settings;
            Options = options;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Options.Value.MySettingsNumber++;
            return Options.Value.MySettingsEnryList;
        }

        [HttpGet("Number")]
        public int GetNumber()
        {
            return Options.Value.MySettingsNumber;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Options.Value.MySettingsEnry1;
        }
       
    }
}
