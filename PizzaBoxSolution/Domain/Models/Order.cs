using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
  /*
    [required] should be able to view its pizzas
•	[required] should be able to compute its cost
•	[required] should be able to limit its cost to no more than $250

•	[optional] should be able to limit its pizza count to no more than 100
*/

    public class Order
    {
        // DB table looks like | orderId | pizzaStoreId | customerId | pizzaId | pizzaName | Total "
        public int orderId { get; set; }
        public int pizzaStoreId { get; set; }
   
        public int customerId;
        public int pizzaId { get; set; }

        public string pizzaName { get; set; }

        private double _total; // needs to be a calculated number
        private const int maxTotal = 255; // maximum amount allowed per order

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                // "value" is value passed to setter
                if (value == 0 )
                {
                    throw new ArgumentException("Please enter the name.", nameof(value));
                }
                if (value >= maxTotal)
                {
                    throw new Exception("Order total cannot exceed $255.00");// let the user know if max value is exceeded
                      
                }
                _total = value;
                Console.WriteLine(_total);
            }
        }
        // Constructor
        public Order(int orderId, int pizzaStoreId, int customerId, int pizzaId, string pizzaName, double total)
        {
            this.orderId = orderId;
            this.pizzaStoreId = pizzaStoreId;
            this.customerId = customerId;
            this.pizzaId = pizzaId;
            this.pizzaName = pizzaName;
            // this._total = total;
            // "value" is value passed to setter
            if (total == 0)
            {
                throw new ArgumentException("Please enter total", nameof(total)); // this should be auto entered by BL & DB Logic
            }
            if (total >= maxTotal)
            {
                throw new Exception("Order total cannot exceed $255.00");// let the user know if max value is exceeded
                Console.WriteLine("Error! Order cannot exceed $255.00");
            }
            _total = total;
            Console.WriteLine(_total);
            Console.WriteLine("Order Constructor");

            Console.WriteLine(orderId + " " + pizzaStoreId + " " + customerId + " " + pizzaId + " " + pizzaName + " " + _total);
        }
       

    }
}
