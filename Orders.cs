using System;
using System.Collections.Generic;

namespace TPizzaBox.Client.Entities
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int? PizzaStoreId { get; set; }
        public int? CustomerId { get; set; }
        public double? Total { get; set; }

        public virtual PizzaStore PizzaStore { get; set; }
    }
}
