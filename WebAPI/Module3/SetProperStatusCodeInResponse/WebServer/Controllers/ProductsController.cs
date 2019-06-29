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

        [HttpGet("from/{low}/to/{high}")]
        public Product[] Get(int low, int high) {
            var products = FakeData.Products.Values
            .Where(p => p.Price >= low && p.Price <= high).ToArray();
            return products;
        }

        [HttpPost]
        public Product Post([FromBody]Product product) {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return product; // contains the new ID
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product) {
            if (FakeData.Products.ContainsKey(id)) {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
            }
        }
    }
}