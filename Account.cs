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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        Form1 frm = new Form1();
        Form2 frm2 = new Form2();

        private void displayData()
        {
          DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select USERNAME_USER , PASSWORD_USER , EMAIL_USER , PHONE_USER , ADDRESS_USER from UserLOGIN where USERNAME_USER='"+Form1.sUsername+"'", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }

        private void Account_Load(object sender, EventArgs e)
        {
          

             try
            {
                myConnection = new SqlConnection(frm.cs);
                displayData();
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
          
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Singing out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    myConnection = new SqlConnection(frm.cs);
                    myCommand = new SqlCommand("DELETE FROM UserLOGIN WHERE USERNAME_USER='"+Form1.sUsername+"'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Account deleted! ");
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                    Application.Restart();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
        }



        }
    
}
