using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InstantMessagingWindowsApp
{/// <summary>
/// The methods in this class talks with the database directly.
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
        public void SendMessage(User u1,string toUserPhNo, string Messagetext)
        {
            User u2 = this.GetIdFromUser(toUserPhNo);

            string queryString = string.Format("Insert into dbo.tblChat (MessageTime,FromUserId,ToUserId,MessageText) values ('{0}','{1}','{2}','{3}')",
                DateTime.Now,
                u1.AccountNumber,
                u2.AccountNumber,
                Messagetext);
                

            using (SqlConnection connection = new SqlConnection(
               connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
                                   
        }
        //helper method
        private User GetIdFromUser(string phno)
        {
            User u1 = null;
            string queryString = string.Format("Select * from tblUser Where PhNumber='{0}'", phno);

            using (SqlConnection connection = new SqlConnection(
               connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    u1 = new User(reader[1].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                    u1.AccountNumber = reader.GetInt32(0);
                    break;
                }
                reader.Close();
            }
            return u1;
        }
        public List<Message> getMessages(string Phno1, string Phno2)
        {
            List<Message> messages = new List<Message>();
            User user2, user1 = null;
            user1 = this.GetIdFromUser(Phno1);
            user2 = this.GetIdFromUser(Phno2);


            string queryString = String.Format("Select * from tblChat Where (FromUserId={0} AND ToUserId={1}) OR (FromUserId={1} AND ToUserId={0})", user1.AccountNumber, user2.AccountNumber);
            using (SqlConnection connection = new SqlConnection(
               connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Message m = new Message();
                    DateTime dt = reader.GetDateTime(1);
                    int messageFromId = reader.GetInt32(2);
                    int messageToId = reader.GetInt32(3);
                    string messageText = reader.GetString(4);
                    string messageFromPhNo, messageToPhNo;
                    if (messageFromId == user1.AccountNumber)
                    {
                        messageFromPhNo = user1.PhoneNo;
                        messageToPhNo = user2.PhoneNo;
                    }
                    else
                    {
                        messageFromPhNo = user2.PhoneNo;
                        messageToPhNo = user1.PhoneNo;
                    }
                    m.FromPhoneno = messageFromPhNo;
                    m.ToPhoneno = messageToPhNo;
                    m.MessageText = messageText;
                    m.Messagetime = dt;
                    messages.Add(m);
                 }
                reader.Close();
            }
            return messages;
        }
        public List<User> getConversationUsers(User LoggedInUser)
        {
            List<User> Users = new List<User>();
            User u1 = null;
            string queryString = String.Format("Select * from tblUser where Id IN((select Distinct  ToUserId from tblChat where FromUserId = {0}) Union (Select Distinct  FromUserId from tblChat where ToUserId = {0}))", LoggedInUser.AccountNumber);
            using (SqlConnection connection = new SqlConnection(
               connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    u1 = new User(reader[1].ToString(),reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                    u1.AccountNumber = reader.GetInt32(0);
                    Users.Add(u1);
                }
                reader.Close();
            }
            return Users;
        }

        #endregion
    }
}
