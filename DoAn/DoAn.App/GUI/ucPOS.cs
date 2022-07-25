using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.App.DAO;
using DoAn.App.Model;
using DoAn.App.Model.DTO;
using DoAn.App.GUI.GUIEdit;

namespace DoAn.App.GUI
{
    public partial class ucPOS : UserControl
    {
        public string username { get; set; }
        public int MaHoaDon { get; set; }
        public List<ChiTietHoaDonDTO> chiTietHoaDonDTOs;
        public ucPOS(string us, int mahd, string nameparent)
        {
            InitializeComponent();
            username = us;
            MaHoaDon = mahd;
            LoadData();
            var tkbase = new TaiKhoanDAO();
            var tk = tkbase.GetBy(username);
            if (tk.Groups != 1)
            {
                btnAddLoaiSanPham.Enabled = false;
                btnAddProduct.Enabled = false;
            }
        }
        public void LoadLoaiSanPham()
        {
            var loaisanphamDAO = new LoaiSanPhamDAO();
            var data = loaisanphamDAO.GetAll();
            slLoaiSanPham.Properties.DataSource = data;
            slLoaiSanPham.Properties.DisplayMember = "TenLoai";
            slLoaiSanPham.Properties.ValueMember = "MaLoai";
        }
        public void LoadData()
        {
            LoadLoaiSanPham();
            chiTietHoaDonDTOs = new List<ChiTietHoaDonDTO>();
            btnUpdate.Enabled = false;
            if (MaHoaDon > 0)
            {
                lbHoaDon.Text = "Hóa Đơn: #" + MaHoaDon;
                var hdDAO = new HoaDonDAO();
                var hoadon = hdDAO.GetBy(MaHoaDon);

                grcChiTietHoaDon.Enabled = grcSanPham.Enabled = txtAddProduct.Enabled = txtSearch.Enabled = slLoaiSanPham.Enabled =
                    btnSearch.Enabled = btnSearch.Enabled = txtTenKhachHang.Enabled = txtSoDienThoai.Enabled = txtDiaChi.Enabled =
                    spGiamGia.Enabled = btnCreate.Enabled = !(hoadon.TrangThai == 1);
                btnUpdate.Enabled = (hoadon.TrangThai == 1);

                if (hoadon.TrangThai != 1)
                {
                    btnCreate.Text = "Cập nhật";
                }
                txtTenKhachHang.Text = hoadon.TenKhachHang;
                txtSoDienThoai.Text = hoadon.SoDienThoai;
                txtDiaChi.Text = hoadon.DiaChi;
                txtTong.Text = (hoadon.TongTien ?? 0).ToString("n0");
                var cthdDAO = new ChiTietHoaDonDAO();
                var chiTietHoas = cthdDAO.GetAll(MaHoaDon);
                foreach (var item in chiTietHoas)
                {
                    chiTietHoaDonDTOs.Add(new ChiTietHoaDonDTO()
                    {
                        SoLuong = item.SoLuong,
                        MaSanPham = item.MaSanPham,
                        DonGia = item.DonGia,
                        MaHoaDon = item.MaHoaDon,
                        MaChiTietHoaDon = item.MaChiTietHoaDon,
                        ThanhTien = item.DonGia
                    });
                }
                var sotien = (chiTietHoas.Sum(x => (x.ThanhTien ?? 0)));
                txtSoTien.Text = ((hoadon.TongTien ?? 0) + (sotien - (hoadon.TongTien ?? 0))).ToString("n0");
                spGiamGia.EditValue = ((hoadon.GiamGia ?? 0) * 100).ToString("n0");
                txtSoLuong.Text = (hoadon.SoLuong ?? 0).ToString("n0");
            }
            Search();
            InitChiTietHoaDon();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void InitChiTietHoaDon()
        {
            grcChiTietHoaDon.RefreshDataSource();
            grcChiTietHoaDon.DataSource = chiTietHoaDonDTOs;
            TinhTong();
        }
        private void Search()
        {
            var lsp = slLoaiSanPham.EditValue + "";
            if (string.IsNullOrEmpty(lsp))
            {
                lsp = "0";
            }
            var text = (txtSearch.EditValue + "").Trim();
            var spDAO = new SanPhamDAO();
            List<SanPham> data = new List<SanPham>();
            if (!string.IsNullOrEmpty(text) && int.Parse(lsp) > 0)
            {
                data = spDAO.GetAll(int.Parse(lsp), text);
            }
            else if (!string.IsNullOrEmpty(text) && int.Parse(lsp) <= 0)
            {
                data = spDAO.GetAll(text);
            }
            else if (string.IsNullOrEmpty(text) && int.Parse(lsp) > 0)
            {
                data = spDAO.GetAll(int.Parse(lsp));
            }
            else if (string.IsNullOrEmpty(text) && int.Parse(lsp) <= 0)
            {
                data = spDAO.GetAll();
            }
            grcSanPham.DataSource = data.Select(x => new SanPhamDTO
            {
                check = chiTietHoaDonDTOs.FirstOrDefault(y => y.MaSanPham == x.MaSanPham) != null,
                MaSanPham = x.MaSanPham,
                TenSanPham = x.TenSanPham,
                LoaiSanPham = x.LoaiSanPham,
                DonGia = x.DonGia,
                Mota = x.Mota,
                SoLuong = x.SoLuong
            }).ToList();
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            var data = grvSanPham.GetFocusedRow() as SanPhamDTO;
            var item = chiTietHoaDonDTOs.FirstOrDefault(x => x.MaSanPham == data.MaSanPham);
            if (item != null)
            {
                chiTietHoaDonDTOs.Remove(item);
            }
            else
            {
                if (data.TonKho > 0)
                {
                    chiTietHoaDonDTOs.Add(new ChiTietHoaDonDTO()
                    {
                        SoLuong = 1,
                        MaSanPham = data.MaSanPham,
                        DonGia = data.DonGia,
                        MaHoaDon = 0,
                        MaChiTietHoaDon = 0,
                        ThanhTien = data.DonGia
                    });
                }
                else
                {
                    MessageBox.Show("Số lượng sản phẩm đã hết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            Search();
            InitChiTietHoaDon();
        }

        private void grvChiTietHoaDon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "SoLuong")
            {
                var data = grvChiTietHoaDon.GetFocusedRow() as ChiTietHoaDonDTO;
                var item = chiTietHoaDonDTOs.FirstOrDefault(x => x.MaSanPham == data.MaSanPham);
                if (e.Value + "" == "0")
                {
                    chiTietHoaDonDTOs.Remove(item);
                    Search();
                }
                else
                {
                    var lsp = grcSanPham.DataSource as List<SanPhamDTO>;
                    var ctDAO = new ChiTietHoaDonDAO();
                    var spDAO = new SanPhamDAO();
                    var count = ctDAO.SoLuongByMaSanPham(data.MaSanPham ?? 0);
                    var sp = spDAO.GetBy((data.MaSanPham??0));
                    var kho = (sp.SoLuong ?? 0) - count;
                    if (int.Parse(e.Value + "") <= kho)
                    {
                        var sotien = int.Parse(e.Value + "") * data.DonGia;
                        item.ThanhTien = sotien;
                    }
                    else
                    {
                        var sotien = kho * data.DonGia;
                        item.SoLuong = kho;
                        item.ThanhTien = sotien;
                        MessageBox.Show("Số lượng sản phẩm chỉ còn " + kho + " sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                Search();
                InitChiTietHoaDon();
            }
        }

        private void txtAddProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                var spDAO = new SanPhamDAO();
                var ctDAO = new ChiTietHoaDonDAO();
                var data = spDAO.GetBy(int.Parse(txtAddProduct.Text.Trim()));
                var count = ctDAO.SoLuongByMaSanPham(data.MaSanPham);
                var kho = (data.SoLuong ?? 0) - count;
                var item = chiTietHoaDonDTOs.FirstOrDefault(x => x.MaSanPham == data.MaSanPham);
                if (item == null)
                {
                    if (kho > 0)
                    {
                        chiTietHoaDonDTOs.Add(new ChiTietHoaDonDTO()
                        {
                            SoLuong = 1,
                            MaSanPham = data.MaSanPham,
                            DonGia = data.DonGia,
                            MaHoaDon = 0,
                            MaChiTietHoaDon = 0,
                            ThanhTien = data.DonGia
                        });
                    }
                    else
                    {
                        MessageBox.Show("Số lượng sản phẩm đã hết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtAddProduct.Text = "";
                    txtAddProduct.Focus();
                }
                Search();
                InitChiTietHoaDon();
            }
        }
        public void TinhTong()
        {
            var soluong = chiTietHoaDonDTOs.Sum(x => x.SoLuong);
            var sotien = chiTietHoaDonDTOs.Sum(x => x.ThanhTien);
            decimal giamgia = 0;
            if (!string.IsNullOrEmpty(spGiamGia.EditValue + ""))
            {
                giamgia = decimal.Parse((spGiamGia.EditValue + "")) / decimal.Parse("100");
            }
            var tinhtong = sotien - (sotien * giamgia);
            txtSoLuong.Text = (soluong ?? 0).ToString("n0");
            txtSoTien.Text = (sotien ?? 0).ToString("n0");
            txtTong.Text = (tinhtong ?? 0).ToString("n0");
        }

        private void spGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (chiTietHoaDonDTOs.Count <= 0)
            {
                MessageBox.Show("Bạn chưa thêm sản phẩm?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTenKhachHang.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datachitiethoadon = new List<ChiTietHoaDon>();
            foreach (var item in chiTietHoaDonDTOs)
            {
                datachitiethoadon.Add(new ChiTietHoaDon
                {
                    MaSanPham = item.MaSanPham,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien
                });
            }
            var hoadon = new HoaDon();
            hoadon.MaHoaDon = MaHoaDon;
            hoadon.TenKhachHang = txtTenKhachHang.Text;
            hoadon.SoDienThoai = txtSoDienThoai.Text;
            hoadon.SoLuong = int.Parse(txtSoLuong.Text);
            hoadon.DiaChi = txtDiaChi.Text;
            hoadon.TongTien = decimal.Parse(txtTong.Text);
            if (!string.IsNullOrEmpty(spGiamGia.EditValue + ""))
            {
                hoadon.GiamGia = decimal.Parse((spGiamGia.EditValue + "")) / decimal.Parse("100");
            }
            //-- 1: Đã thanh toán, 0: chưa thanh toán
            hoadon.TrangThai = 1;
            hoadon.NgayLap = DateTime.Now;
            hoadon.MaTaiKhoan = username;
            var hdDAO = new HoaDonDAO();
            var mahoadon = hdDAO.Save(hoadon);
            if (mahoadon > 0)
            {
                MaHoaDon = mahoadon;
                datachitiethoadon.ForEach(x => x.MaHoaDon = mahoadon);
                var cthdDAO = new ChiTietHoaDonDAO();
                var res = cthdDAO.SaveRange(datachitiethoadon, mahoadon);
                if (res)
                {
                    MessageBox.Show("Tạo hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Tạo hóa đơn lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var hdDAO = new HoaDonDAO();
            var hoadon = hdDAO.GetBy(MaHoaDon);
            hoadon.TrangThai = 0;
            var mahoadon = hdDAO.Save(hoadon);
            if (mahoadon > 0)
            {
                MessageBox.Show("Cập nhật hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var frm = new FrmSanPham(0);
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Search();
            }
        }

        private void btnAddLoaiSanPham_Click(object sender, EventArgs e)
        {
            var frm = new FrmLoaiSanPham(0);
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadLoaiSanPham();
            }
        }

        
    }
}
