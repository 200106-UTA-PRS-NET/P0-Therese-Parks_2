using System;
using System.Collections.Generic;

namespace TPizzaBox.Client.Entities
{
    public partial class PizzaStore
    {
        public PizzaStore()
        {
            Customer = new HashSet<Customer>();
            Orders = new HashSet<Orders>();
            Pizza = new HashSet<Pizza>();
        }

        public int PizzaStoreId { get; set; }
        public string PizzaStoreName { get; set; }
        public string PizzaStoreLocation { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
