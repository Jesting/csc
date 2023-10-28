using System;
using System.Text;
using Lection18Program2.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Lection18Program2.Controllers
{
    [LogActionFilter]
    [ApiController]
    [Route("[controller]")]
    public class CrudController:ControllerBase
	{
        static Dictionary<string, string> data = new Dictionary<string, string>();

        [HttpPost(template: "post")]
        public async Task<ActionResult> PostAsync(string key, string value)
        {
            var reader = await Request.BodyReader.ReadAsync();
            Request.Body.Position = 0;
            var buffer = reader.Buffer;
            var body = Encoding.UTF8.GetString(buffer.FirstSpan);
            Request.Body.Position = 0;

            try
            {
                data.Add(key, value);
                return Ok();
            }
            catch 
            {
                return StatusCode(409);
            }
        }

        [HttpGet(template: "get")]
        public ActionResult<string> Get(string key)
        {
            if (data.ContainsKey(key))
            {
                return Ok(data[key]);
            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpPut(template: "put")]
        public ActionResult Put(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
                
            }
            else
            {
                data.Add(key, value);
            }
            return Ok();
        }

        [HttpPatch(template: "patch")]
        public ActionResult Patch(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
                return Ok();

            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpDelete(template: "delete")]
        public ActionResult Delete(string key)
        {
            if (data.ContainsKey(key))
            {
                data.Remove(key);
                return Ok();

            }
            else
            {
                return StatusCode(404);
            }
        }

    }
}

