using System;

namespace Domain.Models
{
    /*
    [required] should be able to have a crust
•	[required] should be able to have a size
•	[required] should be able to compute its cost

•	[optional] should be able to have at least 2 default toppings, including cheese and sauce
•	[optional] should be able to limit its toppings to no more than 5
*/

        //DB table looks like this--> [ pizzaID | orderId | type | size | crust | price] 
    public class Pizza

    {
        public int pizzaId { get; set; }
        public int orderId { get; set; } //name

        private string _pizzaType;
        // list of strings to be accessd by the calling object who wants to make a choice of pizza types
        string[] pizzaTypes = { "Cheese", "California", "Greek", "Mexican" };

        private string _pizzaSize;
        // list of strings to be accessd by the calling object who wants to make a choice of pizza types
        string[] pizzaSizes = { "Small", "Medium", "Large" };

        public string pizzaCrust { get; set; } //name

        private float _pizzaPrice; // if price is small price = 7.00, if...

        //----------------------------------Constructors-----------------------------------------------//
        public Pizza()
        {
            Console.WriteLine("No arg Pizza Constructor");
        }
        public Pizza(int pizzaId, int orderId, string pizzaType, string pizzaSize, string pizzaCrust, float pizzaPrice)
        {
            this.pizzaId = pizzaId;
            this.orderId = orderId;
            this._pizzaType = pizzaType;
            this.PizzaSize = pizzaSize;
            this.pizzaCrust = pizzaCrust;
            this._pizzaPrice = pizzaPrice;

            Console.WriteLine("Pizza Constructor");
            Console.WriteLine(pizzaId + " " + orderId + " " + pizzaType + " " +
                pizzaSize + " " + pizzaCrust + " " + pizzaPrice);

        }

      

        //----------------------------------Properties-----------------------------------------------//

        public string PizzaType
        {
            get
            {
                return _pizzaType;
            }
            set
            {
                // "value" is value passed to setter
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must choose pizza type.", nameof(value));
                }
                _pizzaType = value;
            }
        }

        public string PizzaSize
        {
            get
            {
                return _pizzaSize;
            }
            set
            {
                // "value" is value passed to setter
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must choose pizza size.", nameof(value));
                }
                _pizzaSize = value;
            }
        }

       
        public float PizzaPrice
        {
            get
            {
                return _pizzaPrice;
            }
            set
            {
                _pizzaPrice = value;
            }
        }

        //--------------------------------------Methods--------------------------------------------------------//
        //  take input size as pizza size and return price
     
         public double PizzaPriceForSize(string size)
        {

            // "value" is value passed to setter
                if (size.Length == 0)
                {
                    throw new ArgumentException("Must choose pizza size.", nameof(size));
                }
                if (size.Contains("Small"))
                {
                    _pizzaPrice = 7.00f;
                }
                if (size.Contains("Medium"))
                {
                    _pizzaPrice = 12.00f;
                }
                if (size.Contains("Large"))
                {
                    _pizzaPrice = 15.00f;
                }

            return PizzaPrice;
            }
        }
    }

