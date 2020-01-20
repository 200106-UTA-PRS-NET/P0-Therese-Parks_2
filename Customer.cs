using System;
using System.Collections.Generic;

namespace TPizzaBox.Client.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public int PizzaStoreId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Phone { get; set; }

        public virtual PizzaStore PizzaStore { get; set; }
    }
}
