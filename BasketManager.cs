using System;
using System.Collections.Generic;

namespace Projeto1AED1
{
    public static class BasketManager
    {
        public static void PrintAllBasketItems(Dictionary<Product, int> basketItems)
        {
            Console.WriteLine("\nLista de todos os produtos adicionados:");

            foreach (var product in basketItems.Keys)
            {
                // Check every product in basket if its quantity ordered is available in stock, else update product quantity in basket to quantity in stock
                var quantityOfProductsInStock = Stock.GetStockQuantityOfProduct(product);
                if (quantityOfProductsInStock < basketItems[product])
                {
                    basketItems[product] = quantityOfProductsInStock;
                    Console.WriteLine("\nO produto {0} tem apenas {1} unidades disponiveis no estoque, o pedido foi efetuado considerando apenas a quantidade disponivel no estoque",
                                    product, quantityOfProductsInStock);
                }

                Console.WriteLine("Produto: {0}    |     Quantidade: {1}    |     Valor unitario: {2}    |     Valor total do item: {3}", product.Name, basketItems[product], product.Price, (decimal)basketItems[product] * product.Price);
            }
        }
    }
}