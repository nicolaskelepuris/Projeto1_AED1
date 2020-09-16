using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto1AED1
{
    static class ProductsRegisterManager
    {
        static List<Product> listOfProductsRegistered = new List<Product>();
        public static void RegisterAllProducts()
        {
            string[] productNamesToBeRegistered = new string[]{"pao", "pao doce", "pao salgado",
                                                            "pao quente", "pao frio", "pao a recheado",
                                                            "pao com queijo", "pao com ovo"};
            string[] productDescriptionsTobeRegistered = new string[]{"apenas um pao", "apenas um pao doce", "apenas um pao salgado",
                                                            "apenas um pao quente", "apenas um pao frio", "apenas um pao a recheado",
                                                            "apenas um pao com queijo", "apenas um pao com ovo"};
            decimal[] productPricesToBeRegistered = new decimal[] { 1, 1.2m, 1.5m, 1.8m, 1.5m, 2.1m, 3.4m, 4.2m };

            for (int i = 0; i < productNamesToBeRegistered.Length; i++)
            {
                listOfProductsRegistered.Add(new Product(i, productNamesToBeRegistered[i], productPricesToBeRegistered[i], productDescriptionsTobeRegistered[i],
                                            new Random().Next(1, 21), DateTime.Now.AddDays(3)));
            }
        }

        public static List<Product> GetCopyOfListOfProductsRegistered()
        {
            return new List<Product>(listOfProductsRegistered);
        }

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
