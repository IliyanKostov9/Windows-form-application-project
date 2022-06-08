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
    public partial class Clothes : Form
    {
        public Clothes()
        {
            InitializeComponent();
        }

        Options opt = new Options();

        private void Clothes_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label3.Text = "Welcome back " + Form1.sUsername;
            label4.Text = date.ToString();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Options.sProduct = "Wrangler Riggs 3W501 Men Twill Workwear Shirt";
            Add add = new Add();
            add.Show();
        }


        private void button6_Click_1(object sender, EventArgs e)
        {
            Options.sProduct = "LIBERTY Women Duck Bib Overalls";
            Add add = new Add();
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Dickies Men 1939 Relaxed-Fit Carpenter Jeans";
            Add add = new Add();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Dickies Women Relaxed Fit Stretch Twill Capri - FR603";
            Add add = new Add();
            add.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Rothco Vintage M-65 Field Jacket - Olive";
            Add add = new Add();
            add.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Polar King Women Glacier Fleece Jacket";
            Add add = new Add();
            add.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Dutch Harbor Gear HD225 Long Coat";
            Add add = new Add();
            add.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Options.sProduct = "OccuNomix LUX-TJR Class 3 High-Vis Breathable Rain Jacket";
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
    }
}
