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
    public partial class Payment : Form
    {
        public Payment()
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
            adapt = new SqlDataAdapter("select NAME_PAYMENT , CREDIT_CARD_PAYMENT , EXPIRATION_PAYMENT , CVV_PAYMENT from Payment join UserLOGIN on( FK_USERP=ID_USER) where USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }

        private void Payment_Load(object sender, EventArgs e)
        {


            try
            {
                myConnection = new SqlConnection(frm.cs);
                displayData();
                if (dataGridView1.Rows[0].Cells[0].Value == null)
                {
                    if (MessageBox.Show("There are no saved payment methods , would you like to add one ?", "No payments saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Close();
                        Payment2 pay2 = new Payment2();
                        pay2.Show();
                    }
                }
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

            if (MessageBox.Show("Are you sure you want to delete the selected card?", "Delete card", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int iError = 0;
                    try
                    {
                        myConnection = new SqlConnection(frm.cs);
                        myConnection.Open();
                        myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN WHERE USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                        iError = Int32.Parse(myCommand.ExecuteScalar().ToString());

                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Dispose();
                        }

                    }
                    catch (Exception ex) { MessageBox.Show("IDK" + ex.Message + " " + ex.Data); }
                    myConnection.Close();


                    string sCard = "";
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    sCard = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    MessageBox.Show(sCard);
                    myConnection = new SqlConnection(frm.cs);
                    myCommand = new SqlCommand("DELETE FROM Payment WHERE FK_USERP='" + iError + "' AND CREDIT_CARD_PAYMENT='" + sCard + "'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Credit card deleted!");
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                }
                catch (Exception ex) { MessageBox.Show("You can't delete an empty record of credit card!"); }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Payment2 pay2 = new Payment2();
            pay2.Show();
        }


         

    }
}
