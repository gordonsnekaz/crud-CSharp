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

    public partial class AddCuctomer : UserControl
    {
        //connection string
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/ADMIN/Desktop/Leeroy/RegistryMaintanance/RegistryMaintanance/Registry.accdb");

        public AddCuctomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Insert into customers(National_ID,First_name,Last_name,Address,Stand_number,Tax,Amount,Balance,Date_of_issue) Values('" + nationalId.Text + "','" + firstName.Text + "','" + lastName.Text + "','" + address.Text + "','" + standNumber.Text + "','" + tax.Text + "','" + amount.Text + "','" + balance.Text + "','" + DateTime.Now + "')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Submitted", "Congrats");
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong user input, please enter correct details!!!");
            }
            firstName.Text = "";
            lastName.Text = "";
            nationalId.Text = "";
            address.Text = "";
            tax.Text = "";
            balance.Text = "";
            amount.Text = "";
            standNumber.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            firstName.Text = "";
            lastName.Text = "";
            nationalId.Text = "";
            address.Text = "";
            tax.Text = "";
            balance.Text = "";
            amount.Text = "";
            standNumber.Text = "";
        }
    }
}
