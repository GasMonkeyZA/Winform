using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peanuts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        LoginClass lc = new LoginClass();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtLastName.Text == "" || txtContact.Text == "" || txtAddress.Text == "" || txtEmail.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill in the blanks");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords don't match");
            }
            else
            {
                lc.Name     = txtName.Text;
                lc.LastName = txtLastName.Text;
                lc.Contact  = txtContact.Text;
                lc.Address  = txtAddress.Text;
                lc.Email    = txtEmail.Text;
                lc.Username = txtUsername.Text;
                lc.Password = txtPassword.Text;

                bool success = lc.Insert(lc);

                if (success == true)
                {
                    const string message = "New User Successfully Added";
                    const string caption = "New User ";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        //Insert Clear Method here

                        Home hme = new Home();
                        hme.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    //Failed to add new user
                    MessageBox.Show("Failed to add new User.  Please try again.");
                }
                
            }

        }

        public void Clear()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

    }
}
