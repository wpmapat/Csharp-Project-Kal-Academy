using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingWindowsApp
{/// <summary>
/// For now this class does nothing. It just returns user by taking harcoded values. Once DB is integrated this code will become more realistic
/// </summary>
    class DBManager
    {
        #region Methods
        public bool CreateAccount(User u1)
        {
            return true;
        }
        public void editAccount(User u1)
        {

        }
        public void deleteAccount(User u1)
        {

        }
        public void updateAccount(User u1)
        {

        }
        /// <summary>
        /// This method will check if this user exist in our database or no and will return user object
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User getUser(int phoneNumber, String password)
        {
            User u1 = new User("John Dow", 25805, "test@test.com", "abc123");
            return u1;
        }
        #endregion 
    }
}
