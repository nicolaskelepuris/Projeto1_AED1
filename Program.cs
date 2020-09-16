using System;

namespace Projeto1AED1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsRegisterManager.RegisterAllProducts();
            CustomerService.PrintListOfProductsAvailableToSell();
            var basket = CustomerService.AskForWhichProductsCustomerWantsToBuy();
            CustomerService.AskCustomerToCreateOrderOrBuyMore(basket);
        }
    }
}
