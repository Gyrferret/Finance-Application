using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Application
{
    class Program
    {
        private int months = 36;
        private float principal = 250000;
        private float r = 3.95f;
        private double constant;

        static void Main(string[] args)
        {
            WindowsForms WindowTest = new WindowsForms();
            WindowTest.Windows();
            // RunFinanceApplication();
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
                Console.WriteLine("Total Due: {0:C2}, Paid to Interest: {1:C2}, Paid to Principal {2:C2}, End Balance: {3:C2}", InformationArray[i, 0], InformationArray[i, 1], InformationArray[i, 2], InformationArray[i, 3]);
            }
        }
    }

    class Cleanup
    {
        public float CleanupInterestRate(float rate)
        {
            return (rate / 100) + 1;
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

    class WindowsForms : Form
    {
        public Button Button1;
        public void Buttons ()
        {
            Button1.Size = new Size(40, 40);
            Button1.Location = new Point(30, 30);
            Button1.Text = "Click Me";
            this.Controls.Add(Button1);
            Button1.Click += new EventHandler(Button1_Click);

        }

        private void Button1_Click (object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        public void Windows()
        {
            Application.EnableVisualStyles();
            Application.Run(new WindowsForms());
        }
    }
}
    
