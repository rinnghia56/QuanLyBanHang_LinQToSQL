using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BusinessLogic;
namespace PBL3.GUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = Function.Instance.checkValidAccount(txtUsername.Text, txtPassword.Text);
            if (tk != null)
            {
                this.Hide();
                FrmMain frm = new FrmMain();
                frm.Sender(tk.ID_TK,(bool)tk.type);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
