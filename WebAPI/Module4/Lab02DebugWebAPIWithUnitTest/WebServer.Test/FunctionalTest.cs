using Xunit;

namespace WebServer.Test
{
    public class FunctionalTest {


        [Fact]
        public void CreateProductsControllerInstanceTest()
        {
            var controller = new ProductsController();
            Assert.NotNull(controller);
        }

    }
}