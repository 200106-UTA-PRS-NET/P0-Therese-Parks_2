using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TPizzaBox.Client.Entities;

namespace TPizzaBox.TPizzaBox.Client
{
    // TODO: IF THERE'S TIME, GO BACK AND MAKE SEPARATE MODEL CLASSES WITH METHODS FOR EACH OF THE ENTITIES
    // THEN CALL THEM FROM THIS CLASS
    class Program
    {
        public static void Main(string[] args)
        {


       
        var thisUser = new LoginTable();
            using (var context = new TPizzaBoxContext())
            {
               
                /*****************************************LOGIN******************************************************/
                Console.WriteLine("Please Enter your User Name: ");
                thisUser.UserName = Console.ReadLine();

                //logic her if username matches db table
                Console.WriteLine("Please Enter your Pin");
                String val = Console.ReadLine();
                thisUser.PassPin = Convert.ToInt32(val);

                //Select all from login table and search through them. 
                //If any of the names match the names entered
                //Allow the user to enter a passcode for that user name.

                //query for the Username entered
                if (context.LoginTable.Any(e => e.UserName == thisUser.UserName))
                {
                    var name = context.LoginTable.FirstOrDefault(e => e.UserName == thisUser.UserName);
                   // name.UserName = thisUser.UserName;
                   
                    context.SaveChanges();
                    Console.WriteLine($"Hello, {thisUser.UserName}, Welcome to TPizzaBox!");
                }
                else if(!context.LoginTable.Any(e => e.UserName == thisUser.UserName))
                {
                        var name = context.LoginTable.FirstOrDefault(e => e.UserName == thisUser.UserName);
                    // name.UserName = thisUser.UserName;
                    Console.WriteLine("The User Name is Incorrect. Please try again. Else if for Name");
                    context.SaveChanges();
                }
                   // logic here if pass code matcheds db table for username
                if (context.LoginTable.Any(e => e.PassPin == thisUser.PassPin))
                {
                    var pass = context.LoginTable.FirstOrDefault(e => e.PassPin == thisUser.PassPin);
                 //   pass.UserName = thisUser.PassPin;
                    //context.LoginTable.Find(pass);
                    //context.LoginTable.Find(name);
                    context.SaveChanges();
                   // Console.WriteLine($"Hello, {thisUser.UserName}, Welcome to TPizzaBox!");
                }
                else if (!context.LoginTable.Any(e => e.PassPin == thisUser.PassPin))
                {
                    var pass = context.LoginTable.FirstOrDefault(e => e.PassPin == thisUser.PassPin);
                    // name.UserName = thisUser.UserName;
                    Console.WriteLine(" User Name or Pass Pin is Incorrect. Please try again. Else if for Pass");
                    context.SaveChanges();
                }

                else
                {
                    Console.WriteLine("The User Name or Pass Pin is Incorrect. Please try again.");
                }


                /*****************************************LOGIN******************************************************/

                //<**REQUIREMENT** 1> --There should exist at least one store. --DONE
                // By Querying the DB, You can see that there is at least one
                // Pizza Store in Existence, Or Add New Pizza Store

                //   Creating a new pizzaStore and saving it to the database
                Console.WriteLine("Press Enter to view Pizza Stores.");
          
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                using (var db = new TPizzaBoxContext())
                {
                  

                    foreach (var pizzastore in db.PizzaStore)
                    {
                        Console.WriteLine("{0} | {1}", pizzastore.PizzaStoreId, pizzastore.PizzaStoreName, pizzastore.PizzaStoreLocation);
                    }
                }

                //Console.WriteLine("Press Enter to add a new Pizza Store.");

                //while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                ////Block for adding pizza store --NEEDS WORK FOR CONSOLE ENTRY
                //using (var db = new TPizzaBoxContext())
                //{

                //    var newPizzaStore = new PizzaStore();
                //    newPizzaStore.PizzaStoreId = 7;
                //    newPizzaStore.PizzaStoreName = "Danny's Pizza";
                //    newPizzaStore.PizzaStoreLocation = "Denver";
                //    db.PizzaStore.Add(newPizzaStore);
                //    var count = db.SaveChanges();
                //    Console.WriteLine("{0} records saved to database", count);

                //    Console.WriteLine("all pizzastore's in the database:");
                //    foreach (var pizzastore in db.PizzaStore)
                //    {
                //        Console.WriteLine("{0} | {1}", pizzastore.PizzaStoreId, pizzastore.PizzaStoreName, pizzastore.PizzaStoreLocation);
                //    }
                //}// end using block for new pizzaStore


                Console.WriteLine("Press Enter to find a Pizza Store.");

                while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                using (var db = new TPizzaBoxContext())
                {

                    var pizzaStoreToFind = new PizzaStore();
                    Console.WriteLine("Enter ID of the Pizza Store you want to find:");
                    String val2 = Console.ReadLine();
                    int pizStoreID = (pizzaStoreToFind.PizzaStoreId = Convert.ToInt32(val2));
                    Console.WriteLine($"Pizza Store with ID {pizStoreID}: ");
                    pizzaStoreToFind = db.PizzaStore.Find(pizStoreID);
                    Console.WriteLine("{0} | {1}", pizzaStoreToFind.PizzaStoreId, pizzaStoreToFind.PizzaStoreName);
                }//End find store by ID

                //< **REQUIREMENT 2** >--Store should be able to view it's completed orders --DONE!
                // SQL Form -->  Select * From Orders Where PizzaStoreID = 1; 

                //Finds PizzaStore's Orders By PizzaStoreID 

                   Console.WriteLine("Press Enter to find a Pizza Store's Orders.");

                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                    using (var db = new TPizzaBoxContext())
                    {

                        var pizzaStoreOfOrder = new Orders();
                        Console.WriteLine("Enter ID of the Pizza Store you want to find:");
                        String val2 = Console.ReadLine(); //ID entered
                        pizzaStoreOfOrder.PizzaStoreId = Convert.ToInt32(val2); 
                    //int pizStoreID = pizzaStoreOfOrder.PizzaStoreId = Convert.ToInt32(val2));
                       
              //      Console.WriteLine($"Pizza Store with ID {pizStoreID}: ");
                        pizzaStoreOfOrder = db.Orders.Find(pizzaStoreOfOrder.PizzaStoreId);

                    Console.WriteLine("Below is shown:\n Order ID | Order Total ");

                    foreach (var p in db.Orders)
                    {
                        Console.WriteLine("{0} | {1}", p.OrderId, p.Total);
                    }

                }//End find store by ID

                Console.WriteLine("Press Enter to find Pizzas in Your Order.");

                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                //<**REQUIREMENT 3 **>--Order should be able to view its pizza's
                // SQL Form --> Select * From Pizza where OrderID = 1;
                var pizzasInOrder = new Pizza();

                using (var db = new TPizzaBoxContext())
                {

                    //var pizzasInOrder = new Pizza();
                    Console.WriteLine("Please Enter Your Order ID: ");
                    String val2 = Console.ReadLine(); //ID entered
                    pizzasInOrder.OrderId = Convert.ToInt32(val2);



                    //if (db.Orders.Any(e => e.OrderId == pizzasInOrder.OrderId))
                    //{
                       // var pizza = context.Pizza.FirstOrDefault(e => e.OrderId == pizzasInOrder.OrderId);
               
                        db.SaveChanges();
                        foreach (var o in db.Pizza)
                            Console.WriteLine("{0} | {1} | {2} | {3} | {4}", o.PizzaId, o.PizzaType, o.PizzaSize, o.PizzaPrice, o.PizzaCrust);
                 //   }
                    ///////////////////////
                    if (context.LoginTable.Any(e => e.UserName == thisUser.UserName))
                    {
                        var name = context.LoginTable.FirstOrDefault(e => e.UserName == thisUser.UserName);
                        // name.UserName = thisUser.UserName;

                        context.SaveChanges();
                        Console.WriteLine($"Hello, {thisUser.UserName}, Welcome to TPizzaBox!");
                    }
                    else if (!context.LoginTable.Any(e => e.UserName == thisUser.UserName))
                    {
                        var name = context.LoginTable.FirstOrDefault(e => e.UserName == thisUser.UserName);
                        // name.UserName = thisUser.UserName;
                        Console.WriteLine("The User Name is Incorrect. Please try again. Else if for Name");
                        context.SaveChanges();
                    }
                }//End find store by ID

                //using (var db = new TPizzaBoxContext())
                //{
                //    var orders = db.ExecuteQuery<Customer>(@"SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM   dbo.Customers WHERE  City = {0}", "London");

                //    foreach (Customer c in customers)
                //        Console.WriteLine(c.ContactName);
                //}
            }
          }



            }//end main
           
            }
        
    


