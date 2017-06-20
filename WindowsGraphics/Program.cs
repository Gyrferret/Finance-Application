using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsGraphics
{
    public class GraphicsProgram : Form
    {
        public GraphicsProgram()
        {
            this.Paint += new PaintEventHandler(PaintMethod);
        }

        private void PaintMethod(object sender, PaintEventArgs e)
        {
            Graphics Graphic = e.Graphics;
            Graphic.DrawString("Hi", new Font("Verdana", 20), new SolidBrush(Color.Aqua), 40, 40);
            Graphic.DrawRectangle(new Pen(Color.Pink, 3), 20, 20, 150, 100);
        }

        public void initialize()
        {
            Application.Run(new GraphicsProgram());
        }
    }
}
