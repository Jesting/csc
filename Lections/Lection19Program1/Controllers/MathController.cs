using Lection19Program1.util;
using Microsoft.AspNetCore.Mvc;

namespace Lection19Program1.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly IFibonacci _fibonacci;

        public MathController(IFibonacci fibonacci)
        {
            _fibonacci = fibonacci;
        }

        [HttpGet(template: "fibonacci")]
        public ActionResult<int> Fibonaccu(int x)
        {
            return Ok(_fibonacci.CalculateFibonacci(x));
        }

    }
}

