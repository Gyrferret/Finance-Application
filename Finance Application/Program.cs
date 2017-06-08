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
            PaymentInformation Information = new PaymentInformation();
            double Constant = Process.DetermineConstant(36, 250000, 1.0395f);
            double[,] Array = Information.MonthlyPayments(36, Constant, 250000, 1.0395f);
            InformationOutput(Array);
            Console.ReadLine();
        }

        static void InformationOutput (double[,] InformationArray)
        {
            for (int i = 0; i < (InformationArray.Length / 4) ; i++)
            {
                Console.WriteLine("Total Due: {0}, Paid to Interest: {1}, Paid to Principal {2}, End Balance: {3}", InformationArray[i, 0], InformationArray[i, 1], InformationArray[i, 2], InformationArray[i, 3]);
            }
        }
    }
    class Processing
    {
        public double DetermineConstant(int months = 36, float principal = 250000, float r = 1.0395f)
        {
            // used to determine the constant monthly payment given a principal, constant months of payment, and constant rate.
            double BaseValue = 1;
            for (int i = 1; i < months; i++)
            {
                BaseValue += Math.Pow(r, i);
            }
            double n = (principal * Math.Pow(r, months)) / BaseValue;
            return n;
        }

        public double MaximumPrincipalAmount (double constant= 550, int months = 36 , float r = 1.095f)
        {
            // used to determine the maximum principal allowed given a constant monthly payment, constant months of payment, and constant rate. 
            double BaseValue = constant;
            for (int i = 0; i < months; i++)
            {
                BaseValue += constant * Math.Pow(r, i);
            }
            double p = (BaseValue / Math.Pow(r, months));
            return p;
        }
    }

    class PaymentInformation
    {
        public double[,] MonthlyPayments (int months, double constant, float principal, float r )
        {
            double RunningTotal = principal; // to initialize the beginning total as the principal.
            double AccuredInterest;
            double InterestPaid;
            double PrincipalPaid;
            double[,] PaymentArry = new double[months, 4];
            int a = 0;
            for (int i = 1; i < months; i++)
            {
                AccuredInterest = (RunningTotal * r);
                InterestPaid = AccuredInterest - RunningTotal;
                PrincipalPaid = constant - InterestPaid;
                RunningTotal = AccuredInterest - constant;
                PaymentArry[a, 0] = AccuredInterest;
                PaymentArry[a, 1] = InterestPaid;
                PaymentArry[a, 2] = PrincipalPaid;
                PaymentArry[a, 3] = RunningTotal;
                a++;
            }
            return PaymentArry;
            }
        }
    
}
