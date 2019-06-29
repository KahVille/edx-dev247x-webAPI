using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class CalculationsController : Controller {

        //Query String
        //api/calculations/add?a=100&b=200
        [HttpGet("add")]
        public double Add([FromQuery]double a, [FromQuery]double b) {
            return a + b;
        }

        //Values from URL
        //api/calculations/sub/a/200/b/100
        [HttpGet("sub/a/{a}/b/{b}")]
        public double Sub([FromRoute]double a, [FromRoute]double b) {
            return a - b;
        }

        /*
        Request body
        /localhost:5000/api/calculations/mul
        { "a": 100, "b": 200 }
        */
        [HttpPost("mul")]
        public double Mul([FromBody]CalculationParameter p) {
            return p.A * p.B;
        }

        //Extract Values from <form> Body, form-data key value pairs
        //the form data is not a JSON object
        [HttpPost("div")]
        public double Div([FromForm]CalculationParameter p) {
            return p.A / p.B;
        }
    }
}