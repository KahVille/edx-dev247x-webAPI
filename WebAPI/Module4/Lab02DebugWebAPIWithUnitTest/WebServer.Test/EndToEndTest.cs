using System.Net.Http;
using System.Net.Http.Headers;
using WebServer.Models;

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

    }
}