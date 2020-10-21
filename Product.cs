using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1AED1
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }

        // Create product with optional parameter ExpireDate
        public Product(int productId, string productName, decimal productPrice, string productDescription, int quantityOfProductsInStock, DateTime? productExpireDate = null)
        {
            ID = productId;
            Name = productName;
            Price = productPrice;
            Description = productDescription;
            ExpireDate = productExpireDate == null ? default(DateTime) : (DateTime)productExpireDate;

            // Add this product to stock
            Stock.AddOrUpdateStockOfProduct(this, quantityOfProductsInStock);
        }

        // Update product properties, parameter need to be null to not update respective property
        public void UpdateProduct(int? productId = null, string productName = null, float? productPrice = null,
                                string productDescription = null, DateTime? productExpireDate = null)
        {
            // Update product property if parameter is not null
            ID = productId == null ? ID : (int)productId;
            Name = productName == null ? Name : productName;
            Price = productPrice == null ? Price : (decimal)productPrice;
            Description = productDescription == null ? Description : productDescription; ;
            ExpireDate = productExpireDate == null ? ExpireDate : (DateTime)productExpireDate;
        }
    }
}
