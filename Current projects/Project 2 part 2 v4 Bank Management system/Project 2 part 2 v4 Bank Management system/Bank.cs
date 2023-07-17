using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_part_2_v4_Bank_Management_system
{
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
}
