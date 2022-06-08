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
   
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

      
        public static string sProduct = "";
      


        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cart crt = new Cart();
            crt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Checkout chk = new Checkout();
            chk.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GET_product gproduct = new GET_product();
            gproduct.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Options_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label4.Text = "Welcome back " + Form1.sUsername;
            label8.Text = date.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Account_detail acdt = new Account_detail();
            acdt.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Popular_products pProducts = new Popular_products();
            pProducts.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Edit_username edUser = new Edit_username();
            edUser.Show();
        }

 
 
    }
}
