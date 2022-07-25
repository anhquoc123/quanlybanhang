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
    public partial class FrmLoaiSanPham : DevExpress.XtraEditors.XtraForm
    {
        public FrmLoaiSanPham(int maloai)
        {
            InitializeComponent();
            txtMaLoai.Text = maloai + "";
            if (maloai != 0)
            {
                var tkbase = new LoaiSanPhamDAO();
                var tk = tkbase.GetBy(maloai);
                txtTenLoai.Text = tk.TenLoai;
                txtMota.Text = tk.MoTa;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tkbase = new LoaiSanPhamDAO();
            var tk = new LoaiSanPham();
            tk.MaLoai =int.Parse( txtMaLoai.Text.Trim());
            tk.TenLoai = txtTenLoai.Text;
            tk.MoTa = txtMota.Text;
            var res = tkbase.Save(tk);
            if (!res)
            {
                MessageBox.Show("Thêm loại sản phẩm lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thêm loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}