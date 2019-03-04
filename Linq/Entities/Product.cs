using System;
namespace Linq.Entities
{
    public class Product
    {

        //DEFINED THE VARIABLES
        public double Price { get; set; }
        public string Name { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
