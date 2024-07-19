using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SqlDbData
    {
        static string connectionString
           = "Data Source = LAPTOP-H6PN7ITJ\\SQLEXPRESS; Initial Catalog = RestaurantMenu; Integrated Security = True;";
            //= "Server=tcp:20.255.250.107,1433;Database=RestaurantMenu;User Id=sa;Password=MyAzureAccount00";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void Connect()
        {
            sqlConnection.Open();
        }

        public static List<Menu> GetUsers()
        {
            string selectStatement = "SELECT Description, Meal, Price, Drinks FROM RestoInfo";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Menu> RestoInfo = new List<Menu>();

            while (reader.Read())
            {
                string Description = reader["Description"].ToString();
                string Meal = reader["Meal"].ToString();
                string Price = reader["Price"].ToString();
                string Drinks = reader["Drinks"].ToString();

                Menu readUser = new Menu() { 

                Description = reader["Description"].ToString(),
                        Meal = reader["Meal"].ToString(),
                        Price = reader["Price"].ToString(),
                        Drinks = reader["Drinks"].ToString()
                    };
                RestoInfo.Add(readUser);
            }

            sqlConnection.Close();

            return RestoInfo;
        }
        public static int AddUser(string Description, string Meal, string Price, string Drinks)
        {
            int success;

            string insertStatement = "INSERT INTO RestoInfo VALUES (@Description, @Meal, @Price, @Drinks )";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Description", Description);
            insertCommand.Parameters.AddWithValue("@Meal", Meal);
            insertCommand.Parameters.AddWithValue("@Price", Price);
            insertCommand.Parameters.AddWithValue("@Drinks", Drinks);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
        public static int UpdateUser(string Description, string Meal, string Price, string Drinks)
        {
            int success;

            string updateStatement = "UPDATE RestoInfo SET Meal = @Meal, Price = @Price, Drinks = @Drinks WHERE Description = @Description";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Description", Description);
            updateCommand.Parameters.AddWithValue("@Meal", Meal);
            updateCommand.Parameters.AddWithValue("@Price", Price);
            updateCommand.Parameters.AddWithValue("@Drinks", Drinks);

            sqlConnection.Open();

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
        public static int DeleteUser(string Description, string Meal, string Price, string Drinks)
        {
            int success;

            string deleteStatement = "DELETE FROM RestoInfo WHERE Description = @Description AND Meal = @Meal AND Price = @Price AND Drinks = @Drinks";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@Description", Description);
            deleteCommand.Parameters.AddWithValue("@Meal", Meal);
            deleteCommand.Parameters.AddWithValue("@Price", Price);
            deleteCommand.Parameters.AddWithValue("@Drinks", Drinks);

            sqlConnection.Open();

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}
