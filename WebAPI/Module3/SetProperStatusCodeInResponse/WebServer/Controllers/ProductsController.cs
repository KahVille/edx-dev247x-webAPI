using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {


        //if null is sent without correct response the client will receive a 500 Internal Server Error
        //thats why use NotFound response which is correct.
        [HttpGet]
        public ActionResult Get() {
            if (FakeData.Products != null)
            {
                return Ok(FakeData.Products.Values.ToArray());
            }
            else {
                return NotFound();
            }
            
        }

        //if null is sent without correct response the client will receive a 204 No Content
        //thats why use NotFound response which is correct.
        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            if (FakeData.Products.ContainsKey(id))
                return Ok(FakeData.Products[id]);
            else
                return NotFound();
        }

        //if null is sent without correct response the client will receive a 204 No Content
        //thats why use NotFound response which is correct.
        [HttpGet("from/{low}/to/{high}")]
        public ActionResult Get(int low, int high) {
            var products = FakeData.Products.Values
            .Where(p => p.Price >= low && p.Price <= high).ToArray();
            if(products.Length > 0) { // LINQ guarantees the products won't be null
                return Ok(products); 
            }
            else {
                return NotFound();
            }

            
        }


        //the best status code for post request of creation is 201 Created
        //return created status code
        /*  
        pass url in created method
        url will be in the http response header
        this is the concept of HATEOAS
        */
        [HttpPost]
        public ActionResult Post([FromBody]Product product) {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return Created($"api/products/{product.ID}",product); // contains the new ID
        }

        //if no return value is provided the client will receive a 200 OK even if the update is unsuccessful 
        //thats why apply NotFound response and ok responses accordingly.
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product) {
            if (FakeData.Products.ContainsKey(id)) {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        //client shoud recieve response whether the delete is successful or not
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
                return Ok();
            }
            else {
                return NotFound();
            }
        }
    }
}