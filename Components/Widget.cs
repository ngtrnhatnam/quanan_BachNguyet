//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet.Components
{
    public partial class Widget : UserControl
    {
        public Widget()
        {
            InitializeComponent();
        }

        public void SetData(string name, string price, bool availability)
        {
            lblName.Text = name;
            lblPrice.Text = price;
            if (availability)
            {
                this.Enabled = true;
            }
            else
            {
                this.Enabled = false;
            }
        }

        private void Widget_MouseHover(object sender, System.EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Widget_MouseLeave(object sender, System.EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }
    }
}
