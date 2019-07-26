using System.Net.Http;
using System.Net.Http.Headers;
using WebServer.Models;
using Xunit;
using Newtonsoft.Json;

namespace WebServer.Test
{
    public class EndToEndTest
    {
        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("http://localhost:5000");
            var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
            return httpClient;
        }

        private bool SameProduct(Product p1, Product p2) 
        {
            return p1.ID == p2.ID && p1.Name == p2.Name && p1.Price == p2.Price;
        }

        [Fact]
        public async void GetActionTest()
        {
            var httpClient = GetHttpClient();
            var allProductsResponse = await httpClient.GetAsync("api/products");
            Assert.True(allProductsResponse.IsSuccessStatusCode);
            var allProductsJson = await allProductsResponse.Content.ReadAsStringAsync();
            var allProducts = JsonConvert.DeserializeObject<Product[]>(allProductsJson);
            Assert.NotNull(allProducts);
            Assert.True(allProducts.Length > 0);
        }


    }
}