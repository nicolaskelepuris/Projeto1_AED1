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
            
            Console.WriteLine("\nPagamento realizado!");

            BasketManager.PrintAllBasketItems(basketItems);

            foreach (var product in basketItems.Keys)
            {
                // sum every product quantity by its price to get total order price
                TotalPrice += product.Price * basketItems[product];
            }

            Console.WriteLine("\nValor total do pedido: {0}", TotalPrice);

            Console.WriteLine("\nPedido efetuado com sucesso!\nOs produtos serão separados e entregues em ate 20 minutos para o cliente {0} no endereço:\n{1} - {2} - {3}",
                            address.CustomerName, address.City, address.Street, address.Number);
        }
    }
}
