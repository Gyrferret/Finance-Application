using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExperiments
{
    class WindowLauncher
    {
        public static void Main(string[] args)
        {

        }

    }

    public class WindowsForms : Form
    {
        public WindowsForms()
        {
            // method of the class needs to be the same name as the class itself.
            Button Button1 = new Button();
            Button1.Size = new Size(40, 40);
            Button1.Location = new Point(30, 30);
            Button1.Text = "Click Me";
            this.Controls.Add(Button1);
            Button1.Click += new EventHandler(Button1_Click);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
        [STAThread]
        public void Windows()
        {
            Application.EnableVisualStyles();
            Application.Run(new WindowsForms());
        }
    }
}
