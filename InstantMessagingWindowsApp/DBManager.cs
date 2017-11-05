using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InstantMessagingWindowsApp
{/// <summary>
/// For now this class does nothing. Once DB is integrated this code will become more realistic
/// </summary>
    class DBManager
    {
        private string connectionstring =
        @"Data Source=Madhura-Laptop\SQLEXPRESS;Initial Catalog=InstantMessagingDB;Integrated Security=SSPI";
        #region Methods
        public bool CreateAccount(User u1)
        {
            //string queryString = "Insert into dbo.tblUser (Name, CreatedDate, PhNumber, EmailAddress, Password) values ('" + 
            //    u1.Name + "','" + u1.CreatedDate + "','" + u1.PhoneNo + "','" + u1.EmailAddress + "','" + u1.Password +"')";

            string queryString = string.Format("Insert into dbo.tbluser (Name, CreatedDate, PhNumber, EmailAddress, Password) values ('{0}','{1}', '{2}', '{3}','{4}')",
                u1.Name,
                u1.CreatedDate.ToShortDateString(),
                u1.PhoneNo,
                u1.EmailAddress,
                u1.Password);


            using (SqlConnection connection = new SqlConnection(
               connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }
        public void EditAccount(User u1)
        {

        }
        public void DeleteAccount(User u1)
        {

        }
        public void UpdateAccount(User u1)
        {

        }
        /// <summary>
        /// This method will check if this user exist in our database or no and will return user object
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string emailaddress, String password)
        {
            User u1=null;
            string queryString = string.Format("Select * from tblUser Where EmailAddress='{0}' and Pwd ='{1}'",
                emailaddress,
                password);


            using (SqlConnection connection = new SqlConnection(
               connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                while(reader.Read())
                {
                    u1 = new User(reader[1].ToString(),reader[3].ToString(),reader[4].ToString(),reader[5].ToString());
                    u1.AccountNumber = reader.GetInt32(0);
                    break;
                }
                reader.Close();
            }

            return u1;
        }
        #endregion 
    }
}
