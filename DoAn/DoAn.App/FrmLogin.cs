using DoAn.App.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAn.App
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public string username { get; set; }
        public FrmLogin(string us)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(us))
            {
                txtUsername.Enabled = false;
                txtUsername.Text = us;
            }
            lbError.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = txtPassword.Enabled = btnLogin.Enabled = false;
            lbError.Text = "";
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                lbError.Text = "Vui lòng nhập tên đăng nhập";
                txtUsername.Enabled = txtPassword.Enabled = btnLogin.Enabled = true;
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                lbError.Text = "Vui lòng nhập mật khẩu";
                txtUsername.Enabled = txtPassword.Enabled = btnLogin.Enabled = true;
                return;
            }
            var tkbase = new TaiKhoanDAO();
            var tk = tkbase.GetBy(txtUsername.Text);
            if (tk == null)
            {
                lbError.Text = "Tài khoản không tồn tại";
                txtUsername.Enabled = txtPassword.Enabled = btnLogin.Enabled = true;
                return;
            }
            if (tk.MatKhau != txtPassword.Text)
            {
                lbError.Text = "Mật khẩu không chính xác";
                txtUsername.Enabled = txtPassword.Enabled = btnLogin.Enabled = true;
                return;
            }
            username = txtUsername.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
