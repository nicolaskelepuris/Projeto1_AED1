using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    public class Address
    {
        public int ID { get; set; }
        public string Street { get; private set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string CustomerName { get; set; }
        public Address(int id, string street, string number, string city, string customerName)
        {
            ID = id;
            Street = street;
            Number = number;
            City = city;
            CustomerName = customerName;
        }
    }
}
