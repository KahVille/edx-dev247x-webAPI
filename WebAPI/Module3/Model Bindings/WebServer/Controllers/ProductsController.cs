using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        
        //Parse the Model from Query String
        //api/products?id=101&name=P101&price=99.99
        [HttpGet]
        public Product Action1([FromQuery]Product product) {
            return product;
        }

        //Parse the Model from Route
        //api/products/101/P101/99.99
        [HttpGet("{id}/{name}/{price}")]
        public Product Action2([FromRoute]Product product) {
            return product;
        }

        //Mix the Query String and Route
        //api/products/101/P101?price=99.99
        [HttpGet("{id}/{name}")]
        public Product Action3(Product product) {
            return product;
        }

        //Parse the Model from Form Data
        //Set the body type to be form-data. 
        //send key value pairs
        //Not a JSON object
        //api/products
        [HttpPost]
        public Product Action4([FromForm]Product product) {
            return product;
        }

        //Parse the Model from JSON Body
        //internal server error, might because my local config
        //api/products
        [HttpPost]
        public Product Action5([FromBody]Product product) {
            return product;
        }

        //no conclusion of the syntax parameters with postman, extreme case
        [HttpPost("{id}/{name}/{price}")]
        public Product[] Action6([FromRoute]Product p1, [FromQuery] Product p2, [FromBody]Product p3) {
            return new Product[] { p1, p2, p3 };
        }

         //no conclusion of the syntax parameters with postman, extreme case
        [HttpPost("{id}/{name}/{price}")]
        public Product[] Action7([FromRoute]Product p1, [FromQuery] Product p2, [FromForm]Product p3) {
            return new Product[] { p1, p2, p3 };
        }
    }
}