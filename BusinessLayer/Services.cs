using System.Collections.Generic;
using Model;
using DataLayer;

namespace BusinessLayer
{
    public class Services
    {
        DataServices dataServices = new DataServices();

        public List<Menu> GetMenus()
        {
            return SqlDbData.GetUsers();
        }
        public List<Menu> GetMenusByMealNum(string mealNum)
        {
            List<Menu> found = new List<Menu>();
            foreach (Menu menu in dataServices.rmenu)
            {
                if (menu.Meal == mealNum)
                {
                    found.Add(menu);
                }
            }
            return found;
        }

        public int CreateUser(string Description, string Meal, string Price, string Drinks)
        {
            return SqlDbData.AddUser(Description, Meal, Price, Drinks);
        }

        public int UpdateUser(string Description, string Meal, string Price, string Drinks)
        {
            return SqlDbData.UpdateUser(Description, Meal, Price, Drinks);
        }

        public int DeleteUser(string Description, string Meal, string Price, string Drinks)
        {
            return SqlDbData.DeleteUser(Description, Meal, Price, Drinks);
        }


    }



}

