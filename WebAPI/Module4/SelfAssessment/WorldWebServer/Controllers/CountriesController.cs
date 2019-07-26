using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller 
    {
        private WorldDbContext dbContext;

        public CountriesController() {
            string connectionString = "server=localhost;port=3306;database=world;userid=root;pwd=toorlan1;sslmode=none";
            this.dbContext = WorldDbContextFactory.Create(connectionString);
        }

        [HttpGet]
        public ActionResult Get() {
            return Ok(this.dbContext.Country.ToArray());
        }
    }
}