using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abadir
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseLayer database = new DatabaseLayer();
            string role = database.GetRole(txtEmployeeID.Text, txtPassword.Text);
            string name = database.GetName(txtEmployeeID.Text);
            role = role.ToLower();
            name = name.ToUpper();

            if (txtEmployeeID.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Both the EmployeeID and password fields need to be filled");
            }
            else
            {
                if (role == "seller" || role=="admin")
                {
                    MainForm mainForm = new MainForm(role,txtEmployeeID.Text, name);
                    
                    this.Hide();
                    mainForm.ShowDialog();
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Invalid EmployeeID and password pair");
                }
               
            }

        }
    }
}
