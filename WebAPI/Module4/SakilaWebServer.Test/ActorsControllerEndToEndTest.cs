using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SakilaWebserver.Models;
using SakilaWebServer.Controllers;
using Xunit;


namespace SakilaWebserver.Test
{
    public class ActorsControllerEndToEndTest
    {
        [Fact]
        public async void GetActorByIdSmokeTest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
                var response = await httpClient.GetAsync("api/actors/101");
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }

                Actor actor = JsonConvert.DeserializeObject<Actor>(jsonString);
                Assert.NotNull(actor);
                Assert.Equal(101,actor.Actor_ID);
                Assert.Equal("SUSAN",actor.First_Name);
                Assert.Equal("DAVIS",actor.Last_Name);
            }
        }
    }
}