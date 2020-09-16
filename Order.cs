using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    class Order
    {
        public int ID { get; private set; }
        Basket basket;
        decimal TotalPrice;
        public Order(Basket basket, Address address, int orderID)
        {
            ID = orderID;
            this.basket = basket;
            var basketItems = basket.GetCopyOfListOfItemsInBasket();
            Console.WriteLine("\nProdutos pedidos:");
            foreach (var product in basketItems.Keys)
            {
                var quantityOfProductsInStock = Stock.GetStockQuantityOfProduct(product);
                if (quantityOfProductsInStock < basketItems[product])
                {
                    basketItems[product] = quantityOfProductsInStock;
                    Console.WriteLine("\nO produto {0} tem apenas {1} unidades disponiveis no estoque, o pedido foi efetuado considerando apenas a quantidade disponivel no estoque",
                                    product, quantityOfProductsInStock);
                }

                TotalPrice += product.Price * basketItems[product];
                Console.WriteLine("Produto: {0}    |     Quantidade: {1}    |     Valor unitario: {2}", product.Name, basketItems[product], product.Price);
            }

            Console.WriteLine("\nValor total do pedido: {0}", TotalPrice);

            Console.WriteLine("\nPedido efetuado com sucesso!\nOs produtos serão separados e entregues em ate 20 minutos para o cliente {0} no endereço:\n{1}, {2}, {3}",
                            address.CustomerName, address.City, address.Street, address.Number);
        }
    }
}
