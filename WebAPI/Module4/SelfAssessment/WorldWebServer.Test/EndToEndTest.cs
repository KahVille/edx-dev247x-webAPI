using System.Net.Http;
using System.Net.Http.Headers;
using WorldWebServer.Models;

namespace WorldWebServer.Test
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
        
        private bool SameCity(City c1, City c2) {
            return c1.ID == c2.ID
            && c1.Name == c2.Name
            && c1.CountryCode == c2.CountryCode
            && c1.District == c2.District
            && c1.Population == c2.Population;
        }

        

    }
}