using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Processing Process = new Processing();
            Console.WriteLine(Process.MaximumPrincipalAmount(550,12,1.095f));
            Console.ReadLine();
        }
    }
    class Processing
    {
        public double DetermineConstant(int months = 36, float principal = 250000, float r = 1.0395f)
        {
            double BaseValue = 1;
            for (int i = 1; i < months; i++)
            {
                BaseValue += Math.Pow(r, i);
            }
            double n = (principal * Math.Pow(r, months)) / BaseValue;
            Console.WriteLine(n);
            MonthlyPayments(n, months, principal, r);
            return n;
        }

        public void MonthlyPayments(double Constant, int months, float principal, float r)
        {
            double RunningTotal = principal;
            double AccumulatedInterest;
            double PrincipalPaid;
            double InterestPaid;
            for (int i = 0; i < months; i++)
            {
                AccumulatedInterest = (RunningTotal * r);
                InterestPaid = (AccumulatedInterest - RunningTotal);
                PrincipalPaid = Constant - InterestPaid;
                Console.WriteLine("Beginning Balance: {0}, Interest Accrued: {1}, Paid to Principal: {2}, Paid to Interest {3}", AccumulatedInterest, InterestPaid, PrincipalPaid, InterestPaid);
                RunningTotal = (AccumulatedInterest - Constant);
            }
        }

        public double MaximumPrincipalAmount (double constant= 550, int months = 36 , float r = 1.095f)
        {
            double BaseValue = constant;
            for (int i = 0; i < months; i++)
            {
                BaseValue += constant * Math.Pow(r, i);
            }
            double p = (BaseValue / Math.Pow(r, months));
            return p;
        }
    }
}
