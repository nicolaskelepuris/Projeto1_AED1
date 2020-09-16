using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    static class CustomerService
    {
        static int addressID;
        static int orderID;
        static List<Product> listOfProductsRegistered = new List<Product>(ProductsRegisterManager.GetCopyOfListOfProductsRegistered());
        private static Address AskForCustomerAddress()
        {
            Console.WriteLine("Favor informar o endereço para entrega dos produtos. \n\nCidade: ");
            var city = Console.ReadLine();

            Console.WriteLine("\nRua: ");
            var street = Console.ReadLine();

            Console.WriteLine("\nNumero da casa (caso seja apartamento digitar NumeroDoPredio-NumeroDoApartamento): ");
            var houseNumber = Console.ReadLine();

            Console.WriteLine("\nNome do cliente: ");
            var customerName = Console.ReadLine();

            return new Address(addressID++, street, houseNumber, city, customerName);
        }

        public static Basket PrintListOfProductsAvailableToSell(Basket basket = null)
        {
            foreach (var product in listOfProductsRegistered)
            {
                var quantityOfProductInStock = Stock.GetStockQuantityOfProduct(product);
                if (quantityOfProductInStock > 0)
                {
                    Console.WriteLine("\nProduto: {0}    |     Valor: {1}    |    Quantidade no estoque: {2}    |    ID do produto: {3}\n", product.Name,
                                    product.Price, quantityOfProductInStock, product.ID);
                }
            }

            // will return a basket if is showing products for client to add more items to an existing basket, else return null
            return basket;
        }

        public static Basket AskForWhichProductsCustomerWantsToBuy(Basket basket = null)
        {
            Console.WriteLine("\nFavor informar quantos produtos distintos gostaria de comprar.");
            var quantityOfDistinctProductsCustomerWantsToBuy = int.Parse(Console.ReadLine());
            Basket newBasket = basket ?? new Basket();

            for (int i = 0; i < quantityOfDistinctProductsCustomerWantsToBuy; i++)
            {
                Product product = null;
                while(product == null)
                {
                    Console.WriteLine("\nFavor informar o ID do produto numero {0} que deseja comprar: ", i + 1);
                    var productID = int.Parse(Console.ReadLine());
                    product = ProductsRegisterManager.GetProductRegisteredByID(productID);
                }
                Console.WriteLine("\nFavor informar a quantidade do produto {0} que deseja comprar: ", product.Name);
                var quantityOfProductCustomerWantsToBuy = int.Parse(Console.ReadLine());
                newBasket.AddOrUpdateItemToBasket(product, quantityOfProductCustomerWantsToBuy);
            }

            return newBasket;
        }

        public static void AskCustomerToCreateOrderOrBuyMore(Basket basket)
        {
            Console.WriteLine("\nDigite 1 para finalizar a compra, 2 para visualizar o cardapio novamente para adicionar novos itens ao carrinho ou 3 para cancelar a compra e visualizar o cardapio");            
            var customerOptionToCreateOrderOrBuyMoreItems = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (customerOptionToCreateOrderOrBuyMoreItems)
            {
                case 1:
                    var address = AskForCustomerAddress();
                    OrderRegister.CreateOrder(new Order(basket, address, orderID++));
                    break;
                case 2:
                    var basketToBeUpdatedWithMoreItems = PrintListOfProductsAvailableToSell(basket);
                    var basketUpdated = AskForWhichProductsCustomerWantsToBuy(basketToBeUpdatedWithMoreItems);
                    AskCustomerToCreateOrderOrBuyMore(basketUpdated);
                    break;
                case 3:
                    PrintListOfProductsAvailableToSell();
                    var newBasket = AskForWhichProductsCustomerWantsToBuy();
                    AskCustomerToCreateOrderOrBuyMore(newBasket);
                    break;
                default:
                    Console.WriteLine("\nOpcao invalida.");
                    AskCustomerToCreateOrderOrBuyMore(basket);
                    break;
            }

        }
    }
}
