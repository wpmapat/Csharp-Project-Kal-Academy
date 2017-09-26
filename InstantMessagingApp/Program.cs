using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User("Max Hui", 25805, "test@test.com","abc123");
            ActionManager ac1 = new ActionManager();
            bool val=ac1.CreateAccount(u1);


            if (val==false)
            {
                Console.WriteLine("It has failed to create an account.");
                return;
            }
                       
            //Console.WriteLine($" Name:{account.Name},$ Date:{account.CreatedDate},$ ActNo:{account.AccountNumber},$ PhNo:{user1.PhoneNo},$ed:{user1.EmailAddress}");


            /*var account2 = new Account();
            account2.Name = "Max Hui";
            account2.CreatedDate = DateTime.Now;
            Console.WriteLine($" Name:{account2.Name},$ Date:{account2.CreatedDate},$ ActNo:{account2.AccountNumber}");*/

            //public void toNavigateToLoginPage()
            {

            }


        }
    }
}
