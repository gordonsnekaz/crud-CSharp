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
    public partial class UpdateCustomer : UserControl
    {
        //connection string 
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/ADMIN/Desktop/Leeroy/RegistryMaintanance/RegistryMaintanance/Registry.accdb");

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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

                if (searchResultGrid.RowCount == 1)
                {
                    MessageBox.Show("Empty");
                }
                else
                {
                    shield.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry for the system breakdown!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "UPDATE customers SET First_name='" + firstName.Text + "', Last_name='" + lastName.Text + "', Stand_number='" + standNumber.Text + "', Address='" + address.Text + "' WHERE National_ID='" + nationalId.Text + "'";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "Congrats");
                con.Close();
                shield.Show();
                nationalId.Text = "";
                firstName.Text = "";
                lastName.Text = "";
                address.Text = "";
                standNumber.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong user input, please enter correct details.!!!");
            }
        }
    }
}
