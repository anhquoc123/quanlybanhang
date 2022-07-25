using DoAn.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    public class HoaDonDAO: BaseDAO
    {//Lấy tất cả dữ liệu bảng hóa đơn trong database
        public List<HoaDon> GetAll()
        {
            return db.HoaDons.ToList();
        }
        //Tìm kiém dữ liệu trong bảng hóa đơn thông qua ký tự 
        public List<HoaDon> GetAll(string search)
        {
            return db.HoaDons.Where(x => x.TenKhachHang.Contains(search) || x.SoDienThoai.Contains(search) || x.DiaChi.Contains(search)).ToList();
        }
        //Lấy tất cả theo khoảng ngày lập
        public List<HoaDon> GetAll(DateTime datestart, DateTime dateend)
        {
            //Câu query
            return db.Database.SqlQuery<HoaDon>("select * from HoaDon where cast(NgayLap as date) between '" + datestart.ToString("yyyy/MM/dd")+"' and '" + dateend.ToString("yyyy/MM/dd") + "' ").ToList();
        }
        //lấy thông tin hóa đơn bởi mã hóa đơn để tiến hành xóa sửa hóa đơn đc lấy lên

        public HoaDon GetBy(int mahoadon)
        {
            return db.HoaDons.FirstOrDefault(x=>x.MaHoaDon == mahoadon);
        }
        //Hàm lưu
        public int Save(HoaDon hdnew)
        {//tìm hóa đơn thông qua mã hóa đơn
            var hd = GetBy(hdnew.MaHoaDon);
            //Nếu có thì tiến hành lưu
            if (hd != null)
            {
                hd.TenKhachHang = hdnew.TenKhachHang;
                hd.SoDienThoai = hdnew.SoDienThoai;
                hd.DiaChi = hdnew.DiaChi;
                hd.GiamGia = hdnew.GiamGia;
                hd.TongTien = hdnew.TongTien;
                hd.TrangThai = hdnew.TrangThai;
                hd.SoLuong = hdnew.SoLuong;
            }
            //Nếu không thì tạo hóa đơn mới
            else
            {
                db.HoaDons.Add(hdnew);
            }
            //lưu lại 
            if (SaveToDb())
            {
                return hdnew.MaHoaDon;
            }
            return 0;
        }
    }
}
