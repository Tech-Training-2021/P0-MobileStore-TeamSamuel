﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class AuthenticateLogin
    {
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        static List<Product.oMumbai> LHistory = JsonConvert.DeserializeObject<List<Product.oMumbai>>(File.ReadAllText(@"History.json"));

        //Username
        public static void AuthenticateUsernamePassword()
        {
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();



            //Password


            Console.WriteLine("\nEnter Password: (After Entering Password press 'Enter')");
            string password = null;

            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)    // this loop breaks when user presses enter
                    break;
                password += key.KeyChar;   //KeyChar is a property that stores the character pressed from the Keyboard
                Console.CursorVisible = false;  //hides the cursor while typing
            }
            Console.CursorVisible = true;
            Check(userName, password);

        }


        //Authentication of username and password
        public static void Check(string userName, string password)
        {
            //Read data from json
            // static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
            List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));


            //Exception Handling
            bool val = false;
            try
            {
                foreach (var o in LCustomer)
                {
                    if (o.Username == userName && o.Password == password)
                    {
                        val = true;
                        break;
                    }
                }
                if (val == false)
                    throw new LoginException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Home.Login();
            }

            if (userName == "Admin" && password == "Admin")
            {
                Console.WriteLine("\n<----- Menu ----->\n");
                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                int choice = int.Parse(Console.ReadLine());

                //Exception
                try
                {
                    while (choice != 7)
                    {
                        switch (choice)
                        {
                            case 1:
                                //search customer
                                Console.Write("Enter Customer's User Name: ");
                                string sUserName = Console.ReadLine();
                                Console.Write("Enter Customer's Location: ");
                                string slocation = Console.ReadLine();
                                AllFun.Search_Customer(sUserName, slocation);
                                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                                choice = int.Parse(Console.ReadLine());
                                break;

                            case 2:
                                //view all customers
                                foreach (var o in LCustomer)
                                {
                                    if (o.Username.ToString() != "Admin" && o.Password.ToString() != "Admin")
                                    {
                                        Console.WriteLine($"Id : {o.Id}\tUser Name : {o.Username.ToString()}\tLocation : {o.Location.ToString()}\tDob : {o.Dob.ToShortDateString()}\n");
                                    }
                                }
                                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                                choice = int.Parse(Console.ReadLine());
                                break;

                            case 3:
                                //add product into json
                                Console.Write("Enter Mobile Company: ");
                                string c_name = Console.ReadLine();
                                Console.Write("Enter Mobile Name: ");
                                string m_name = Console.ReadLine();
                                Console.Write("Enter RAM: ");
                                string ram = Console.ReadLine();
                                int i;
                                bool success = int.TryParse(ram, out i);
                                if (!success)
                                {
                                    Console.WriteLine("Please enter integer value");
                                    Console.Write("Enter RAM: ");
                                    ram = Console.ReadLine();
                                    success = int.TryParse(ram, out i);
                                }
                                Console.Write("Enter ROM: ");
                                string rom = Console.ReadLine();
                                int j;
                                bool r_success = int.TryParse(rom, out j);
                                if (!r_success)
                                {
                                    Console.WriteLine("Please enter integer value");
                                    Console.Write("Enter ROM: ");
                                    rom = Console.ReadLine();
                                    r_success = int.TryParse(rom, out j);
                                }

                                Console.Write("Enter color: ");
                                string color = Console.ReadLine();
                                Console.Write("Enter store: ");
                                string store = Console.ReadLine();
                                Console.Write("Enter Price: ");
                                string price = Console.ReadLine();
                                int k;
                                bool p_success = int.TryParse(price, out k);
                                if (!success)
                                {
                                    Console.WriteLine("Please enter integer value");
                                    Console.Write("Enter Price: ");
                                    price = Console.ReadLine();
                                    p_success = int.TryParse(price, out k);
                                }
                                AllFun.Add_Products(c_name, m_name, i, j, color, store, k);
                                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                                choice = int.Parse(Console.ReadLine());
                                break;
                            case 4:
                                //iterate list to display all products
                                foreach (var o in LProduct)
                                {
                                    Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColors : {o.Color}\tStore Location : {o.Store}\tPrice : {o.Price}\n");
                                }
                                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                                choice = int.Parse(Console.ReadLine());
                                break;
                            case 5:
                                foreach (var o in LHistory)
                                {
                                    Console.WriteLine($"Customer Name : {o.Cust}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColor : {o.Color}\tStore : {o.Store}\tPrice : {o.Price}\n");
                                }
                                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                                choice = int.Parse(Console.ReadLine());
                                break;
                            case 6:
                                Console.Write("Enter the store Location to see it's product history ");
                                string storeLocation = Console.ReadLine();
                                AllFun.SearchStoreHistory(storeLocation);
                                Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : View particular store Order History\nClick 7 : Exit");
                                choice = int.Parse(Console.ReadLine());
                                break;
                            case 7:
                                Console.WriteLine("Please click either 1 2 3 4 5 6 7 ");
                                break;
                            default:
                                throw new LoginException(choice);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (val == true)
            {
                AllFun.User(userName, password);
            }
        }
    }
}
