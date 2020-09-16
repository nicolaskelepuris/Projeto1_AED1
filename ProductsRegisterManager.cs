using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto1AED1
{
    static class ProductsRegisterManager
    {
        static List<Product> listOfProductsRegistered = new List<Product>();

        // register all products with random number of quantity of product in stock
        public static void RegisterAllProducts()
        {
            string[] productNamesToBeRegistered = new string[]{"pao", "pao doce", "pao salgado",
                                                            "pao quente", "pao frio", "pao a recheado",
                                                            "pao com queijo", "pao com ovo"};
            string[] productDescriptionsTobeRegistered = new string[]{"apenas um pao", "apenas um pao doce", "apenas um pao salgado",
                                                            "apenas um pao quente", "apenas um pao frio", "apenas um pao a recheado",
                                                            "apenas um pao com queijo", "apenas um pao com ovo"};
            decimal[] productPricesToBeRegistered = new decimal[] { 1.00m, 1.20m, 1.50m, 1.80m, 1.50m, 2.10m, 3.40m, 4.50m };

            for (int i = 0; i < productNamesToBeRegistered.Length; i++)
            {
                listOfProductsRegistered.Add(new Product(i, productNamesToBeRegistered[i], productPricesToBeRegistered[i], productDescriptionsTobeRegistered[i],
                                            new Random().Next(1, 21), DateTime.Now.AddDays(3)));
            }
        }

        // returns copy of list with products registered
        public static List<Product> GetCopyOfListOfProductsRegistered()
        {
            return new List<Product>(listOfProductsRegistered);
        }

        // returns product found by id, if there's no product with id from parameter return null
        public static Product GetProductRegisteredByID(int id)
        {
            var ProductsWithIDRequired = listOfProductsRegistered.Where(x => x.ID == id);
            if (ProductsWithIDRequired.Any())
            {
                return ProductsWithIDRequired.First();
            }

            Console.WriteLine("Nao existe produto com esse id");
            return null;
        }
    }
}
