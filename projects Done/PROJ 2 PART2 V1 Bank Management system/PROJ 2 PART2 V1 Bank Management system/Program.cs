using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_2_PART2_V1_Bank_Management_system
{

    // Base Class BankAccount--------------------------------------------------------------------------------------------
    public class BankAccount
    {
        // initializing and declaring attributes--
        public int AccountNo;
        public string AccountHolderName;
        public decimal Balance;
        // Constructors---
        public BankAccount(int accountNumber, string accountHolderName)
        {
            AccountNo = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = 0;
        }
        // deposit method-----------------------------------------
        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Your current balance is {Balance}");
        }
        // Withdraw method----------------------------------------
        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Not Enough Balance");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Succesfully with drawn Rs{amount}/- now your current balance os {Balance}");
            }
        }
        // Account information method-----------------------------
        public void AccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNo}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Balance: {Balance}");
        }
    }// BankAccount class end------------------------------------------------------------------------------------------------------------------------------------

    //Subclass of base class BankAccount class --------------------------------------------------------------------------------------------------------------------
    public class SavingAccount : BankAccount
    {
        public decimal InterestRate { get; set; } ////aditional attributes
                                                  //Construct
        public SavingAccount(int accountNumber, string accountHolderName, decimal interestRate) : base(accountNumber, accountHolderName)
        {
            InterestRate = interestRate;
        }
        // override Deposit method to add interest rate 
        public override void Deposit(decimal amount)
        {
            decimal interest = amount * (InterestRate / 100);
            Balance += amount + interest;
            Console.WriteLine($"deposited: {amount} , interest: {interest} , current balance: {Balance}");
        }
    }//Saving account class END------------------------------------------------------------------------------------------------------------------

    //Checking Acount Class start-----------------------------------------------------------------------------------------------------------
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int accountNumber, string accountHolderName) : base(accountNumber, accountHolderName)
        {
        }
        public override void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn: {amount} current Balance: {Balance} ");
            }
            else
            {
                Console.WriteLine("NOT enough funds availible ");
            }
        }
    } // Checking acount class END-----------------------------------------------------------------------------------------------------

    // Bank Class Start-----------------------------------------------------------------------------------------------------------------------------------
    public class Bank
    {      // declare a list of type BankAccount
        public List<BankAccount> bankaccountsList { get; set; }
        //constructor
        public Bank()
        {
            bankaccountsList = new List<BankAccount>();
        }
        // Add account method()---------------------------
        public void AddAccount(BankAccount account)
        {
            bankaccountsList.Add(account);
            Console.WriteLine($"{account.AccountHolderName} with account number {account.AccountNo} has been added to bank accounts list");
        }
        // DepositToAccount() method---------------------------
        public void DepositToAccount(int accountnumber, decimal amount)
        {
            BankAccount yourAccount = findAccount(accountnumber);
            if (yourAccount != null)
            {
                yourAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine($"account not found with account number {accountnumber} ");
            }
        }
        //'WithdrawFromAccount() method---------------------------------------------
        public void WithdrawFromAccount(int accountnumber, decimal amount)
        {
            BankAccount yourAccount = findAccount(accountnumber);
            if (yourAccount != null)
            {
                yourAccount.Withdraw(amount);
            }
            else
            {
                Console.WriteLine($"account not found with account number {accountnumber} ");
            }


        }
        private BankAccount findAccount(int accountnumber)
        {
            foreach (BankAccount account in bankaccountsList)
            {
                if (account.AccountNo == accountnumber)
                {
                    return account;
                }

            }
            return null;
        }
    }
    // UI user intration --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //public  static class bankApplicationForUser
    //{
    //   //bool open;
    //    public static void ApplicationForUseropen(int open,BankAccount YourAccount)
    //    {
    //        if (open == 1)
    //        {
    //            Console.WriteLine("OPENED! Bank Application");
    //            Char UserWant;  // Userwant vaiable is used for two purpose 
    //            Console.WriteLine("Do you have your bank account or NOT,Enter 'Y' for YES OR 'N' for NO ");
    //            UserWant = Char.Parse(Console.ReadLine());
    //            if (UserWant == 'Y' || UserWant == 'y')
    //            {    
    //            //Already have account
    //                Console.WriteLine("Enter your Name");

    //                Console.WriteLine("Account___Information:");
    //                YourAccount.AccountInfo();
    //                Console.WriteLine("Do you want to withdraw or deposit money");
    //                Console.WriteLine("Enter 'W' to withdraw or 'D' to Deposit");
    //                char userChoice = Char.Parse(Console.ReadLine());
    //                if (userChoice == 'W' || userChoice == 'w')
    //                {
    //                //Withdraw
    //                    Console.WriteLine("Enter the amount you want to Withdraw");
    //                    int amount = int.Parse(Console.ReadLine());
    //                    YourAccount.Withdraw(amount);
    //                }
    //                else if (userChoice == 'D' || userChoice == 'd')
    //                {
    //                //Deposit
    //                    Console.WriteLine("Enter the amount you want to deposit");
    //                    int amount = int.Parse(Console.ReadLine());
    //                    YourAccount.Deposit(amount);
    //                }
    //            }
    //            else if (UserWant == 'N' || UserWant == 'n')
    //            {      
    //            // Create new account
    //                Console.WriteLine("Welcome dear do you want to open a bank account enter 'Y' for YES OR 'N' for NO ");
    //                UserWant = Char.Parse(Console.ReadLine());
    //                if (UserWant == 'Y' || UserWant == 'y')
    //                {
    //                    Console.WriteLine("Enter your Name");
    //                    string userName = (Console.ReadLine());
    //                    Random random = new Random();
    //                    int accountNumber = random.Next(100000, 999999);
    //                    BankAccount NewAccount = new BankAccount(accountNumber, userName);
    //                    Console.WriteLine("Congratulations! your new account sucessfully creatd.");
    //                    Console.WriteLine("Account___Information:");
    //                    NewAccount.AccountInfo();
    //                    Console.WriteLine("PRESS Enter to login ");
    //                    Console.ReadKey();
    //                    Console.WriteLine("Logged In!");
    //                    Console.WriteLine("Do you want to withdraw or deposit money");
    //                    Console.WriteLine("Enter 'W' to withdraw or 'D' to Deposit");
    //                    char userChoice = Char.Parse(Console.ReadLine());
    //                    if (userChoice == 'W' || userChoice == 'w')
    //                    {        
    //                    // Withdraw
    //                        Console.WriteLine("Enter the amount you want to Withdraw");
    //                        int amount = int.Parse(Console.ReadLine());
    //                        NewAccount.Withdraw(amount);
    //                    }
    //                    else if (userChoice == 'D' || userChoice == 'd')
    //                    {      
    //                    //Deposit
    //                        Console.WriteLine("Enter the amount you want to deposit");
    //                        int amount = int.Parse(Console.ReadLine());
    //                        NewAccount.Deposit(amount);
    //                    }

    //                }

    //            }
    //            else if (UserWant == 'N' || UserWant == 'n')
    //            {
    //                Console.WriteLine("Ok NO ISSUE YOU MAY CREAT LATER ,WHEN EVER YOU WANT");
    //                open = 0;
    //            }
    //        }
    //        else if(open==0)
    //        {
    //            Console.WriteLine("Bank Application closed");
    //        }
    //    }
    //}

    // Main  progrme class --------------------------------------------------------------------------------------------------------------
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
