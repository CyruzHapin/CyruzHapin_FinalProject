using System;
using System.Collections.Generic;
using Model;
using BusinessLayer;
using DataLayer;
using System.Data.SqlClient;

namespace RestaurantMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            //SqlDbData.Connect();

            bool active = true;
            while (active)
            {
                Console.WriteLine("Restaurant Menu Management");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a new menu item");
                Console.WriteLine("2. Delete a menu item");
                Console.WriteLine("3. View all menu items");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter the number:");
                string number = Console.ReadLine();

                if (number == "1")
                {
                    Console.WriteLine("Enter Description:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Enter Meal:");
                    string meal = Console.ReadLine();

                    Console.WriteLine("Enter Price:");
                    string price = Console.ReadLine();

                    Console.WriteLine("Enter Drinks:");
                    string drinks = Console.ReadLine();

                    SqlDbData.AddUser(description, meal, price, drinks);
                    Console.WriteLine("Menu item added successfully!");
                }
                else if (number == "2")
                {
                    Console.WriteLine("Enter Description of the item to delete:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Enter Meal of the item to delete:");
                    string meal = Console.ReadLine();

                    Console.WriteLine("Enter Price of the item to delete:");
                    string price = Console.ReadLine();

                    Console.WriteLine("Enter Drinks of the item to delete:");
                    string drinks = Console.ReadLine();

                    SqlDbData.DeleteUser(description, meal, price, drinks);
                    Console.WriteLine("Menu item deleted successfully!");
                }
                else if (number == "3")
                {
                    Console.WriteLine("Current menu items:");
                    GetUsers();
                }
                else if (number == "4")
                {
                    active = false;
                }
                else
                {
                    Console.WriteLine("ERROR: Invalid selection. Please try again.");
                }
            }
        }

        public static void GetUsers()
        {
            List<Menu> infoFromDB = SqlDbData.GetUsers();

            foreach (var item in infoFromDB)
            {
                Console.WriteLine("Description: " + item.Description);
                Console.WriteLine("Meal: " + item.Meal);
                Console.WriteLine("Price: " + item.Price);
                Console.WriteLine("Drinks: " + item.Drinks);
                Console.WriteLine();
            }
        }
    }
}