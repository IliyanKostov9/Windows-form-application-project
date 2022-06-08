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
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
        }


        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        Form1 frm = new Form1();

        private void displayData()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select NAME_PRODUCT AS PRODUCT, DESCRIPTION_PRODUCT AS DETAIL, PRICE_PRODUCT AS PRICE, NAME_PRODUCT_TYPE AS TYPE , QUANTITY_CART AS QUANTITY from Cart join UserLOGIN on( FK_USERC=ID_USER) join Product on( FK_PRODUCT=ID_PRODUCT) join Product_type on (FK_PRODUCT_TYPE=ID_PRODUCT_TYPE) where UserLOGIN.USERNAME_USER='" + Form1.sUsername + "' ORDER BY NAME_PRODUCT", myConnection); adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }

        private void displayData2()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select USERNAME_USER from UserLOGIN where USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            myConnection.Close();
        }

        private void displayData3()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ADDRESS_USER AS ADDRESS from UserLOGIN where USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            myConnection.Close();
        }

        private void displayData4()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select NAME_PAYMENT, CREDIT_CARD_PAYMENT, EXPIRATION_PAYMENT, CVV_PAYMENT from Payment join UserLOGIN on(FK_USERP=ID_USER) where UserLOGIN.USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            myConnection.Close();
        }

        private void displayData5()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select SUM(TOTAL) AS Total from ( select ROUND(SUM(PRICE_PRODUCT * QUANTITY_CART),2) AS TOTAL , NAME_PRODUCT , QUANTITY_CART from Product join Cart on(FK_PRODUCT=ID_PRODUCT) "+
            "join UserLOGIN on(FK_USERC=ID_USER) where USERNAME_USER='" + Form1.sUsername + "' AND "+
            "ID_PRODUCT=FK_PRODUCT GROUP BY PRICE_PRODUCT, QUANTITY_CART , NAME_PRODUCT) Product", myConnection); adapt.Fill(dt);
          
            dataGridView5.DataSource = dt;
            myConnection.Close();
        }
        

        private void Checkout_Load(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                displayData();
                displayData2();
                displayData3();
                displayData4();
                displayData5();

                if ( dataGridView4.RowCount == 1) {       
                    if (MessageBox.Show("There are no saved payment methods , would you like to add one ?", "No payments saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Close();
                        Payment2 pay2 = new Payment2();
                        pay2.Show();
                    }
                    else
                    {
                        MessageBox.Show("You cannot proceed to checkout your products!"); Close();
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

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sSelected_payment = dataGridView4.CurrentRow.Cells[0].Value.ToString();

            if (dataGridView1.RowCount == 1) { MessageBox.Show("You can't checkout with empty cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Close(); }
            else
            {
                if (MessageBox.Show("Confirm purchase?", "Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (dataGridView4.RowCount > 2)
                    {
                        if (MessageBox.Show("Pay with card name :" + sSelected_payment + " ?", "Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                        }
                    }

                    try
                    {
                        int iError_user = 0;

                        try
                        {
                            myConnection = new SqlConnection(frm.cs);
                            myConnection.Open();
                            myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN where USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                            iError_user = Int32.Parse(myCommand.ExecuteScalar().ToString());
                            if (myConnection.State == ConnectionState.Open)
                            {
                                myConnection.Dispose();
                            }

                        }
                        catch (Exception ex) { MessageBox.Show("Error select " + ex.Message + " "); }

                        myConnection.Close();
                        myConnection = new SqlConnection(frm.cs);
                        myConnection.Open();

                        myCommand = new SqlCommand("DECLARE @ROWS INT; SET @ROWS=0; BEGIN INSERT INTO Transaction_history (FK_USERT,QUANTITY_TRANSACTION,FK_PRODUCTT) SELECT FK_USERC,QUANTITY_CART,FK_PRODUCT FROM Cart END;", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Dispose();
                        }

                        myCommand = new SqlCommand("DELETE FROM Cart WHERE FK_USERC='" + iError_user + "'", myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("Transaction completed!");
                        Close();
                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Dispose();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Error " + ex.Message); }

                }
            }
        }





    }
}
