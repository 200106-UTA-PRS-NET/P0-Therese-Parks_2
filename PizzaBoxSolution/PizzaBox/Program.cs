using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Domain.Models;
//using Storing.Repositories;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //note; I could use var varname = object;
            // --------------test code---------Pizza Object-----------------
            Pizza testPizz = new Pizza();
            Console.WriteLine(testPizz.PizzaPriceForSize("Large"));  //Pass :) , show price for large pizza

            // --------------test code ------- PizzaStore Object------------
            // Constructor 1
            PizzaStore ps = new PizzaStore(111, "Popps Pizza", "MaryVille", 222, 333); //Pass :)
            // Constructor 2
            PizzaStore ps2 = new PizzaStore(111, "Popps Pizza", "MaryVille"); //Pass :)

            // --------------test code ------- Order Object---------------
            // Exception gets thrown when total value exceeds 255.00
            Order testOrder = new Order(111, 222, 333, 444, "California", 240.00); //Pass :) throws exception for price exceeding 250.00

            // --------------test code ------- Order Object--------------
            Customer cus = new Customer(111, 222, "Robert Brown", "999-999-9999"); //Pass :) 
        }
    }
}

