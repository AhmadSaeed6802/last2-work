using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2_part_2_v4_Bank_Management_system
{
    public class SavingAccount : BankAccount
    {
        // Implementation of CalculateInterest() method specific to saving account.
        public override decimal CalculateInterest()
        {
            // Calculate and return the interest for savings account.
            decimal interestRate = 0.06m;
            return balance * interestRate;
        }
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
    }
}
