using System.Collections.Generic;

namespace WebServer.Models
{
    public class FakeData
    {
        public static IDictionary<int, Product> Products;

        static FakeData() {
            Products = new Dictionary<int,Product>();
            Products.Add(0, new Product{ID = 0, Name = "Apple", Price = 55.55});
            Products.Add(1, new Product {ID = 0, Name = "Bike", Price = 6.66});
            Products.Add(2, new Product {ID = 0, Name = "Coffee", Price = 7.77});
        }

    }
}