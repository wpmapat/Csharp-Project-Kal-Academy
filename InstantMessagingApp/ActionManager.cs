using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingApp
{
    class ActionManager
    {
        DBManager dBManager;
       public ActionManager()
        {
            dBManager = new DBManager();
        }

        #region Methods
        public void SendMessage(User sender, Account a1, string messageText)
    {       

    }
        /// <summary>
        /// This method will create an account
        /// </summary>
        /// <param name="u1"></param>
        /// <returns></returns>
        public bool CreateAccount(User u1)
        {
            dBManager.CreateAccount(u1);
            return true;
            
        }
        /// <summary>
        /// This method will help user to sign in in his account by providing phone number and password. Since there is no database yet, i have hardcoded some of my code
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>. 
        public User LoginUser(int phoneNumber,string password)
        {
            User u1=dBManager.getUser(phoneNumber,password);
            return u1;
        }
        //public void EditAcct(User u)
        //public void DeleteAcct(User u)
#endregion
    }
}
