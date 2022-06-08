using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_shop_
{
    public partial class Flag : Form
    {
        public Flag()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Options.sProduct = "American Banner Flagpole Kit";
            Add add = new Add();
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Options.sProduct = "8-Foot Outrigger Wall Mount Series ECOS Flagpole";
            Add add = new Add();
            add.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Ireland 12in x 18in Flag";
            Add add = new Add();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Set of 50 State Flags - 12x18 inch";
            Add add = new Add();
            add.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Canada Flag 3ft x 5ft Printed Polyester";
            Add add = new Add();
            add.Show();
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Checkered 12 x 18 inch Flag on Wooden Stick";
            Add add = new Add();
            add.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Whishlist whish = new Whishlist();
            whish.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cart crt = new Cart();
            crt.Show();
        }

        private void Flag_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label3.Text = "Welcome back " + Form1.sUsername;
            label4.Text = date.ToString();
        }
    }
}
