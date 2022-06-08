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
    public partial class Form1 : Form
    {

       public static string sUsername;

        public Form1()
        {
            
          
            InitializeComponent();
        }

        public string cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Local0\Documents\Visual Studio 2012\Projects\Online shop_\Online shop_\Database1.mdf;Integrated Security=True";
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);




        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                button1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                myConnection = new SqlConnection(cs);
                myCommand = new SqlCommand("SELECT * FROM UserLOGIN WHERE USERNAME_USER = @NAME AND PASSWORD_USER = @PASSWORD", myConnection);

                SqlParameter uName = new SqlParameter("@NAME", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                uName.Value = textBox1.Text;
                uPassword.Value = textBox2.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read() == true)
                {
                    MessageBox.Show("You have logged in successfully " + textBox1.Text);
                    sUsername = textBox1.Text;
                    //Hide the login form
                    this.Hide();
                    Options opt = new Options();
                    opt.Show();
                   // Form2 frm2 = new Form2();
                    //frm2.Show();
                }
                else
                {
                    MessageBox.Show("Username / Password is incorrect!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }






    }
}