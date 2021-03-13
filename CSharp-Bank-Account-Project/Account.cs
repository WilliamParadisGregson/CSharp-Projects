using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    public class Account
    {
        

        int AccountNumber;
        string OwnerName;
        double Balance;
        double MonthlyDepositAmount;

        public static double MonthlyFee = 4.0;
        public static double MonthlyInterestRate = 0.0025;
        public static double MinimumInitialBalance = 1000;
        public static double MinimumMonthDeposit = 50;



        public Account(string name, int num, double bal, double dep)
        {
            this.OwnerName = name;
            this.AccountNumber = num;
            this.Balance = bal;
            this.MonthlyDepositAmount = dep;

            return;
        }

        public double Deposit(double dep)
        {
            Balance = Balance + dep;
            return Balance;
        }

        public double Withdraw(double withd)
        {
            Balance = Balance - withd;
            return Balance;
        }
        public string getName()
        {
            return OwnerName;
        }
        public double getMonthlydeposit()
        {
            return MonthlyDepositAmount;
        }
        public int getAccnum()
        {
            return AccountNumber;
        }
        public double getBalance()
        {
            return Balance;
        }
    }
}
