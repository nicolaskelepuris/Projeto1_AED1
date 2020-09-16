using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    static class Stock
    {
        static Dictionary<Product, int> stock = new Dictionary<Product, int>();

        public static void AddOrUpdateStockOfProduct(Product product, int quantityOfProduct)
        {
            if (!stock.ContainsKey(product))
            {
                stock.Add(product, quantityOfProduct);
            }
            else
            {
                stock[product] = quantityOfProduct;
            }
        }

        public static int GetStockQuantityOfProduct(Product product)
        {
            if (stock.ContainsKey(product))
            {
                return stock[product];
            }
            else
            {
                Console.WriteLine("Esse produto não está cadastrado no estoque");
                return 0;
            }
        }
    }
}
