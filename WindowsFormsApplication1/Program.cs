using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class DataDisplay : Form 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public DataDisplay()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DataDisplay());
        }

        private void DataDisplay_Load (object sender, EventArgs e)
        {
            LoadPaymentsGridView();
        }

        private void LoadPaymentsGridView()
        {

        }

    }
}
