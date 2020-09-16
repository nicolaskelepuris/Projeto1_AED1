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

        public static void PrintListOfProductsAvailableToSell()
        {
            foreach (var product in listOfProductsRegistered)
            {
                var quantityOfProductInStock = Stock.GetStockQuantityOfProduct(product);
                if (quantityOfProductInStock > 0)
                {
                    Console.WriteLine("\nProduto: {0}    |     Descricao: {1}    |     Valor: {2}    |    Quantidade no estoque: {3}    |    ID do produto: {4}\n",
                                    product.Name, product.Description, product.Price, quantityOfProductInStock, product.ID); ;
                }
            }
        }

        // Parameter basket is needed when customer already has a basket and wants to insert more products before confirming order
        public static Basket AskForWhichProductsCustomerWantsToBuy(Basket basket = null)
        {
            Console.WriteLine("\nFavor informar quantos produtos distintos gostaria de comprar.");
            var quantityOfDistinctProductsCustomerWantsToBuy = int.Parse(Console.ReadLine());

            // newBasket received param basket if not null
            Basket newBasket = basket ?? new Basket();

            for (int i = 0; i < quantityOfDistinctProductsCustomerWantsToBuy; i++)
            {
                Product product = null;

                // ask for product id until customer sends a valid id
                while(product == null)
                {
                    Console.WriteLine("\nFavor informar o ID do produto numero {0} que deseja comprar: ", i + 1);
                    var productID = int.Parse(Console.ReadLine());
                    product = ProductsRegisterManager.GetProductRegisteredByID(productID);
                }

                Console.WriteLine("\nFavor informar a quantidade do produto {0} que deseja comprar: ", product.Name);
                var quantityOfProductCustomerWantsToBuy = int.Parse(Console.ReadLine());

                // insert item into basket
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
                    // create order and finish application
                    var address = AskForCustomerAddress();
                    OrderRegister.CreateOrder(new Order(basket, address, orderID++));
                    break;
                case 2:
                    // send customer back to fill basket with an existing basket
                    PrintListOfProductsAvailableToSell();
                    var basketUpdated = AskForWhichProductsCustomerWantsToBuy(basket);
                    AskCustomerToCreateOrderOrBuyMore(basketUpdated);
                    break;
                case 3:
                    // send customer back to fill basket with an empty basket
                    PrintListOfProductsAvailableToSell();
                    var newBasket = AskForWhichProductsCustomerWantsToBuy();
                    AskCustomerToCreateOrderOrBuyMore(newBasket);
                    break;
                default:
                    // AskCustomerToCreateOrderOrBuyMore again
                    Console.WriteLine("\nOpcao invalida.");
                    AskCustomerToCreateOrderOrBuyMore(basket);
                    break;
            }

        }
    }
}
