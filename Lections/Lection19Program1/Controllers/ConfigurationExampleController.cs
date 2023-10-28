using System;
using Microsoft.AspNetCore.Mvc;

namespace Lection19Program1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ConfigurationExampleController:ControllerBase
	{
		private IConfiguration _configuration;

		public ConfigurationExampleController(IConfiguration conf)
		{
			_configuration = conf;
		}


        public class VersionInfo
        {
            public string Number { get; set; }
            public string Code { get; set; }
        }


        [HttpGet(template: "GetVersion")]
        public ActionResult<string> GetVersion()
        {
            var version = _configuration.GetSection("VersionInfo").Get<VersionInfo>();
            return Ok(version.Code);
        }
    }
}

