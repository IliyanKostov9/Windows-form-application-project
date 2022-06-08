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
    public partial class Edit_username : Form
    {
        public Edit_username()
        {
            InitializeComponent();
        }


        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        Form1 frm = new Form1();

        private void Edit_username_Load(object sender, EventArgs e)
        {
            richTextBox1.Text="Requirements\n\n\n username should be at least 8 characters length !";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to edit username?", "Change username", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
             if (textBox1.Text !="")
            {
                bool bNotEqualUsername = false;

                try
                {

                    myConnection = new SqlConnection(frm.cs);
                    myConnection.Open();
                    myCommand = new SqlCommand("SELECT USERNAME_USER FROM UserLOGIN WHERE USERNAME_USER='" + textBox1.Text + "'", myConnection);
                    myCommand.ExecuteScalar().ToString();

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }

                }
                catch (Exception ex) { bNotEqualUsername = true; }


                if (!bNotEqualUsername) { MessageBox.Show("\nUsername is already taken!"); textBox1.Clear(); textBox1.Focus(); }
                else
                {
                    string sLengthError = "";
                    if (textBox1.TextLength <= 8) sLengthError = "Username don't meet the minimum requirements!";

                    if (sLengthError != "") MessageBox.Show(sLengthError);
                    else
                    {
                        try
                        {
                            myConnection = new SqlConnection(frm.cs);
                            myCommand = new SqlCommand("UPDATE UserLOGIN SET USERNAME_USER='" + textBox1.Text + "' WHERE USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            MessageBox.Show("You have edited in successfully ! You will now log out " + textBox1.Text);
                            Form1.sUsername = textBox1.Text;
                            Application.Restart();

                            if (myConnection.State == ConnectionState.Open)
                            {
                                myConnection.Dispose();
                            }
                            Close();

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
                    }
                }
            }
            else MessageBox.Show("Empty username!");
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    


    }
}
