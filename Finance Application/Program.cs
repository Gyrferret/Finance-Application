using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using Linq = System.Linq;
// allows your to make reference aliases. 
namespace Finance_Application
{
    public class Program
    {
        private int months = 360;
        private float principal = 535000;
        private float r = 3.75f;
        private double constant;


        public static void Main(float[] args)
        {
            if (args.Length != 0)
            {
                // RunFinanceApplicationArguments(args[0],args[1],args[2])  
            }
            RunFinanceApplication();
        }

        static void RunFinanceApplicationArguments(int months, float principal, float r)
        {
            Processing Process = new Processing();
            PaymentInformation Information = new PaymentInformation();
            Cleanup CleanupRate = new Cleanup();
            float rate = CleanupRate.CleanupInterestRate(r);
            double constant = Process.DetermineConstant(months, principal, rate);
            double[,] Array = Information.MonthlyPayments(months, constant, principal, rate);
            InformationOutput(Array);
            Console.ReadLine();
        }

        static void RunFinanceApplication()
        {
            Processing Process = new Processing();
            Program Variables = new Program();
            PaymentInformation Information = new PaymentInformation();
            Cleanup CleanupRate = new Cleanup();
            float rate = CleanupRate.CleanupInterestRate(Variables.r);
            double constant = Process.DetermineConstant(Variables.months, Variables.principal, rate);
            double[,] Array = Information.MonthlyPayments(Variables.months, constant, Variables.principal, rate);
            InformationOutput(Array);
            Console.ReadLine();

        }

        static void InformationOutput(double[,] InformationArray)
        {
            for (int i = 0; i < (InformationArray.Length / 4); i++)
            {
                Console.WriteLine("{4}.) Total Due: {0:C2}, Paid to Interest: {1:C2}, Paid to Principal {2:C2}, End Balance: {3:C2}", InformationArray[i, 0], InformationArray[i, 1], InformationArray[i, 2], InformationArray[i, 3], (i + 1));
            }
        }
    }

    class DataOutput
    {
        public static System.Data.DataTable newDataTable(double[,] InformationArray)
        {
            System.Data.DataTable myTable = new System.Data.DataTable();

            myTable.Columns.Add("Month");
            myTable.Columns.Add("Paid to Interest");
            myTable.Columns.Add("Paid to Principal");
            myTable.Columns.Add("End Balance");

            for (int i = 0; i < (InformationArray.Length / 4); i++)
            {
                myTable.Rows.Add(InformationArray[i, 0], InformationArray[i, 1], InformationArray[i, 2], InformationArray[i, 3], (i + 1));
            }

            return myTable;
        }
    }


    class Cleanup
    {
        public float CleanupInterestRate(float rate)
        {
            return (((rate / 100) /12) + 1);
        }

    }

    class Processing
    {
        public double DetermineConstant(int months = 360, float principal = 535000, float r = 1.0395f)
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

        public double MaximumPrincipalAmount(double constant = 550, int months = 36, float r = 1.095f)
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
        public double[,] MonthlyPayments(int months, double constant, float principal, float r)
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
    
