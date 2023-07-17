using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_part_2_v4_Bank_Management_system
{
    public abstract class BankAccount
    {
        // initializing and declaring attributes--
        private int AccountNo;
        private string AccountHolderName;
        private decimal Balance;
        // public methods for accessing and modifying these properties to uphold encapsulation.
        public int AccountNumber
        {
            get { return AccountNo; }
            set { AccountNo = value; }
        }

        public string accountHolderName
        {
            get { return AccountHolderName; }
            set { AccountHolderName = value; }
        }

        public decimal balance
        {
            get { return Balance; }
            set { Balance = value; }
        }
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
        // Abstract method to calculate interest. Each subclass will provide its own implementation.
        public abstract decimal CalculateInterest();
        // Account information method-----------------------------
        public void AccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNo}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Balance: {Balance}");
        }
    }
}
