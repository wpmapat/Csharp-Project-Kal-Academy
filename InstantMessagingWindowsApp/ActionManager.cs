using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingWindowsApp
{
    class ActionManager
    {
        DBManager dBManager;
       public ActionManager()
        {
            dBManager = new DBManager();
        }

        #region Methods

        //This method will call SendMessage method of DBManger class and will pass all the details for tblChat table so that we can save all conversation history between sender and Receiver.
        
        public void SendMessage(User sender, string PhNumber, string messageText)
    {
            dBManager.SendMessage(sender,PhNumber, messageText);
    }
        public List<Message> getMessages(string ph1, string ph2)
        {
            return dBManager.getMessages(ph1, ph2);
        }
        /// <summary>
        /// This method will create an account
        /// </summary>
        /// <param name="u1"></param>
        /// <returns></returns>
        public bool CreateAccount(User u1)
        {
           return dBManager.CreateAccount(u1);
            
        }
        /// <summary>
        /// This method will help user to sign in in his account by providing phone number and password. Since there is no database yet, i have hardcoded some of my code
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>. 
        public User LoginUser(string emailaddress,string password)
        {
            User u1=dBManager.GetUser(emailaddress,password);
            return u1;
        }
        public List<User> getConversationUsers(User LoggedInUser)
        {
            return dBManager.getConversationUsers(LoggedInUser);
        }
            //public void EditAcct(User u)
            //public void DeleteAcct(User u)
            #endregion
        }
}
