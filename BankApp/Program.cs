using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("**************");
            Console.WriteLine("Welcome to my bank");
            while (true)
            {


                Console.WriteLine("Please choose an option below:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        break;
                    case "1":
                        Console.WriteLine("Email Address");
                        var EmailAddress = Console.ReadLine();
                        Console.WriteLine("Account type: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{accountTypes[i]}");
                        }
                        var accountType = (TypeOfAccount)Enum.Parse(typeof(TypeOfAccount), Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(EmailAddress, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, At: {account.AccountType}, Balance: {account.Balance:C}, CreatedDate:{account.CreatedDate}");
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":

                        emailAddress = Console.ReadLine();
                        var accounts=Bank.GetAllAccounts();
                        foreach(var item in accounts)
                        {
                            Console.WriteLine();
                        }
                        break;
                    default:
                        break;
                }
            }



        }
    }
}
