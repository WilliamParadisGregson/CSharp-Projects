using System;
using System.Collections.Generic;

namespace lab4
{
    class Bank 
    { 
        public static void Main(string[] args)
        {
            int con = 1;
            List<Account> accounts = new List<Account>();
            Console.Write("Enter the number of months to deposit: ");
            int months = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            while (con == 1)
            {
                try
                {
                    Console.Write("Enter Custumer Name: ");
                    string cName=Console.ReadLine();
                    if (string.IsNullOrEmpty(cName))
                    {
                        con = 0;
                        break;
                    }
                    
                    Console.Write("Enter " + cName +  "'s Initial Deposit Amount (Minimum $1,000.00) ");
                    double iDeposit = double.Parse(Console.ReadLine());
                    while (iDeposit < Account.MinimumInitialBalance)
                    {
                        Console.Write(cName + "'s Initial Deposit Amount is too low. Please enter a Initial Deposit Amount over $1,000.00: ");
                        iDeposit = double.Parse(Console.ReadLine());
                    }

                    Console.Write("Enter " + cName + "'s Monthly Deposit Amount (Minimum $50.00) ");
                    double mDeposit = double.Parse(Console.ReadLine());
                    while (mDeposit < Account.MinimumMonthDeposit)
                    {
                        Console.Write(cName + "'s Monthly Deposit Amount is too low. Please enter a Monthly Deposit Amount over $50.00: ");
                        mDeposit = double.Parse(Console.ReadLine());
                    }

                    Random rand = new Random();
                    int accNum = rand.Next(90000, 99999);

                    accounts.Add(new Account(cName, accNum, iDeposit, mDeposit));
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.Write("Please enter a Integer!\n");
                }

            };


            Console.WriteLine("\n");
            foreach (var account in accounts)
            {
                for (int i = 0; i < months; i++) 
                { 
                    account.Withdraw(Account.MonthlyFee); // deducting the monthly fee
                    account.Deposit(Account.MonthlyInterestRate * account.getBalance()); // depositing the monthly interest rate
                    account.Deposit(account.getMonthlydeposit()); // desposit the accounts monthly deposit amount
                } 
                
                Console.WriteLine("After "+ months + " months, " + account.getName() +  "'s account (#" + account.getAccnum() + "), has a balance of: $" + account.getBalance());
            }

        }
    }

    

}
