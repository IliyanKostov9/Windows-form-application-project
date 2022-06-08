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
    public partial class Foods : Form
    {

        
        public Foods()
        {
            InitializeComponent();
        }

        Options opt = new Options();
        

        private void Foods_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label3.Text = "Welcome back " + Form1.sUsername;
            label4.Text = date.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Dark Chocolate Truffles";
            Add add = new Add();
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Sugar Free Chocolate Chip Biscuits";
            Add add = new Add();
            add.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Alpen No Sugar Added Muesli";
            Add add = new Add();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Flahavan Pinhead Irish Oatmeal";
            Add add = new Add();
            add.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Barry Tea Irish Breakfast Tea Bags - 80 count";
            Add add = new Add();
            add.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Ahmad Tea London Phone Tin - 25 Tea Bags";
            Add add = new Add();
            add.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Heinz Piccalilli - 10.9oz";
            Add add = new Add();
            add.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Colman Beef Casserole Mix";
            Add add = new Add();
            add.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Whishlist whish = new Whishlist();
            whish.Show();
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
