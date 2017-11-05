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
                Console.WriteLine("5. Print all Transactions");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        break;
                    case "1":
                        Console.WriteLine("Email Address");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("Account type: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{accountTypes[i]}");
                        }
                        var accountType = (TypeOfAccount)Enum.Parse(typeof(TypeOfAccount), Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(emailAddress, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, At: {account.AccountType}, Balance: {account.Balance:C}, CreatedDate:{account.CreatedDate}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number:");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Deposit:");
                            amount = Convert.ToDecimal(Console.ReadLine());
                            Bank.Deposit(accountNumber, amount);
                            Console.WriteLine("Deposit was successful");
                        }
                        catch( FormatException)
                        {
                            Console.WriteLine("Either the amount or account number is invlid");
                        }
                        catch(OverflowException)
                        {
                            Console.WriteLine("Either the amount or account number is beyond the range");
                        }
                        catch(ArgumentOutOfRangeException ax)
                        {
                            Console.WriteLine(ax.Message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Oops! try again");
                      
                        }
                        break;
                    case "3":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number:");
                            var accountnumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Amount to Withdraw:");
                            amount = Convert.ToDecimal(Console.ReadLine());
                            Bank.Withdraw(accountnumber, amount);
                            Console.WriteLine("Withdrawl was successful");
                        }
                        catch(ArgumentOutOfRangeException ax)
                        {
                            Console.WriteLine(ax.Message);
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        var anumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactions(anumber);
                        foreach(var tran in transactions)
                        {
                            Console.WriteLine($"ID:{tran.Transactionid}, Date:{tran.TransactionsDate}, Type:{tran.TypeOfTransaction}, Amount:{tran.Amount:C}, Description:{tran.Description}");
                        }
                    break;
                    default:
                        break;

                }
                if (choice == "0")
                    break;
            }



        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email address:");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAllAccounts(emailAddress);
            foreach (var item in accounts)
            {
                Console.WriteLine($"AN: {item.AccountNumber}, AT:{item.AccountType}, Balance:{item.Balance}, CreatedDate:{item.CreatedDate}");
            }

        }
    }
}
