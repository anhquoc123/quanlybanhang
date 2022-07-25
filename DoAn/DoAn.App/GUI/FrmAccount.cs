using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DoAn.App.DAO;

namespace DoAn.App.GUI
{
    public partial class FrmAccount : DevExpress.XtraEditors.XtraForm
    {
        public FrmAccount(string username)
        {
            InitializeComponent();
            var tkbase = new TaiKhoanDAO();
            var tk = tkbase.GetBy(username);
            txtTenDangNhap.Text = username;
            txtHoTen.Text = tk.HoTen;
            var dataquyen = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>(1,"Admin"),
                new KeyValuePair<int, string>(2,"Nhân viên")
            };
            slRole.Properties.DataSource = dataquyen;
            slRole.Properties.DisplayMember = "Value";
            slRole.Properties.ValueMember = "Key";
            slRole.EditValue = tk.Groups;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu để lưu","Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tkbase = new TaiKhoanDAO();
            var tk = tkbase.GetBy(txtTenDangNhap.Text);
            if (tk != null)
            {
                if (txtPassword.Text != tk.MatKhau)
                {
                    MessageBox.Show("Mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtHoTen.Text != tk.HoTen)
                {
                    tk.HoTen = txtHoTen.Text;
                }
                if (int.Parse(slRole.EditValue+"") != (tk.Groups??0))
                {
                    tk.Groups = int.Parse(slRole.EditValue + "");
                }
                if (!string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
                {
                    if (txtNewPassword.Text.Trim() == txtPassword.Text.Trim())
                    {
                        MessageBox.Show( "Mật khẩu mới trùng mới mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtNewPassword.Text.Trim() != txtConfirm.Text.Trim())
                    {
                        MessageBox.Show("Mật khẩu mới không trùng mới mật khẩu nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tk.MatKhau = txtNewPassword.Text.Trim();
                }
                var res = tkbase.Save(tk);
                if (!res)
                {
                    MessageBox.Show("Lưu lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}