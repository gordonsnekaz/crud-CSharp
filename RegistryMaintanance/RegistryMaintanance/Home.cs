using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryMaintanance
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            landingPage1.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
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
            addCuctomer1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteCustomer1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateCustomer1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchCustomer1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewCustomers1.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.ShowDialog();
            this.Close();

        }

        private void landingPage1_Load(object sender, EventArgs e)
        {

        }

    }
}
