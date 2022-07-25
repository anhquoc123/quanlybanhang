using DoAn.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    public class SanPhamDAO: BaseDAO
    {
        //Lấy tất cả dữ liệu bằng sanpham trong database
        public List<SanPham> GetAll()
        {
            return db.SanPhams.ToList();
        }
        //tìm kiếm dữ liệu trong bảng SanPham trong database qua ký tự
        public List<SanPham> GetAll(string search)
        {
            return db.SanPhams.Where(x => x.TenSanPham.Contains(search) || x.Mota.Contains(search)).ToList();
        }
        // Lấy tất cả dữ liệu trong database thông qua cột Loại sản phẩm
        public List<SanPham> GetAll(int lsp)
        {
            return db.SanPhams.Where(x => x.LoaiSanPham == lsp).ToList();
        }
        //tìm kiếm dữ liệu trong bảng SanPham thông qua ký tự và thông quacột Loại sản phẩm
        public List<SanPham> GetAll(int lsp,string search)
        {
            return db.SanPhams.Where(x => x.LoaiSanPham == lsp && (x.TenSanPham.Contains(search) || x.Mota.Contains(search))).ToList();
        }
        //Lấy thông tin Sản phẩm bởi Mã sản phẩm để thao tác xóa sửa sản phẩm đc lấy lên
        public SanPham GetBy(int msp)
        {
            return db.SanPhams.FirstOrDefault(x=>x.MaSanPham == msp);
        }
        //Hàm xóa
        public bool Delete(int MaSanPham)
        {
            //tìm kiếm sản phẩm trong database thông qua mã sản phẩm
            var sp = GetBy(MaSanPham);
            //Nếu tìm thấy
            if (sp != null)
            {//tiến hành xóa khỏi bảng sản phẩm
                db.SanPhams.Remove(sp);
            }
            //Lưu lại 
            return SaveToDb();
        }
        //Hàm lưu
        public bool Save(SanPham spnew)
        {//tìm sản phẩm trong database thông qua mã sản phẩm
            var sp = GetBy(spnew.MaSanPham);
            //Nếy có thì tiến hành sửa đổi
            if (sp != null)
            {
                sp.TenSanPham = spnew.TenSanPham;
                sp.LoaiSanPham = spnew.LoaiSanPham;
                sp.Mota = spnew.Mota;
                sp.SoLuong = spnew.SoLuong;
                sp.DonGia = spnew.DonGia;
            }
            //không có thì thêm mới
            else
            {
                db.SanPhams.Add(spnew);
            }
            //Lưu lại
            return SaveToDb();
        }
    }
}
