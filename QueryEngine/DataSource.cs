using System;
using System.Collections.Generic;
using System.Text;

namespace QueryEngine
{
    public sealed class DataSource
    {
        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }
        public DataSource(List<User> users)
        {
            Users = users;
        }
    }

    public sealed class User
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public User(string email, string fullName, int age)
        {
            Email = email;
            FullName = fullName;
            Age = age;
        }
    }
    
    public sealed class Order
    {
        public string BuyerName { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public Order(string buyerName, string productName, float price)
        {
            BuyerName = buyerName;
            ProductName = productName;
            Price = price;
        }
    }
    public sealed class Data
    {
        public DataSource GenerateSomeData()
        {
            return new DataSource
                (
                    new List<User>
                    {
                        new User("adamlat2@poczta.pl", "Adam Małysz", 44),
                        new User("lukaszkowalski@gmail.com", "Łukasz Kowalski", 34),
                        new User("michalkichal@onet.pl", "Michał Kichała", 17)
                    }
                );
           
        }
    }
}
