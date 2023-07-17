using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_part_2_v4_Bank_Management_system
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            //create instance of bank class,saving
            Bank bank = new Bank();
            //create instance of saving account and checking account
            SavingAccount newsavingaccount = new SavingAccount(4890, "ali", 2.5m);
            CheckingAccount newcheckingaccount = new CheckingAccount(4891, "ali");
            //Add accounts to bank (list)
            bank.AddAccount(newsavingaccount);
            bank.AddAccount(newcheckingaccount);
            //Make a few transactions
            bank.DepositToAccount(4890, 10000);
            bank.DepositToAccount(4891, 3000);
            bank.WithdrawFromAccount(4890, 9000);
            bank.WithdrawFromAccount(4890, 1000);
            bank.WithdrawFromAccount(4891, 1000);

            // Display account information
            newsavingaccount.AccountInfo();
            newcheckingaccount.AccountInfo();
            Console.ReadKey();




            // Display messages to user to let him now whst's required to enter
            //get his responces and proced with them
            //Console.WriteLine("Enter Your name");
            //string userName = (Console.ReadLine());
            //Random random = new Random();
            //int accountNumber = random.Next(100000, 999999);
            //BankAccount YourAccount = new BankAccount(accountNumber, userName);

            //Console.WriteLine($"{userName}! Do you want to open bank apllication for user Enter '1',Enter '0' to close console(this window)");
            //int okOpen=int.Parse(Console.ReadLine());
            //while(okOpen==1)
            //{
            //    Console.WriteLine(" Want to proceed further  Enter '1',Enter '0' to close console");
            //    int openok = int.Parse(Console.ReadLine());
            //    bankApplicationForUser.ApplicationForUseropen(openok,YourAccount);
            //    Console.WriteLine("Do you have anything more to do Enter '1' ,Enter '0' to close console(this window)");
            //    okOpen=int.Parse(Console.ReadLine());

            //}
            //Console.WriteLine("Bank Application closed");
            //Console.ReadLine();








        }

    }
   
}
