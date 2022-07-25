using DoAn.App.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.Model.DTO
{
    public class SanPhamDTO : SanPham
    {
        public bool check { get; set; }
        public string TenLoai
        {
            get
            {
                var loaiDAO = new LoaiSanPhamDAO();
                return loaiDAO.GetBy(LoaiSanPham ?? 0) == null ? "" : loaiDAO.GetBy(LoaiSanPham ?? 0).TenLoai;
            }
        }
        public int TonKho
        {
            get
            {
                var loaiDAO = new SanPhamDAO();
                var item = loaiDAO.GetBy(MaSanPham);
                var cthoadon = new ChiTietHoaDonDAO();
                var counthd = cthoadon.SoLuongByMaSanPham(MaSanPham);
                return (item.SoLuong ?? 0) - counthd;
            }
        }
    }
}
