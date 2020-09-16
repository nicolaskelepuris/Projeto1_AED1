using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    static class Stock
    {
        // dictionary for product and it's quantity in stock
        static Dictionary<Product, int> stock = new Dictionary<Product, int>();

        public static void AddOrUpdateStockOfProduct(Product product, int quantityOfProduct)
        {
            // add new product to stock if stock does not contain product, else just update product quantity in stock
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
            // check if stock contains product before getting it's quantity
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
