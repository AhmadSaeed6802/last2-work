using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_part_2_v4_Bank_Management_system
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int accountNumber, string accountHolderName) : base(accountNumber, accountHolderName)
        {
        }
        // Implementation of CalculateInterest() method specific to checking account.
        public override decimal CalculateInterest()
        {
            // Calculate and return the interest for savings account.
            decimal interestRate = 0.03m;
            return balance * interestRate;
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
    }
}
