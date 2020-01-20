using System;
using System.Collections.Generic;

namespace TPizzaBox.Client.Entities
{
    public partial class LoginTable
    {
        public string UserName { get; set; }
        public int? PassPin { get; set; }
    }
}
