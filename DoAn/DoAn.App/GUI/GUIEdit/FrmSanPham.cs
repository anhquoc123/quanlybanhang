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
    public partial class FrmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public FrmSanPham(int msp)
        {
            InitializeComponent();
            this.spDonGia.Properties.MinValue = 0;
            this.spDonGia.Properties.MaxValue = decimal.MaxValue;
            this.spSoLuong.Properties.MinValue = 0;
            this.spSoLuong.Properties.MaxValue = decimal.MaxValue;
            var loaiDAO = new LoaiSanPhamDAO();
            slLoaiSanPham.Properties.DataSource = loaiDAO.GetAll();
            slLoaiSanPham.Properties.DisplayMember = "TenLoai";
            slLoaiSanPham.Properties.ValueMember = "MaLoai";
            txtMaSanPham.Text = msp + "";
            if (msp != 0)
            {
                var tkbase = new SanPhamDAO();
                var tk = tkbase.GetBy(msp);
                txtTenSanPham.Text = tk.TenSanPham;
                spDonGia.Text = (tk.DonGia??0).ToString("n0");
                spSoLuong.Text = (tk.SoLuong??0).ToString("n0");
                txtMota.Text = tk.Mota;
                slLoaiSanPham.EditValue = tk.LoaiSanPham;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSanPham.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(slLoaiSanPham.EditValue+""))
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(spDonGia.EditValue + ""))
            {
                spDonGia.EditValue = "0";
            }
            if (string.IsNullOrEmpty(spSoLuong.EditValue + ""))
            {
                spSoLuong.EditValue = "0";
            }
            var tkbase = new SanPhamDAO();
            var tk = new SanPham();
            tk.LoaiSanPham = int.Parse(slLoaiSanPham.EditValue+"");
            tk.TenSanPham = txtTenSanPham.Text;
            tk.Mota = txtMota.Text;
            tk.DonGia = int.Parse(spDonGia.EditValue + "");
            tk.SoLuong = int.Parse(spSoLuong.EditValue + "");
            var res = tkbase.Save(tk);
            if (!res)
            {
                MessageBox.Show("Thêm sản phẩm lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}