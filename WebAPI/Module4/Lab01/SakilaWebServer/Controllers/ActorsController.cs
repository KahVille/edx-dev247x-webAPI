using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SakilaWebServer.Models;

namespace SakilaWebServer.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private SakilaDbContext dbContext;

        public ActorsController()
        {
            string connectionString = "server=localhost;port=3306;database=sakila;userid=root;pwd=toorlan1;sslmode=none";
            dbContext = SakilaDbContextFactory.Create(connectionString);
        }

        //GET api/actors
        [HttpGet]
        public ActionResult GetAllActors()
        {
            return Ok(dbContext.Actor.ToArray());
        }

        //GET api/actors/101
        [HttpGet("{id}")]
        public ActionResult GetActorByID(int id)
        {
            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (actor != null)
            {
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }
        }

        //POST api/actors
        [HttpPost]
        public ActionResult PostNewActor([FromBody]Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            dbContext.Actor.Add(actor);
            dbContext.SaveChanges();
            return Created("api/actors", actor);
        }

        //PUT api/actors/101
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Actor actor)
        {
            var target = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (target != null && ModelState.IsValid)
            {
                dbContext.Entry(target).CurrentValues.SetValues(actor);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE api/actors/101
        [HttpDelete("{id}")]
        public ActionResult DeleteActor(int id)
        {

            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (actor != null)
            {
                dbContext.Actor.Remove(actor);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}