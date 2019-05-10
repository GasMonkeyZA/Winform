using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peanuts
{
    class LoginClass
    {
        public int UserID          { get; set; }
        public string Name         { get; set; }
        public string LastName     { get; set; }
        public string Contact      { get; set; }
        public string Address      { get; set; }
        public string Email        { get; set; }
        public string Username     { get; set; }
        public string Password     { get; set; }

        static string myconnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public bool Insert(LoginClass lc)
        {
            bool isSuccess = true;

            SqlConnection conn = new SqlConnection(myconnString);

            try
            {
                string sql = "INSERT INTO Users(FirstName, LastName, Contact, Address, Email, Username, Password)VALUES(@FirstName, @LastName, @Contact, @Address, @Email, @Username, @Password)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("FirstName", lc.Name);
                cmd.Parameters.AddWithValue("LastName", lc.LastName);
                cmd.Parameters.AddWithValue("Contact", lc.Contact);
                cmd.Parameters.AddWithValue("Address", lc.Address);
                cmd.Parameters.AddWithValue("Email", lc.Email);
                cmd.Parameters.AddWithValue("Username", lc.Username);
                cmd.Parameters.AddWithValue("Password", lc.Password);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
