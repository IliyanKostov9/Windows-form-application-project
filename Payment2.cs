using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Online_shop_
{
    public partial class Payment2 : Form
    {
        public Payment2()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public SqlCommand myCommand;
        Form1 frm = new Form1();



        private void Payment2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int iError = 0;
                try
                {
                    try {
                     myConnection = new SqlConnection(frm.cs);
                     myConnection.Open();
                   myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN WHERE USERNAME_USER='"+Form1.sUsername+"'", myConnection);
                 iError = Int32.Parse(myCommand.ExecuteScalar().ToString());

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }

                }
                catch (Exception ex) {MessageBox.Show("Error"+ex.Message+" "+ ex.Data); }
                    myConnection.Close();

                   
                    myConnection = new SqlConnection(frm.cs);
                    myCommand = new SqlCommand(@"insert into Payment(NAME_PAYMENT,CREDIT_CARD_PAYMENT,EXPIRATION_PAYMENT,CVV_PAYMENT,FK_USERP) values(@NAME,@CARD,@EXPIRATION,@CVV,@USERP)", myConnection);

                    myCommand.Parameters.AddWithValue("@NAME", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@CARD", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@EXPIRATION", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@CVV", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@USERP", iError);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Credit card added!");
                    Close();
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }




            }
            else MessageBox.Show("Please fill all the neccessary information!");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


      
    }
}
