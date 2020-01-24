using System;
using System.Collections.Generic;

namespace PizzaOrder.Domain
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int? OrderOrderId { get; set; }
        public string CrustType { get; set; }
        public string PizzaSize { get; set; }
        public double? Cost { get; set; }
        public string PizzaType { get; set; }
    }
}
