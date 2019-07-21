using Xunit;
using WebServer.Controllers;

namespace WebServer.Test
{
    public class FunctionalTest {


        //namspace of ProductsController could not be found
        [Fact]
        public void CreateProductsControllerInstanceTest()
        {
            var controller = new ProductsController();
            Assert.NotNull(controller);
        }

    }
}