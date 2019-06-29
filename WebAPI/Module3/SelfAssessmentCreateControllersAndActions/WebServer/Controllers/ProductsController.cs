using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        //ok
        //defaults to api/products
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            if (FakeData.Products != null)
            {
                return Ok(FakeData.Products.Values.ToArray());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetProductByID(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                return Ok(FakeData.Products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        //ok
        //this function structure was needed to check from earlier examples
        [HttpGet("price/{low}/{high}")]
        public ActionResult GetProductsBetweenPrice(int low, int high)
        {

            var products = FakeData.Products.Values
            .Where(p => p.Price >= low && p.Price <= high).ToArray();
            if (products.Length > 0)
            { //Linq ensures that array cant be null
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItemByID(int id)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                FakeData.Products.Remove(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //ok
        //this function structure was needed to check from earlier assignments
        [HttpPost]
        public ActionResult PostNewIttem([FromBody]Product newProduct)
        {
            //generate new id
            newProduct.ID = FakeData.Products.Keys.Max() + 1;
            // parse json string from body
            //assign values to the list
            //Add product to the list
            FakeData.Products.Add(newProduct.ID, newProduct);
            return Created($"api/products/{newProduct.ID}", newProduct);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody]Product updatedProduct)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                FakeData.Products[id].ID = updatedProduct.ID;
                FakeData.Products[id].Name = updatedProduct.Name;
                FakeData.Products[id].Price = updatedProduct.Price;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //get increateamount
        //loop all products
        //increase their price by amount
        //return responses ok and not found
        //check for not null

        [HttpPut("raise/{amount}")]
        public ActionResult UpdateAllProductsByAmount(int amount)
        {
            if (FakeData.Products != null)
            {
                var allProducts = FakeData.Products.ToArray();
                if (allProducts.Length > 0) //linq ensurs that product cant be null
                {
                    //update price of every item;
                    for (int i = 0; i < allProducts.Length; i++)
                    {
                        var item = allProducts[i].Value;
                        item.Price += amount;
                    }
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}