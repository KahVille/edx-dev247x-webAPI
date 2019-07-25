using Xunit;
using WebServer.Controllers;
using WebServer.Models;
using Microsoft.AspNetCore.Mvc;

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
            Assert.Equal(4, Repository.Products.Count);

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
        void GetActionTest() 
        {
            var controller = new ProductsController();
            Assert.IsType<OkObjectResult>(controller.Get());
            foreach (var key in Repository.Products.Keys)
            {
                 Assert.IsType<OkObjectResult>(controller.Get(key));
            }
        }


    }
}