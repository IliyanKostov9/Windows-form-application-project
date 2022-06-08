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
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }



        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        Form1 frm = new Form1();
        public static string sCart = "";
        public static  int iError = 0;
        public static int iError_product = 0;
       

        private void displayData()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select NAME_PRODUCT AS PRODUCT, DESCRIPTION_PRODUCT AS DETAIL, PRICE_PRODUCT AS PRICE, NAME_PRODUCT_TYPE AS TYPE , QUANTITY_CART AS QUANTITY from Cart join UserLOGIN on( FK_USERC=ID_USER) join Product on( FK_PRODUCT=ID_PRODUCT) join Product_type on (FK_PRODUCT_TYPE=ID_PRODUCT_TYPE) where UserLOGIN.USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }


        private void Cart_Load(object sender, EventArgs e)
        {

            try{
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
     if (MessageBox.Show("Are you sure you want to remove this item from cart?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
     {
         try
         {
  
            
             sCart = dataGridView1.CurrentRow.Cells[0].Value.ToString();
             
             try
             {
                 myConnection = new SqlConnection(frm.cs);
                 myConnection.Open();
                 myCommand = new SqlCommand("SELECT ID_USER FROM UserLOGIN WHERE USERNAME_USER='" + Form1.sUsername + "'", myConnection);
                 iError = Int32.Parse(myCommand.ExecuteScalar().ToString());
                 myCommand = new SqlCommand("SELECT ID_PRODUCT FROM Product WHERE NAME_PRODUCT='" + sCart + "'", myConnection);
                 iError_product = Int32.Parse(myCommand.ExecuteScalar().ToString());
             
                 if (myConnection.State == ConnectionState.Open)
                 {
                     myConnection.Dispose();
                 }

             }
             catch (Exception ex) { MessageBox.Show("Error" + ex.Message + " " + ex.Data); }
             myConnection.Close();



             int rowIndex = dataGridView1.CurrentCell.RowIndex;
             //  sCard = dataGridView1.CurrentCell.Value.ToString();

             dataGridView1.Rows.RemoveAt(rowIndex);
             //  MessageBox.Show(sCard);
             myConnection = new SqlConnection(frm.cs);
             myCommand = new SqlCommand("DELETE FROM Cart WHERE FK_USERC='" + iError + "' AND FK_PRODUCT='" + iError_product + "'", myConnection);
             myConnection.Open();
             myCommand.ExecuteNonQuery();
             myConnection.Close();
             MessageBox.Show("Product deleted!");
             if (myConnection.State == ConnectionState.Open)
             {
                 myConnection.Dispose();
             }
         }
         catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
     }
 }

 private void button2_Click(object sender, EventArgs e)
 {
     sCart = dataGridView1.CurrentRow.Cells[0].Value.ToString();
     Change_quantity ch_quant = new Change_quantity();
     ch_quant.Show();
 }





    }
}
