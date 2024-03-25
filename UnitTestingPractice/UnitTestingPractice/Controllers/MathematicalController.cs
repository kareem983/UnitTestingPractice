using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestingPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathematicalController : ControllerBase
    {
        
        [HttpGet("GetSumTwoNumbers/{x}/{y}")]
        public int GetSumTwoNumbers(int x, int y)
        {
            return x + y;
        }

        [HttpGet("GetAbstractTwoNumbers/{x}/{y}")]
        public int GetAbstractTwoNumbers(int x, int y)
        {
            return x - y;
        }

        [HttpGet("GetMultiplyTwoNumbers/{x}/{y}")]
        public int GetMultiplyTwoNumbers(int x, int y)
        {
            return x * y;
        }

        [HttpGet("GetDividTwoNumbers/{x}/{y}")]
        public int GetDividTwoNumbers(int x, int y)
        {
            if (y == 0) 
                return 0;
            
            return x / y;
        }
    }
}
