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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1 frm = new Form1();
            DateTime date = DateTime.Now;
            label3.Text = "Welcome back " + Form1.sUsername;
            label4.Text = date.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cart crt = new Cart();
            crt.Show();
        }

        private void homeKitchenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void giftsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Whishlist wh = new Whishlist();
            wh.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Foods fd = new Foods();
            fd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clothes cl = new Clothes();
            cl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LED ld = new LED();
            ld.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Flag flag = new Flag();
            flag.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Outdoor otd = new Outdoor();
            otd.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

 

      
    }
}
