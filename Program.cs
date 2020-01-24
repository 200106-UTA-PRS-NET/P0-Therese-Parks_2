using PizzaOrder.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;


namespace PizzaOrder.Client
{
    class Program
    {

        static void Main(string[] args)
        {
            /*****************************************begin make sure user has account******************************************************/
            var thisUser = new Login();
            var thisPizza = new Pizza();
            var thisOrder = new Orders();
            var thisCustomer = new Customer();
            using (var context = new PIZZA_ORDER_DB2Context())
            {
                string createUser = " CREATE ";
                Console.WriteLine("Welcome TO Your PIZZA ORDER Portal! ");
                Console.WriteLine("Press ENTER to sign in, or type 'CREATE' to create a new login.");
                createUser = Console.ReadLine();
                if ((createUser.Length > 1) || (createUser == "CREATE"))
                {

                    // Ask user for values one at a time to create an account
                    Console.WriteLine("Please Enter Your First Name: ");
                    thisUser.LoginName = Console.ReadLine();
                    Console.WriteLine("Please Enter Your a Four-Digit Pass Code: ");
                    String val = Console.ReadLine();
                    thisUser.LoginPasscode = thisUser.LoginPasscode = Convert.ToInt32(val);

                    var newName = thisUser.LoginName;
                    var newPass = thisUser.LoginPasscode;

                    // String interpolation
                    var commandText = "INSERT Login (LOGIN_NAME, LOGIN_PASSCODE) VALUES (@LOGIN_NAME, @LOGIN_PASSCODE)";
                  
                    var name = new Microsoft.Data.SqlClient.SqlParameter("@LOGIN_NAME", newName);
                    var pass = new Microsoft.Data.SqlClient.SqlParameter("@LOGIN_PASSCODE", newPass);

                    context.Database.ExecuteSqlRaw(commandText, name, pass);
                    context.SaveChanges();
                    Console.WriteLine("ACCOUNT CREATED SUCCESSFULLY!.");

                }
                else
                {

                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                }
            }
            /*****************************************end make sure user has account******************************************************/


            using (var context = new PIZZA_ORDER_DB2Context())
            {

                /*****************************************begin  login******************************************************/
                Console.WriteLine("Please Enter your User Name: ");
                thisUser.LoginName = Console.ReadLine();

                //logic for if username matches db table
                Console.WriteLine("Please Enter your Pin");
                String val = Console.ReadLine();
                thisUser.LoginPasscode = Convert.ToInt32(val);

                //Select all from login table and search through them. 
                //If any of the names match the names entered

                //Allow the user to enter a passcode for that user name.
                //query for the Username entered
                if (context.Login.Any(e => e.LoginName == thisUser.LoginName))
                {
                    var name = context.Login.FirstOrDefault(e => e.LoginName == thisUser.LoginName);
                    // name.UserName = thisUser.UserName;

                    context.SaveChanges();
                    Console.WriteLine($"Hello, {thisUser.LoginName}, Welcome to the PIZZA ORDER PORTAL!");

                }
                else if (!context.Login.Any(e => e.LoginName == thisUser.LoginName))
                {
                    var name = context.Login.FirstOrDefault(e => e.LoginName == thisUser.LoginName);
                    // name.UserName = thisUser.UserName;
                    Console.WriteLine("The User Name is Incorrect. Please try again. Else if for Name");
                    context.SaveChanges();
                    return;
                }
                // logic here if pass code matcheds db table for username
                if (context.Login.Any(e => e.LoginPasscode == thisUser.LoginPasscode))
                {
                    var pass = context.Login.FirstOrDefault(e => e.LoginPasscode == thisUser.LoginPasscode);
                    //   pass.UserName = thisUser.PassPin;
                    //context.LoginTable.Find(pass);
                    //context.LoginTable.Find(name);
                    context.SaveChanges();
                    // Console.WriteLine($"Hello, {thisUser.UserName}, Welcome to TPizzaBox!");
                }
                else if (!context.Login.Any(e => e.LoginPasscode == thisUser.LoginPasscode))
                {
                    var pass = context.Login.FirstOrDefault(e => e.LoginPasscode == thisUser.LoginPasscode);
                    // name.UserName = thisUser.UserName;LoginPasscode
                    Console.WriteLine(" User Name or Pass Pin is Incorrect. Please try again. Else if for Pass");
                    context.SaveChanges();
                    return;
                }

                else
                {
                    Console.WriteLine("The User Name or Pass Pin is Incorrect. Please try again.");
                }

                /*****************************************end login******************************************************/

                /********************************begin checking for existing store***********************************/

                Console.WriteLine("Press Enter to view Pizza Stores.");

                while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                using (var db = new PIZZA_ORDER_DB2Context())
                {

                    foreach (var store in db.Store)
                    {
                        Console.WriteLine("{0} | {1} | {2}", store.StoreId, store.StoreName, store.Location);
                    }
                }
                /********************************end checking for existing store***********************************/

                /********************************begin choosing a store to order from***********************************/

                // After customer chooses a store, a customer account could be created for that store with the users credentials from LOGIN


                using (var db = new PIZZA_ORDER_DB2Context())
                {

                    var pizzaStoreToFind = new Store();
                    Console.WriteLine("Enter the ID of the Pizza Store you wish to order from:");
                    String val2 = Console.ReadLine();
                    int pizStoreID = (pizzaStoreToFind.StoreId = Convert.ToInt32(val2));

                    Console.WriteLine("You have selected the following location");
                    pizzaStoreToFind = db.Store.Find(pizStoreID);
                    Console.WriteLine("{0} | {1} | {2}", pizzaStoreToFind.StoreId, pizzaStoreToFind.StoreName, pizzaStoreToFind.Location);
                    Console.WriteLine("If you already have a customer account Type " + "YES" + ":");
                    Console.WriteLine("Otherwise press Enter to create one:");

                    String hasAccount = Console.ReadLine();

                    // var existingCustomerOrders = new Orders();

                    if ((hasAccount.Length > 1) || (hasAccount == "YES"))
                    {
                        var existingOrderToFind = new Orders();
                        Console.WriteLine("Please Enter Your Customer ID: ");
                        String val5 = Console.ReadLine();// match this entered customer Id's in Order table

                        int existingCusID = Convert.ToInt32(val5);
                        //existingOrderToFind.CusCustomerId = existingCusID;
                        thisCustomer.CustomerId = existingCusID;
                        var ord = new Orders();
                        Console.WriteLine($"Orders for customer with ID {existingCusID}: ");
                        Console.WriteLine(existingOrderToFind = db.Orders.Find(ord.CusCustomerId));

                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                        Console.WriteLine("These are your past orders:");

                        //-----------------same for pizza------------------//
                        //adds sums
                        var sumOfPizzasPerOrder = new Pizza();
                        Console.WriteLine("Please Enter Your Order ID to see the sum of your order ");
                        String val6 = Console.ReadLine();
                      
                        int sum = Convert.ToInt32(val6);
                        //existingOrderToFind.CusCustomerId = existingCusID;
                        sumOfPizzasPerOrder.Cost = sum;

                       // Console.WriteLine($"Orders for customer with ID {sum}: ");
                   //     Console.WriteLine(existingOrderToFind = db.Pizza.FromSqlRaw("Pizza.Cost"));

                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                        Console.WriteLine("These are your past orders:");
                        try
                            {
                                Console.WriteLine("PREVIOUS ORDERS: Order ID | customer ");
                                Console.WriteLine("{0} | {1} |", existingOrderToFind.OrderId, existingOrderToFind.CusCustomerId);
                              
                            }
                            catch (Exception e)
                            {
                                
                                Console.WriteLine("You have no previous orders.");
                                
                            }
                            //   Console.WriteLine("{0} | {1} | {2}", store.StoreId, store.StoreName, store.Location);
                        }

           
                    else
                    {
                        //------------------------------------begin creating new customer ------------------------------------------------------------------|
                     //   int newCustomerid = 20;// Change manually for now
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        // var thisCustomer = new Customer();
                        // Ask user for values one at a time to create an account
                        //Customer id
                     

                        //First Name
                        Console.WriteLine("Please Enter Your First Name: ");
                        thisCustomer.FirstName = Console.ReadLine();
                        //Last Name
                        Console.WriteLine("Please Enter Your Last Name: ");
                        thisCustomer.LastName = Console.ReadLine();
                        //Phone
                        Console.WriteLine("Please Enter Your Phone Number: ");
                        thisCustomer.PhoneNumber = Console.ReadLine();

                        // var id = thisCustomer.CustomerId;
                      //  var id = 8;
                        var firstName = thisCustomer.FirstName;
                        var lastName = thisCustomer.LastName;
                        var phone = thisCustomer.PhoneNumber;

                        // String interpolation
                        var commandText = "INSERT Customer ( FIRST_NAME, LAST_NAME,PHONE_NUMBER) VALUES (@FIRST_NAME, @LAST_NAME, @PHONE_NUMBER)";
                       // var cusId = new Microsoft.Data.SqlClient.SqlParameter("@CUSTOMER_ID", id);
                        var first = new Microsoft.Data.SqlClient.SqlParameter("@FIRST_NAME", firstName);
                        var lname = new Microsoft.Data.SqlClient.SqlParameter("@LAST_NAME", lastName);
                        var pnum = new Microsoft.Data.SqlClient.SqlParameter("@PHONE_NUMBER", phone);

                        context.Database.ExecuteSqlRaw(commandText, first, lname, pnum);
                        context.SaveChanges();
                     
                        Console.WriteLine("CUSTOMER ACCOUNT CREATED SUCCESSFULLY!.");


                        //search DB for the customer's new ID

                        // context.SaveChanges();
                        // var newcusID = new Customer();
                        // newcusID.FirstName = firstName;
                        // newcusID.LastName = lastName;

                        // newcusID = db.Customer.Find(newcusID.CustomerId);

                        //using (var c = new PIZZA_ORDER_DB2Context())
                        //{
                        //    var cusid = c.Orders
                        //                    .Find(
                        //        "Select customer_id from Customer where last_name=@last AND phone_number=@phn ",
                        //        new SqlParameter("@last", lastName),
                        //        new SqlParameter("@phn", phone));
                                           
                        //}

                        //Console.WriteLine("below is your new customer id: ");





                    }//end else
                     //*******************************auto-create order*************************************//
                    
                        var mypizza = new Pizza();
                    //Console.WriteLine("Enter the ID of the Pizza Store you wish to order from:");
                    //String val2 = Console.ReadLine();
                    //int pizStoreID = (pizzaStoreToFind.StoreId = Convert.ToInt32(val2));
                    int pizOrdID = pizStoreID;

                        Console.WriteLine("You have selected the following location");
                        pizzaStoreToFind = db.Store.Find(pizStoreID);
                        Console.WriteLine("{0} | {1} | {2}", pizzaStoreToFind.StoreId, pizzaStoreToFind.StoreName, pizzaStoreToFind.Location);

                        Console.WriteLine("Notice that your account has been added to the list.");
                        // Console.WriteLine("Enter the new ID that you see next to your name:");
                    
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                    using (var db4 = new PIZZA_ORDER_DB2Context())
                    {

                        foreach (var cus in db4.Customer)
                        {
                            Console.WriteLine("{0} | {1} ", cus.CustomerId, cus.LastName);
                        }
                    }
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                    Console.WriteLine("Enter the Customer Id provide to you:");
                    String val3 = Console.ReadLine();// match this entered customer Id's in Order table
                    int newCusID = Convert.ToInt32(val3);
                  
                    //  after the user presses enter, a new Order will be automatically created. 
                    //  var thisOrder = new Orders();
                    // int newOrderId = 20;// Change manually for now
                   // int cid = thisCustomer.CustomerId;
                  //  Ask user for values one at a time to create an account

                    // Order id

                   // thisOrder.OrderId = newOrderID;
                   // Store ID
                  //  Console.WriteLine("Please Enter Your First Name: ");
                    thisOrder.StoreStoreId = pizStoreID;
                    thisCustomer.CustomerId = newCusID;
                    
                    
                    //Customer ID
                    // thisOrder.CusCustomerId = 20;// Change Manually for now;


                    var o_id = thisOrder.OrderId;
                    var st_id = thisOrder.StoreStoreId;
                    //var cus_id = thisCustomer.CustomerId;

                    var cus_id = newCusID;


                    // String interpolation
                    var commandText2 = "INSERT Orders ( STORE_STORE_ID, CUS_CUSTOMER_ID)" +
                        " VALUES ( @STORE_STORE_ID, @CUS_CUSTOMER_ID)";
                  //  var ord_id = new Microsoft.Data.SqlClient.SqlParameter("@ORDER_ID", o_id);
                    var store_id = new Microsoft.Data.SqlClient.SqlParameter("@STORE_STORE_ID", st_id);
                    var cust_id = new Microsoft.Data.SqlClient.SqlParameter("@CUS_CUSTOMER_ID", cus_id);

                    context.Database.ExecuteSqlRaw(commandText2,store_id, cust_id);
                    context.SaveChanges();
                    Console.WriteLine("New Order has begun...");

                    /********************************end auto create order***********************************/

                    /********************************begin ordering pizza***********************************/

                    /**  Pizza can use order Id from the new order*/
                    Console.WriteLine("Press Enter to Make your order.");

                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    // after the user presses enter, a new Order will be automatically created. 
                    //var thisOrder = new Orders();
             
                    

                    //PIZZA_ID
                   // thisPizza.PizzaId = 20;//Manual for now
                    //ORDER_ORDER_ID
                 //s   thisPizza.OrderOrderId = orderIdForPizza;// Change Manually for now;
                    //CRUST_TYPE
                    Console.WriteLine("Please Type Your Choice of Crust Thickness.");
                    Console.WriteLine("THIN" + " " + "or" + " " + "THICK :");
                    String crustForPizza = Console.ReadLine();
                    thisPizza.CrustType = crustForPizza;
                    //PIZZA_SIZE
                    Console.WriteLine("Please Type the size of the Pizza:");
                    Console.WriteLine("SMALL" + " " + "MEDIUM" + " " + "or" + " " + "LARGE");
                    string enteredSize = Console.ReadLine();
                    thisPizza.PizzaSize = enteredSize;
                    double priceOfPizza;
                    switch (enteredSize)
                    {
                        case "SMALL":
                            //priceOfPizza = 5.00;
                            Console.WriteLine("A SMALL pizza of any kind is $5.00.");
                            priceOfPizza = 5.00;
                            thisPizza.Cost = priceOfPizza;
                            break;
                        case "MEDIUM":
                            // priceOfPizza = 7.00;
                            Console.WriteLine("A MEDIUM pizza of any kind is $7.00.");
                            priceOfPizza = 7.00;
                            thisPizza.Cost = priceOfPizza;
                            break;
                        case "LARGE":
                            // priceOfPizza = 9.00;
                            Console.WriteLine("A LARGE pizza of any kind is $9.00.");
                            priceOfPizza = 9.00;
                            thisPizza.Cost = priceOfPizza;
                            break;

                    }

              
                 

                    //PIZZA_TYPE
                    Console.WriteLine("Please enter the TYPE of the Pizza:");
                    Console.WriteLine("CALIFORNIA" + " " + "GREEK" + " " + "or" + " " + "CHEESE");
                    string entererdType = Console.ReadLine();
                    thisPizza.PizzaType = entererdType;

                    Console.WriteLine("Enter the Order Id provide to you:");
                    String val4 = Console.ReadLine();// match this entered customer Id's in Order table
                    int newOrderID = Convert.ToInt32(val4);
                    thisPizza.OrderOrderId = newOrderID;
                    // var pizzaID = thisPizza.PizzaId;
                    var orderID = thisPizza.OrderOrderId;
                    var crustT = thisPizza.CrustType;
                    var piz_size = thisPizza.PizzaSize;
                    var cost = thisPizza.Cost;
                    var piz_type = thisPizza.PizzaType;


                    // String interpolation
                    var commandTextPizza = "INSERT Pizza ( ORDER_ORDER_ID, CRUST_TYPE, PIZZA_SIZE, COST, PIZZA_TYPE)" +
                        " VALUES  (@ORDER_ORDER_ID, @CRUST_TYPE, @PIZZA_SIZE, @COST, @PIZZA_TYPE)";
                   // var pid = new Microsoft.Data.SqlClient.SqlParameter("@PIZZA_ID", pizzaID);
                    var orderid = new Microsoft.Data.SqlClient.SqlParameter("@ORDER_ORDER_ID", orderID);
                    var crst = new Microsoft.Data.SqlClient.SqlParameter("@CRUST_TYPE", crustT);
                    var psize = new Microsoft.Data.SqlClient.SqlParameter("@PIZZA_SIZE", piz_size);
                    var cst = new Microsoft.Data.SqlClient.SqlParameter("@COST", cost);
                    var ptype = new Microsoft.Data.SqlClient.SqlParameter("@PIZZA_TYPE", piz_type);
                    context.Database.ExecuteSqlRaw(commandTextPizza, orderid, crst, psize, cst, ptype);
                    context.SaveChanges();
                    Console.WriteLine("PIZZA ORDER ENTERED SUCCESSFULLY!.");
           
                    //----------------------------------------------begin order automatically showing pizzas-------------------------------------------------------//
                    // Show all pizzas with This orderID;
                    var pizzaInOrder = new Pizza();

                    pizzaInOrder.OrderOrderId = orderID;

                    Console.WriteLine("Notice that your order is in the Queue.");

                    foreach (var pizza in db.Pizza)

                    {
                        var name = context.Pizza.FirstOrDefault(e => e.OrderOrderId == orderID);
                        Console.WriteLine("{0} | {1} | {2}", pizza.OrderOrderId, pizza.PizzaType, pizza.Cost);
                  
                    }

                    Console.WriteLine("ORDER TOTAL is" + " " + "$" +  cost );

                   // var mypizza = new Pizza();
                   
                    var mycusid = orderID;

                 //   Console.WriteLine("pizzas in your order:");
                  //  Console.WriteLine(mypizza = db.Pizza.Find(mycusid));
                    //  Console.WriteLine("This is a view of your pizzas from this order.");
                    //Console.WriteLine("Would you like to add another pizza to this order? Type Y for yes or N for no.");
                   // String answer = Console.ReadLine();

                    //----------------------------------------begin giving customer the option to add another pizza-----------------------------------------//
                    //if (answer == "N")
                    //{
                    //    Console.WriteLine("This completes your order. Thank you!");
                    //}
                    //if (answer == "Y")
                    //{
                    //    Console.WriteLine("Begin Ordering next pizza!");

                    //}

                    Console.WriteLine("SIGN OUT TO END THIS SESSION.");
                    Console.WriteLine("By pressing Enter.");

                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                }





            }
        }
    }
}



