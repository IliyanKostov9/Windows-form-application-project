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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        static int iQuantity = 0;
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        Options Options = new Options();
        Form1 frm = new Form1();

        private void displayData()
        {
            myConnection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select NAME_PRODUCT, DESCRIPTION_PRODUCT, PRICE_PRODUCT, NAME_PRODUCT_TYPE from Product join Product_type on(FK_PRODUCT_TYPE=ID_PRODUCT_TYPE) where NAME_PRODUCT='" + Options.sProduct + "'", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
           
            myConnection.Close();
        }






        private void Add_Load(object sender, EventArgs e)
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
            string sIDProduct = "", sIDUser = "";
            string sFindSameProduct = "";
            string sMergeQuantity = "";
            bool bMergeQuantityProduct =true;
            int iMergeQuantity = 0;

            if (iQuantity == 0) { MessageBox.Show("You cannot add product with 0 quantity!"); }
            else
            {
                try
                {

                    myConnection = new SqlConnection(frm.cs);
                    myConnection.Open();
                    myCommand = new SqlCommand("SELECT ID_PRODUCT FROM Product WHERE NAME_PRODUCT='" + Options.sProduct + "'", myConnection);
                    sIDProduct = myCommand.ExecuteScalar().ToString();
                    myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN WHERE USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                    sIDUser = myCommand.ExecuteScalar().ToString();
                    myConnection.Close();

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }

                }
                catch (Exception ex) { MessageBox.Show("Error"); }


                try
                {
                    myConnection = new SqlConnection(frm.cs);
                    myConnection.Open();
                    myCommand = new SqlCommand("SELECT FK_PRODUCT FROM Cart join Product on(FK_PRODUCT=ID_PRODUCT) join UserLOGIN on(FK_USERC=ID_USER) WHERE NAME_PRODUCT='" + Options.sProduct + "' AND ID_USER='" + sIDUser + "'", myConnection);
                    sFindSameProduct = myCommand.ExecuteScalar().ToString();
                    myCommand = new SqlCommand("SELECT QUANTITY_CART FROM Cart join Product on(FK_PRODUCT=ID_PRODUCT) join UserLOGIN on(FK_USERC=ID_USER) WHERE NAME_PRODUCT='" + Options.sProduct + "' AND ID_USER='" + sIDUser + "'", myConnection);
                    sMergeQuantity = myCommand.ExecuteScalar().ToString();
                    iMergeQuantity = Int32.Parse(sMergeQuantity);
                }
                catch (Exception ex) { bMergeQuantityProduct = false; }
               

                if (bMergeQuantityProduct)
                {

                    try
                    {
                        myConnection = new SqlConnection(frm.cs);
                        myCommand = new SqlCommand("UPDATE Cart SET QUANTITY_CART='"+(iMergeQuantity+iQuantity)+"' WHERE FK_PRODUCT='"+sFindSameProduct+"'", myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("Product added to cart with quantity!");
                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Dispose();
                        }
                        iQuantity = 0;
                        Close();

                    }
                    catch (Exception ex) { MessageBox.Show("Error" + ex.Message + " " + ex.Data); }
                    myConnection.Close();


                }
                else
                {
                    try
                    {
                        myConnection = new SqlConnection(frm.cs);
                        myCommand = new SqlCommand("INSERT INTO Cart(QUANTITY_CART,FK_PRODUCT,FK_USERC) VALUES(@QUANTITY,@PRODUCT,@USERC)", myConnection);
                        myCommand.Parameters.AddWithValue("@QUANTITY", textBox1.Text);
                        myCommand.Parameters.AddWithValue("@PRODUCT", sIDProduct);
                        myCommand.Parameters.AddWithValue("@USERC", sIDUser);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("Product added to cart! ");
                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Dispose();
                        }
                        iQuantity = 0;
                        Close();

                    }
                    catch (Exception ex) { MessageBox.Show("Error" + ex.Message + " " + ex.Data); }
                    myConnection.Close();
                }
            }
        }












        private void button2_Click(object sender, EventArgs e)
        {


            string sIDProduct = "", sIDUser = "";

            try
            {

                myConnection = new SqlConnection(frm.cs);
                myConnection.Open();
                myCommand = new SqlCommand("SELECT ID_PRODUCT FROM Product WHERE NAME_PRODUCT='" + Options.sProduct + "'", myConnection);
                sIDProduct = myCommand.ExecuteScalar().ToString();
                myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN WHERE USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                sIDUser = myCommand.ExecuteScalar().ToString();
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }

            }
            catch (Exception ex) { MessageBox.Show("Error"); }


            try
            {

                myConnection = new SqlConnection(frm.cs);
                //myConnection.Open();
                myCommand = new SqlCommand("INSERT INTO Whishlist(FK_PRODUCT,FK_USERW) VALUES(@PRODUCT,@USERW)", myConnection);
                myCommand.Parameters.AddWithValue("@PRODUCT", sIDProduct);
                myCommand.Parameters.AddWithValue("@USERW", sIDUser);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Product added to wishlist! ");
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
                iQuantity = 0;

                Close();

            }
            catch (Exception ex) { MessageBox.Show("Error" + ex.Message + " " + ex.Data); }
            myConnection.Close();

        }






        private void button5_Click(object sender, EventArgs e)
        {
            if (iQuantity < 999)
            {
                iQuantity +=1;
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

        private void button4_Click(object sender, EventArgs e)
        {
            iQuantity = 0;

            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iQuantity = 0;

            Checkout chk = new Checkout();
            chk.Show();
            Close();
        }

       

      

     


    }
}
