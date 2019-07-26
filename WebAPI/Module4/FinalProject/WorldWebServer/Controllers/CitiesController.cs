using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorldWebServer.Models;

namespace WorldWebServer.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private WorldDbContext dbContext;

        public CitiesController()
        {
            string connectionString = "server=localhost;port=3306;database=world;userid=root;pwd=toorlan1;sslmode=none";
            this.dbContext = WorldDbContextFactory.Create(connectionString);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this.dbContext.City.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult GetAction(int id)
        {

            City target = this.dbContext.City.SingleOrDefault(ct => ct.ID == id);
            if (target != null)
            {
                return Ok(target);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("cc/{cc}")]
        public ActionResult GetAction(string cc)
        {
            var cities = this.dbContext.City
            .Where(ct => string.Equals(ct.CountryCode, cc, System.StringComparison.CurrentCultureIgnoreCase))
            .ToArray();
            return Ok(cities);
        }

        [HttpPost]
        public ActionResult Post([FromBody] City city)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            this.dbContext.City.Add(city);
            this.dbContext.SaveChanges();
            return Created($"api/cities/{city.ID}", city);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] City city)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            City target = this.dbContext.City.SingleOrDefault(ct => ct.ID == id);
            if (target != null)
            {
                this.dbContext.Entry(target).CurrentValues.SetValues(city);
                this.dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            City target = this.dbContext.City.SingleOrDefault(ct => ct.ID == id);

            if (target != null)
            {
                this.dbContext.City.Remove(target);
                this.dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}