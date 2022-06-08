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
    public partial class Change_quantity : Form
    {
        public Change_quantity()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        Form1 frm = new Form1();
        Cart cart = new Cart();
        static int iQuantity = 0;

        private void Change_quantity_Load(object sender, EventArgs e)
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


        private void displayData()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select NAME_PRODUCT AS PRODUCT, DESCRIPTION_PRODUCT AS DETAIL, PRICE_PRODUCT AS PRICE, NAME_PRODUCT_TYPE AS TYPE , QUANTITY_CART AS QUANTITY "+
            "from Cart join UserLOGIN on( FK_USERC=ID_USER) join Product on( FK_PRODUCT=ID_PRODUCT) join Product_type on (FK_PRODUCT_TYPE=ID_PRODUCT_TYPE) "+
            "where UserLOGIN.USERNAME_USER='" + Form1.sUsername + "' AND NAME_PRODUCT='"+Cart.sCart+"'", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string sSelected_product = "";
            if (iQuantity == 0) { MessageBox.Show("You cant set 0 quantity!"); }

            else
            {
                //sSelected_product = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(sSelected_product);
                try
                {
                    int iError = 0;
                    int iError_product = 0;

                    try
                    {
                        myConnection = new SqlConnection(frm.cs);
                        myConnection.Open();
                        myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN WHERE USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                        iError = Int32.Parse(myCommand.ExecuteScalar().ToString());
                        myCommand = new SqlCommand("SELECT ID_PRODUCT FROM Product WHERE NAME_PRODUCT='" + Cart.sCart + "'", myConnection);
                        iError_product = Int32.Parse(myCommand.ExecuteScalar().ToString());

                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Dispose();
                        }

                    }
                    catch (Exception ex) { MessageBox.Show("Error" + ex.Message + " " + ex.Data); }
                    myConnection.Close();

                    myConnection = new SqlConnection(frm.cs);
                    myCommand = new SqlCommand("UPDATE Cart SET QUANTITY_CART='" + iQuantity + "' WHERE FK_USERC='" + iError + "' AND FK_PRODUCT='" + iError_product + "'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Quantity edited!");
                    iQuantity = 0;
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (iQuantity < 999)
            {
                iQuantity += 1;
                textBox1.Text = iQuantity.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (iQuantity > 0)
            {
                iQuantity -= 1;
                textBox1.Text = iQuantity.ToString();
            }
        }



    }
}
