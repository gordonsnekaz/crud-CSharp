using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RegistryMaintanance
{
    public partial class SearchCustomer : UserControl
    {
        //connection string 
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/ADMIN/Desktop/Leeroy/RegistryMaintanance/RegistryMaintanance/Registry.accdb");

        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query = @"SELECT * FROM customers WHERE National_ID='" + Convert.ToString(nationalId.Text) + "' ";
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                OleDbDataAdapter adapt;
                adapt = new OleDbDataAdapter(query, con);
                cmd.Connection = con;

                DataTable dt = new DataTable();
                adapt.Fill(dt);
                searchResultGrid.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong user input!!!");
            }
        }
    }
}
