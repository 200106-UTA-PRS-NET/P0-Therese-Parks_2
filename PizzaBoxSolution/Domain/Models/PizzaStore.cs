using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    /*
    [required] should exist at least 1 store
•	[required] should be able to view its completed orders(sales) --> covered by business logic 
•	
    [optional] should be able to view its sales --> FK to sale
•	[optional] should be able to view its inventory --> simple auto decrement for sale, retrieval of a number
•	[optional] should be able to view its users(customers) --> covered by Business Logic
*/

     /*  <summary>
      *  A PizzaStore object, having name, a collection of its customers, 
      *  and an overall 
       </summary>*/

       // DB table looks like this --> customerID | customerName | orderID | phoneNumber
    public class PizzaStore
    {

        //sales and inventory can be fields in the PizzaStore Table
        //Customers can have a reference to the Pizza Store. 
        //Customer account id can be foriegn key inside Pizza Store
        //Customers can have a reference to the Pizza Store. 
        //Customer account id can be foriegn key inside Pizza Store
        //zero will indicate a missing value for id

        //[--DB Table looks like--> pizzaStoreId | Name | Location | customerId | orderId ]

        //pizzaStoreId 
        public int Id { get; set; }
       // public string Id { get; set; }

        private string _name; //name

        //location
        //location --> customer can choose location(list of locations)
        private string _location;

        //customerID
        public int customerID { get; set; }
        //public string customerID { get; set; }

        //orderID
        public int orderID { get; set; }
        //public string orderID { get; set; }



        public PizzaStore(int Id, string name, string location, int customerID, int orderID)
        {
            this.Id = Id;
            this.Name = name;
            this.Location = location;
            this.customerID = customerID;
            this.orderID = orderID;
      
            Console.WriteLine("Pizza Store Constructor");

            Console.WriteLine(Id + " " + name + " " + location + " " + customerID + " " + orderID);

        }
        public PizzaStore(int Id, string name, string location)
        {
            this.Id = Id;
            this.Name = name;
            this.Location = location;
          
            Console.WriteLine("Pizza Store Constructor with Id, name, and location");

            Console.WriteLine(Id + " " + name + " " + location);

        }

        //public PizzaStore(string Id, string name, string location, string customerID, string orderID)
        //{
        //    this.Id = Id;
        //    this.Name = name;
        //    this.Location = location;
        //    this.customerID = customerID;
        //    this.orderID = orderID;
        //}

        // list of strings to be accessd by the calling object who wants to make a choice of location
        string[] locationChoices = { "Topeka", "Wamego", "Manhattan" };
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                // "value" is value passed to setter
                if(value.Length == 0)
                {
                    throw new ArgumentException("Please enter the name.", nameof(value));
                }
                _name = value;
            }
        }

        public string Location
        {
            get
            {
                return _location; 
            }
            set
            {
                // "value is value passed to setter
                if(value.Length == 0)
                {
                    throw new ArgumentException("Please enter the location.", nameof(value));    
                }
                _location = value; // customer will choose name and that choice will become the location
            }
        }
        // The Customers(customer accounts) of this PizzaStore
        // Depends on concrete "List to simplify serialization.
        // This list of customers is like a directory so it can be insured that a 
        // customer has account to see order history
        public List<Customer> CustomerAccounts { get; set; } = new List<Customer>();
        // The Completed Orders(Sales) of this PizzaStore
        // This list of orders is like a directory so PizzaStore can view it's sales; 
        // Pull up list of sales --> using BL and DB access to customize view
        public List<Order> Sales { get; set; } = new List<Order>();

    }
}
