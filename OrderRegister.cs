using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projeto1AED1
{
    static class OrderRegister
    {
        static List<Order> listOfOrdersRegistered = new List<Order>();

        public static void CreateOrder(Order order)
        {
            listOfOrdersRegistered.Add(order);
        }

        public static Order GetOrderByID(int id)
        {
            return listOfOrdersRegistered.Where(x => x.ID == id).First();
        }
    }
}
