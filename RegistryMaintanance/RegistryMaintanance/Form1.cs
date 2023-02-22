using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RegistryMaintanance
{
    public partial class Login : Form
    {
        //connection string 
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/ADMIN/Desktop/Leeroy/RegistryMaintanance/RegistryMaintanance/Registry.accdb");

        public Login()
        {
            InitializeComponent();
            textBoxInitial();
        }

        public void textBoxInitial()
        {
            username.Text = "eg Leeroy";
            username.Font = new Font("Microsoft sans serif", 9, FontStyle.Bold);
            username.ForeColor = Color.Gray;

            password.Text = "******";
            password.Font = new Font("Microsoft sans serif", 9, FontStyle.Bold);
            password.ForeColor = Color.Gray;

        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "******")
            {
                password.Text = "";
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "******";
            }
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "eg Leeroy")
            {
                username.Text = "";
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "eg Leeroy";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to exit the application?", "Confirm Exit!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Good bye!!!");
                Application.Exit();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query = @"SELECT COUNT(*) FROM admins WHERE username='" +username.Text + "' AND password='"+ password.Text +"'";
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                OleDbDataAdapter adapt;
                adapt = new OleDbDataAdapter(query, con);
                cmd.Connection = con;

                DataTable dt = new DataTable();
                adapt.Fill(dt);
                con.Close();

                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Home f2 = new Home();
                    f2.ShowDialog();
                    this.Close();
                }
                else
                {
                    username.Text = "";
                    password.Text = "";
                    textBoxInitial();
                    username.Focus();
                    MessageBox.Show("Invalid username or password!!!");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry for the system breakdown!!!");
            }
            
        }

        private void forgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please visit the Information and technology for help!!!");
        }
        
    }
}
