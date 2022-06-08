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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        Form1 frm = new Form1();


        private void Register_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Requirements\n\n\n username and password should be at least 8 characters length and should not be the same !";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sLengthError = "";
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if ( (textBox1.TextLength <= 8 && textBox2.TextLength <= 8 ) || ( textBox1.Text == textBox2.Text) ) sLengthError="Username / Password don't meet the minimum requirements!";
                bool bNotEqualUsername = false;
   
                try
                {
                    
                   myConnection = new SqlConnection(frm.cs);
                   myConnection.Open();
                   myCommand = new SqlCommand("SELECT USERNAME_USER FROM UserLOGIN WHERE USERNAME_USER='"+textBox1.Text+"'", myConnection);
                   myCommand.ExecuteScalar().ToString();

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }

                }
                catch (Exception ex) {  bNotEqualUsername = true; }


                if (!bNotEqualUsername) { MessageBox.Show("\nUsername is already taken!"); }
                else
                {
                    if (sLengthError != "") MessageBox.Show(sLengthError);
                    else
                    {
                        try
                        {
                            myConnection = new SqlConnection(frm.cs);
                            myCommand = new SqlCommand("INSERT INTO UserLOGIN(USERNAME_USER,PASSWORD_USER,EMAIL_USER,PHONE_USER,ADDRESS_USER) " +
                            "VALUES(@USERNAME,@PASSWORD,@EMAIL,@PHONE,@ADDRESS)", myConnection);
                            myCommand.Parameters.AddWithValue("@USERNAME", textBox1.Text);
                            myCommand.Parameters.AddWithValue("@PASSWORD", textBox2.Text);
                            myCommand.Parameters.AddWithValue("@EMAIL", textBox3.Text);
                            myCommand.Parameters.AddWithValue("@PHONE", textBox4.Text);
                            myCommand.Parameters.AddWithValue("@ADDRESS", textBox6.Text);
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            MessageBox.Show("You have registered in successfully " + textBox1.Text);
                            if (myConnection.State == ConnectionState.Open)
                            {
                                myConnection.Dispose();
                            }
                            Close();

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
                    }
                }
           } else MessageBox.Show("Empty username / password!");
            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
