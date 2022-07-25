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
using DoAn.App.Model;

namespace DoAn.App.GUI.GUIEdit
{
    public partial class FrmUser : DevExpress.XtraEditors.XtraForm
    {
        public FrmUser(string username)
        {
            InitializeComponent();
            var dataquyen = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>(1,"Admin"),
                new KeyValuePair<int, string>(2,"Nhân viên")
            };
            slRole.Properties.DataSource = dataquyen;
            slRole.Properties.DisplayMember = "Value";
            slRole.Properties.ValueMember = "Key";
            if (!string.IsNullOrEmpty(username))
            {
                var tkbase = new TaiKhoanDAO();
                var tk = tkbase.GetBy(username);
                txtTenDangNhap.Text = username;
                txtHoTen.Text = tk.HoTen;
                txtHoTen.Text = tk.HoTen;
                slRole.EditValue = tk.Groups;
            }
            else
            {
                txtTenDangNhap.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(slRole.EditValue + ""))
            {
                MessageBox.Show("Vui lòng chọn quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tkbase = new TaiKhoanDAO();
            var tk = new TaiKhoan();
            tk.TenDangNhap = txtTenDangNhap.Text.Trim();
            tk.HoTen = txtHoTen.Text;
            tk.Groups = int.Parse(slRole.EditValue + "");
            var res = tkbase.Save(tk);
            if (!res)
            {
                MessageBox.Show("Thêm tài khoản lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}