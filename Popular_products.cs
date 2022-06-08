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
    public partial class Popular_products : Form
    {
        public Popular_products()
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
            adapt = new SqlDataAdapter("select USERNAME_USER, NAME_PRODUCT AS PRODUCT, DESCRIPTION_PRODUCT AS DETAIL, PRICE_PRODUCT AS PRICE, NAME_PRODUCT_TYPE AS TYPE , QUANTITY_TRANSACTION AS QUANTITY from Transaction_history join UserLOGIN on( FK_USERT=ID_USER) join Product on( FK_PRODUCTT=ID_PRODUCT) join Product_type on (FK_PRODUCT_TYPE=ID_PRODUCT_TYPE) ORDER BY USERNAME_USER", myConnection); adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }

        private void displayData5()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select SUM(TOTAL) AS Total from ( select ROUND(SUM(PRICE_PRODUCT * QUANTITY_TRANSACTION),2) AS TOTAL , PRICE_PRODUCT from Product join Transaction_history on(FK_PRODUCTT=ID_PRODUCT) " +
            "join UserLOGIN on(FK_USERT=ID_USER) " +
            "GROUP BY PRICE_PRODUCT ) Product", myConnection); 
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            myConnection.Close();
        }

        private void displayData3()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ROUND(SUM(PRICE_PRODUCT * QUANTITY_TRANSACTION),2) AS TOTAL ,USERNAME_USER AS USERNAME, NAME_PRODUCT , QUANTITY_TRANSACTION from Product join Transaction_history on(FK_PRODUCTT=ID_PRODUCT) " +
            "join UserLOGIN on(FK_USERT=ID_USER) where " +
            "ID_PRODUCT=FK_PRODUCTT GROUP BY PRICE_PRODUCT, QUANTITY_TRANSACTION , NAME_PRODUCT , USERNAME_USER ORDER BY TOTAL DESC", myConnection);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            myConnection.Close();
        }


        private void Popular_products_Load(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                displayData();
                displayData5();
                displayData3();
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

    }
}
