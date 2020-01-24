using System;
using System.Collections.Generic;

namespace PizzaOrder.Domain
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
