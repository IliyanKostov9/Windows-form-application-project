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
    public partial class LED : Form
    {
        public LED()
        {
            InitializeComponent();
        }

        Options options = new Options();

        private void button3_Click(object sender, EventArgs e)
        {
            Options.sProduct = "LED A19 Grow Light Bulb - Full Spectrum - LumeGen";
            Add add = new Add();
            add.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Options.sProduct = "LED Temporary Dual-Head Work Light - 200W - 20,0000 Lumens - 5000K - Pinegreen Lighting";
            Add add = new Add();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Case of 6 - GE Lighting Energy Smart - Lumens";
            Add add = new Add();
            add.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Replay Collection - 1 Light Wall Bracket With Etched Glass Shade - Progress Lighting";
            Add add = new Add();
            add.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Options.sProduct = "A19 - 25W - Orange Party Light";
            Add add = new Add();
            add.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Edition Collection - One-Light Large Wall Lantern - Progress Lighting";
            Add add = new Add();
            add.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Options.sProduct = "LED Wattage Adjustable and Color Tunable Canopy Light";
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

        private void LED_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label3.Text = "Welcome back " + Form1.sUsername;
            label4.Text = date.ToString();
        }
    }
}
