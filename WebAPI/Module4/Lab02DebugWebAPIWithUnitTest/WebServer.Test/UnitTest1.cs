using System;
using Xunit;

/*
Sending an HTTP GET request to api/products should get all four products
Send an HTTP GET request to api/products/1 should get the product matches to the ID
Send an HTTP DELETE request to api/products/1 should delete the product matches to the ID
Send an HTTP POST request to api/products with the JSON body satisfies the Product class should add a new product on the server
Send an HTTP PUT request to api/products/1 with the JSON body satisfies the Product class should update the product matches to the ID
 */


namespace WebServer.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
