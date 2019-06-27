using System;
using Newtonsoft.Json;

namespace ProductSeDe
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Product myProduct = new Product() {ID = 0, Name = "Coffee", Price = 2.5};
            //serialize product
            string jSonString = SerializeProduct(myProduct);
            Console.WriteLine("============== Product Seriliazed ==============");
            Console.WriteLine(jSonString);
            Console.WriteLine("==============");
            Console.WriteLine();
            Console.WriteLine("============== new assigned Product Deseriliazed ==============");
            Product mySecondProduct = DeSerializeProduct(jSonString);
            
            //print product  object details details
            Console.WriteLine();
            Console.WriteLine("============== Objects' details before modification ==============");
            DisplayProductDetails(myProduct);
            Console.WriteLine("==============");
            DisplayProductDetails(mySecondProduct);
            Console.WriteLine("==============");

            //modify second product to check if it has reference to the first beacuse the type of return from DeSerializeProduct function
            Console.WriteLine();
            Console.WriteLine("============== modifying second product details ==============");
            mySecondProduct.ID =3;
            mySecondProduct.Name = "Tea";
            Console.WriteLine();
            
            //print serialized details after modification
            Console.WriteLine(" ============== JSONs after modification ==============");
            Console.WriteLine(SerializeProduct(myProduct));
            Console.WriteLine("==============");
            Console.WriteLine(SerializeProduct(mySecondProduct));
            Console.WriteLine("==============");
            Console.WriteLine();
            //print product  object details details after modification
            Console.WriteLine(" ============== Objects after modification ==============");
            DisplayProductDetails(myProduct);
            Console.WriteLine("==============");
            DisplayProductDetails(mySecondProduct);
            Console.WriteLine("==============");
        }

        public static string SerializeProduct(Product product) {
            return JsonConvert.SerializeObject(product);
        }

        //returns new Object from serialized string
        public static Product DeSerializeProduct(string productString) {
                return JsonConvert.DeserializeObject<Product>(productString);
        }

        public static void DisplayProductDetails(Product product) {
            Console.WriteLine($"Product ID: {product.ID}");
            Console.WriteLine($"Product Name: {product.Name}");
            Console.WriteLine($"Product Price: {product.Price}");
        }

    }
}
