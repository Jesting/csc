using System.Net;
using Lection18Program2.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Lection18Program2.Controllers
{
    [LogActionFilter]
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public MathController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet(template: "square")]
        public int Square(int x)
        {
            return x * x;
        }

        [HttpGet(template: "divide")]
        public ActionResult<int> Divide(int x, int y)
        {
            try
            {
                var z = x / y;
                return Ok(z);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private static int CalculateFibonacci(int number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

            if (number > 46)
                throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

            int first = 1, second = 1;

            for (int i = 2; i <= number; i++)
            {
                int temp = first;
                first = second;
                second = first + temp;
            }

            return first;
        }


        [HttpGet(template: "fibonacci")]
        public async Task<ActionResult<int>> FibonaccuAsync(int x, int y)
        {
            var rx = await Task.Run(() => CalculateFibonacci(x));
            var ry = await Task.Run(() => CalculateFibonacci(y));

            return Ok(rx + ry);
        }

    }
}

