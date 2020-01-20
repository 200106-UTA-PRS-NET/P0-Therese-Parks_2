using System;
using System.Collections.Generic;

namespace TPizzaBox.Client.Entities
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int? PizzaStoreId { get; set; }
        public int? OrderId { get; set; }
        public string PizzaType { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaCrust { get; set; }
        public double? PizzaPrice { get; set; }

        public virtual PizzaStore PizzaStore { get; set; }
    }
}
