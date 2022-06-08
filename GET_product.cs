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
    public partial class GET_product : Form
    {
        public GET_product()
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
            adapt = new SqlDataAdapter("select NAME_PRODUCT AS PRODUCT, DESCRIPTION_PRODUCT AS DETAIL, PRICE_PRODUCT AS PRICE, NAME_PRODUCT_TYPE AS TYPE from Product join Product_type on( FK_PRODUCT_TYPE=ID_PRODUCT_TYPE) ORDER BY NAME_PRODUCT", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }



        private void GET_product_Load(object sender, EventArgs e)
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
    }
}
