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
    public partial class Account_detail : Form
    {
        public Account_detail()
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
            adapt = new SqlDataAdapter("select USERNAME_USER, PASSWORD_USER, EMAIL_USER, PHONE_USER, ADDRESS_USER from UserLOGIN where USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
        }

        private void displayData2()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select NAME_PAYMENT, CREDIT_CARD_PAYMENT, EXPIRATION_PAYMENT, CVV_PAYMENT from Payment join UserLOGIN on(FK_USERP=ID_USER) where UserLOGIN.USERNAME_USER='" + Form1.sUsername + "'", myConnection);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            myConnection.Close();
        }

        private void Account_detail_Load(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                displayData();
                displayData2();
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


    }
}
