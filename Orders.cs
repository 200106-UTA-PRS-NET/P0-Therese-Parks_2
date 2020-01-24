using System;
using System.Collections.Generic;

namespace PizzaOrder.Domain
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int? StoreStoreId { get; set; }
        public int? CusCustomerId { get; set; }

        public virtual Customer CusCustomer { get; set; }
        public virtual Store StoreStore { get; set; }
    }
}
