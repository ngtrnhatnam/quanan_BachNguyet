using System;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet.Components
{
    public partial class Widget : UserControl
    {

        public Widget()
        {
            InitializeComponent();
        }

        public void SetData(string id, string name, string price, bool availability)
        {
            lblName.Text = name;
            lblPrice.Text = price;
            lblID.Text = id;
            if (availability)
            {
                this.Enabled = true;
                lblTamHet.Visible = false;
            }
            else
            {
                this.Enabled = false;
                lblTamHet.Visible = true;
            }
        }

        private void Widget_MouseClick(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.Fixed3D;
            System.Threading.Thread.Sleep(20);
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
