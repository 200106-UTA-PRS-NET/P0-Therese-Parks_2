using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
 /*
    [required] should be able to view its order history
•	[required] should be able to only order from 1 location/24-hour period
•	[required] should be able to only order if an account exists

•	[optional] should be able to only order 1 time within a 2 hour period
*/ 
     
    // HAS-A-RELATIONSHIP 
    //--> One to many Pizza stores can have one to many Customers(customer accounts)
    //--> One Customer can have many Orders(Unique to each customer)
    //--> One Order can have many Pizza's

    //[ DB table looks like this --> CustomerID | orderID | name | phone]
    public class Customer
    {
        public int customerId { get; set; }
        public int orderId { get; set; }
        private string _name;
        private string _phone;

        //-------------------------Constructors------------------------------------//
        public Customer(int customerId, int orderId, string name, string phone)
        {
            this.customerId = customerId;
            this.orderId = orderId;
            this._name = name;
            this._phone = phone;

            Console.Write("Customer Constructor");
            Console.WriteLine(customerId + " " + orderId + " " + name + " " + phone);
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                // "value" is value passed to setter
                if (value.Length == 0)
                {
                    throw new ArgumentException("Please enter the name.", nameof(value));
                }
                _name = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                // "value" is value passed to setter
                if (value.Length == 0)
                {
                    throw new ArgumentException("Please enter a valid phone number.", nameof(value));
                }
                _phone = value;
            }
        }
    }
}
