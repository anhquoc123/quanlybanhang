using DoAn.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    public class ChiTietHoaDonDAO : BaseDAO
    {//Lấy tất cả dữ liệu trong bảng chi tiết hóa đơn trong database
        public List<ChiTietHoaDon> GetAll()
        {
            return db.ChiTietHoaDons.ToList();
        }
        //tìm kiém dữ liệu trong bảng chi tiết hóa đơn thông qua mã hóa đơn
        public List<ChiTietHoaDon> GetAll(int mhd)
        {
            return db.ChiTietHoaDons.Where(x => x.MaHoaDon == mhd).ToList();
        }
        //lấy thông tin chi tiết hóa đơn bởi mã chi tiết hóa đơn để tiến hành thao tác xóa sửa chi tiết hóa đơn đc lấy lên
        
        public ChiTietHoaDon GetBy(int machitiethoadon)
        {
            return db.ChiTietHoaDons.FirstOrDefault(x => x.MaChiTietHoaDon == machitiethoadon);
        }
        //Lấy tổng số lượng trong chi tiết hóa đơn bởi mã sản phẩm
        public int SoLuongByMaSanPham(int MaSanPham)
        {
            //Kiểm được chi tiết hóa đơn có chứa mã sản phẩm cần kiếm
            var data = db.ChiTietHoaDons.Where(x => x.MaSanPham == MaSanPham).ToList();
            //tiến hành cộng số lượng, nếu số lượng rỗng thì gắn bằng 0
            return data.Sum(x => x.SoLuong ?? 0);
        }
        //hàm lưu chi tiết hóa đơn
        public int Save(ChiTietHoaDon hdnew)
        {//tìm chi tiết hóa đơn thông qua mã chi tiết hóa đơn
            var hd = GetBy(hdnew.MaChiTietHoaDon);
            //Nếu có thì tiến hành sửa đổi
            if (hd != null)
            {
                hd.MaSanPham = hdnew.MaSanPham;
                hd.SoLuong = hdnew.SoLuong;
                hd.DonGia = hdnew.DonGia;
                hd.ThanhTien = hdnew.ThanhTien;
            }
            //Nếu không thì thêm mới
            else

            {
                db.ChiTietHoaDons.Add(hdnew);
            }
            //Lưu lại thành công
            if (SaveToDb())
            {
                //thì trả về mã của chi tiết hóa đơn đó
                return hdnew.MaChiTietHoaDon;
            }
            //không thành công thì trả về 0
            return 0;
        }
        //Lưu nhiều
        public bool SaveRange(List<ChiTietHoaDon> cths, int mhd)
        {
            //Lấy tất cả chitiethoadon bằng mã hóa đơn
            var data = GetAll(mhd);
            //nếu có
            if (data.Count > 0)
            {
                //xóa tất cả
                db.ChiTietHoaDons.RemoveRange(data);
            }
            //tiến hành lưu lại danh sách chi tiết hóa đơn
            db.ChiTietHoaDons.AddRange(cths);
            //lưu lại
            return SaveToDb();
        }
    }
}
