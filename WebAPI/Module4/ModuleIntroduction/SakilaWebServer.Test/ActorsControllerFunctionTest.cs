using System;
using Microsoft.AspNetCore.Mvc;
using SakilaWebserver.Models;
using SakilaWebServer.Controllers;
using Xunit;


/*
The goal of the functional test is to verify if the functions of our controllers and actions are implemented correctly. 
To avoid any impact from other factors, such as URL routes and model bindings, the functional test cases will call the actions directly.
 */


namespace SakilaWebserver.Test
{
    public class ActorsControllerFunctionTest {

        [Fact]
        public void GetActorByIdSmokeTest() {
            var controller = new ActorsController();
            var result = controller.Get(101) as OkObjectResult;
            var actor = result.Value as Actor;
            //swapping the expected and actual parameters from (Actor_ID,101) to (101,Actor_ID) fixed xunit warning about working with literals
            Assert.Equal(101,actor.Actor_ID); 
            Assert.Equal("SUSAN",actor.First_Name);
            Assert.Equal("DAVIS",actor.Last_Name);
        }
    }
}