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
    public partial class Outdoor : Form
    {
        public Outdoor()
        {
            InitializeComponent();
        }

        Options options = new Options();
        

        private void button3_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Woodeze BBQ Campfire Rotisserie";
            Add add = new Add();
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Woodeze 10 x 20 Canopy Party Tent - Blue";
            Add add = new Add();
            add.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Options.sProduct = "WoodEze 1-2 Face Cord Expandable Heavy Duty Firewood Rack";
            Add add = new Add();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Options.sProduct = "King Canopy 12 x 20 8-Leg White Universal Canopy";
            Add add = new Add();
            add.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Woodeze Foldable Beach  Utility Wagon with Brake";
            Add add = new Add();
            add.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Options.sProduct = "Tree of Life Fire Pit Ring- 30 Inch";
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

        private void Outdoor_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label3.Text = "Welcome back " + Form1.sUsername;
            label4.Text = date.ToString();
        }
    }
}
