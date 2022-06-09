using Microsoft.AspNetCore.Mvc;

namespace RESTWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var first = ConvertToDecimal(firstNumber);
                var second = ConvertToDecimal(secondNumber);
                var first_double = decimal.ToDouble(first);
                var second_double = decimal.ToDouble(second);

                var sum = first + second;
                var sub = first - second;
                var mult = first * second;
                var div = first / second;
                var raiz_first = Convert.ToDecimal(Math.Sqrt(first_double));
                var raiz_second = Convert.ToDecimal(Math.Sqrt(second_double));
                var media = (first + second) / 2;
                var total = "Subtração: " + sub.ToString() +
                    "\r\nSoma: " + sum.ToString() +
                    "\r\nMultiplicação: " + mult.ToString() +
                    "\r\nDivisão: " + div.ToString() +
                    "\r\nRaiz do 1°: " + raiz_first +
                    "\r\nRaiz do 2°: " + raiz_second +
                    "\r\nMedia: " + media;
                return Ok(total);
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}