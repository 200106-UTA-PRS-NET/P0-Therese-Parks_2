using System;
using System.Collections.Generic;

namespace PizzaOrder.Domain
{
    public partial class Login
    {
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public int? LoginPasscode { get; set; }
    }
}
