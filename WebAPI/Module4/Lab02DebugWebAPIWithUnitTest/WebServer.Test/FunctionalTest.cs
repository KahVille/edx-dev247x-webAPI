using Xunit;
using WebServer.Controllers;
using WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebServer.Test
{
    public class FunctionalTest
    {


        //namspace of ProductsController could not be found
        [Fact]
        public void CreateProductsControllerInstanceTest()
        {
            var controller = new ProductsController();
            Assert.NotNull(controller);
        }

        //Assert.NotNull() Failure of Repository.Products at line 21
        //Assert.Equal() Failure Expected: 4 Actual: 3 at line 22
        //Assert.Equal() Failure Expected: 2 Actual: 3 at line 36

        [Fact]
        public void RepositoryInitializationTest()
        {
            Assert.NotNull(Repository.Products);
            Assert.Equal(5, Repository.Products.Count);

            foreach (var id in new int[] { 0, 1, 2, 3, })
            {
                Assert.True(Repository.Products.ContainsKey(id));
            }

            foreach (var key in Repository.Products.Keys)
            {
                Assert.Equal(key, Repository.Products[key].ID);
            }
        }

        [Fact]
        public void GetActionTest() 
        {
            var controller = new ProductsController();
            Assert.IsType<OkObjectResult>(controller.Get());
            foreach (var key in Repository.Products.Keys)
            {
                 Assert.IsType<OkObjectResult>(controller.Get(key));
            }
        }

        //Assert.Equal() Failure Expected: 5 Actual: 4
        //the new product was not added to the list
        [Fact]
        public void PostActionTest()
        {
            var controller = new ProductsController();
            int oldCount = Repository.Products.Count;
            var product = new Product {Name = "Test Product", Price=9.9};
            Assert.IsType<CreatedResult>(controller.Post(product));
            Assert.Equal(oldCount+ 1,Repository.Products.Count);
        }

        [Fact]
        public void DeleteActionTest()
        {
            var controller = new ProductsController();
            int oldCount = Repository.Products.Count;
            var maxKey = Repository.Products.Keys.Max();
            Assert.IsType<OkResult>(controller.Delete(maxKey));
            Assert.Equal(oldCount -1,Repository.Products.Count);
        }


        //test ran fine but seems like there is a bug
        [Fact]
        public void PutActionTest()
        {
            var controller = new ProductsController();
            int oldCount = Repository.Products.Count;
            var maxKey = Repository.Products.Keys.Max();
            var product = Repository.Products[maxKey];
            product.Name = "Changed";
            Assert.IsType<OkResult>(controller.Put(maxKey,product));
            Assert.Equal(oldCount,Repository.Products.Count);
        }




    }
}