using System;
namespace Lection16Program2
{
    public class Calculator
    {
        private readonly ICalculatorService _calculatorService;

        public Calculator(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public int Add(int a, int b)
        {
            return _calculatorService.Add(a, b);
        }

        public int Subtract(int a, int b)
        {
            return _calculatorService.Subtract(a, b);
        }
    }
}

