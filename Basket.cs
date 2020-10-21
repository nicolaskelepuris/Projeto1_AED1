using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    class Basket
    {
        // basketItem has a Product and its Quantity
        private Dictionary<Product, int> basketItem;

        public Basket()
        {
            basketItem = new Dictionary<Product, int>();
        }

        public void AddOrUpdateItemToBasket(Product product, int quantityOfProductToBeAddedOrUpdatedInBasket)
        {
            var quantityOfProductsInStock = Stock.GetStockQuantityOfProduct(product);

            // add item to basket if this basket does not contain this product, else only update it's quantit
            if (!basketItem.ContainsKey(product))
            {
                // check if quantity of product that customer asked for is available in stock
                if (quantityOfProductsInStock >= quantityOfProductToBeAddedOrUpdatedInBasket)
                {
                    basketItem.Add(product, quantityOfProductToBeAddedOrUpdatedInBasket);
                }
                else
                {
                    basketItem.Add(product, quantityOfProductsInStock);
                    Console.WriteLine
                        ("\nA quantidade do produto {0} excede a quantidade disponivel ({1} unidades) no estoque.\nO pedido foi efetuado considerando apenas a quantidade disponivel no estoque", product.Name, quantityOfProductsInStock);
                }
            }
            else
            {
                // check if quantity of product that customer asked for is available in stock
                if (quantityOfProductsInStock >= quantityOfProductToBeAddedOrUpdatedInBasket)
                {
                    basketItem[product] = quantityOfProductToBeAddedOrUpdatedInBasket;
                }
                else
                {
                    basketItem[product] = quantityOfProductsInStock;
                    Console.WriteLine
                            ("\nA quantidade do produto {0} excede a quantidade disponivel ({1} unidades) no estoque.\nO pedido foi efetuado considerando apenas a quantidade disponivel no estoque", product.Name, quantityOfProductsInStock);
                }
            }
            Console.WriteLine("\nItem adicionado ao carrinho:\nProduto: {0}    |     Quantidade: {1}    |     Valor unitario: {2}", product.Name, basketItem[product], product.Price);
            
            var basketItems = this.GetCopyOfListOfItemsInBasket();
            BasketManager.PrintAllBasketItems(basketItems);
        }

        public Dictionary<Product, int> GetCopyOfListOfItemsInBasket()
        {
            return new Dictionary<Product, int>(basketItem);
        }
    }
}
