using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group4_Project_PRG281.DataAccessLayer;
using Group4_Project_PRG281.PresentationLayer;

namespace Group4_Project_PRG281
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DataHandler handler = new DataHandler();
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (handler.UsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            else
            {
                handler.UserRegisteration(username, password);
                MessageBox.Show("Registration successful! You can now log in.");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (handler.LoginAuthenticator(username, password))
            {
                this.Hide();
                MainForm form = new MainForm();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
