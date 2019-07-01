using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServer.Models;


/*
The frontend will send a GET request to api/products to get all products.
The frontend will send a GET request to api/products/101 to get the product whose ID is 101
The frontend will send a GET request to api/products/price/6/9 to get the products whose price is between 6 and 9.
The frontend will send a DELETE request to api/products/101 to delete the product whose ID is 101
The frontend will send a POST request to api/products to create a new product
The frontend will send a PUT request to api/products/101 to update the product whose ID is 101
The frontend will send PUT request to api/products/raise/3 to raise the price of all products by 3

Please note, the actions should deal with the corner cases such as the product does not exist.

 */

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

        //ok
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

        //ok
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

        //ok
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

        //ok
        [HttpPut("raise/{amount}")]
        public ActionResult UpdateAllProductsByAmount(int amount)
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
    }
}