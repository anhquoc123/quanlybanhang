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
using DoAn.App.Model.DTO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace DoAn.App.GUI
{
    public partial class FrmOrder : DevExpress.XtraEditors.XtraForm
    {
        public string username { get; set; }
        public FrmOrder()
        {
            InitializeComponent();
            Search();
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.BringToFront();
            dateStart.Value = dateEnd.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            grcHoaDon.DataSource = null;
            grcHoaDon.Refresh();
            var hdDAO = new HoaDonDAO();
            var tkDAO = new TaiKhoanDAO();
            var datestart = dateStart.Value;
            var dateend = dateEnd.Value;
            var data = hdDAO.GetAll(datestart, dateend).Select(x=> new OrderDTO()
            {
                MaHoaDon = x.MaHoaDon,
                TenKhachHang = x.TenKhachHang,
                SoDienThoai = x.SoDienThoai,
                DiaChi = x.DiaChi,
                NgayLap = x.NgayLap,
                MaTaiKhoan = x.MaTaiKhoan,
                HoTen = tkDAO.GetBy(x.MaTaiKhoan).HoTen,
                GiamGia = x.GiamGia,
                TongTien = x.TongTien,
                TrangThai = x.TrangThai
            }).ToList();
            grcHoaDon.DataSource = data;
            //GroupColumns(grvSanPham);

        }

        private void grvHoaDon_Click(object sender, EventArgs e)
        {
            grcChiTietHoaDon.DataSource = null;
            grcChiTietHoaDon.Refresh();
            var getdt = grvHoaDon.GetFocusedRow() as OrderDTO;
            if (getdt != null)
            {
                var cthdDAO = new ChiTietHoaDonDAO();
                var data = cthdDAO.GetAll(getdt.MaHoaDon).Select(x => new ChiTietHoaDonDTO()
                {
                    MaSanPham = x.MaSanPham,
                    MaHoaDon = x.MaHoaDon,
                    DonGia = x.DonGia,
                    MaChiTietHoaDon = x.MaChiTietHoaDon,
                    SoLuong = x.SoLuong,
                    ThanhTien = x.ThanhTien
                });
                grcChiTietHoaDon.DataSource = data;
            }
        }

        private void grvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            var getdt = grvHoaDon.GetFocusedRow() as OrderDTO;
            if (getdt != null)
            {
                var posform = new FrmPOS(username, getdt.MaHoaDon, true);
                posform.BringToFront();
                var result = posform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Search();
                }
            }
        }
    }
}