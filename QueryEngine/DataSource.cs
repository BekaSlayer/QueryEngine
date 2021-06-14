using System;
using System.Collections.Generic;
using System.Text;

namespace QueryEngine
{
    public sealed class DataSource
    {
        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }
    }

    public sealed class User
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; } 
    }
    
    public sealed class Order
    {
        public string BuyerName { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
    }
}
