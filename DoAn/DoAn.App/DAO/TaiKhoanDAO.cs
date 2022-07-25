using DoAn.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    public class TaiKhoanDAO: BaseDAO
    {
        //Lấy tất cả dữ liệu bẳng TaiKhoan trong database
        public List<TaiKhoan> GetAll()
        {
            return db.TaiKhoans.ToList();
        }
        //tìm kiếm dữ liệu trong bẳng TaiKhoan trong database qua ký tự
        public List<TaiKhoan> GetAll(string search)
        {
            return db.TaiKhoans.Where(x => x.TenDangNhap.Contains(search) || x.HoTen.Contains(search)).ToList();
        }
        //Lấy tất cả dữ liệu bẳng TaiKhoan trong database thông qua cột Group
        public List<TaiKhoan> GetAll(int role)
        {
            return db.TaiKhoans.Where(x => x.Groups == role).ToList();
        }
        //tìm kiếm dữ liệu trong bẳng TaiKhoan trong database qua ký tự và thông qua cột Group
        public List<TaiKhoan> GetAll(int role,string search)
        {
            return db.TaiKhoans.Where(x => x.Groups == role && (x.TenDangNhap.Contains(search) || x.HoTen.Contains(search))).ToList();
        }
        //Lấy thông tin tài khoản bởi tên đăng nhập để thao tắc xóa , sửa tài khoản được lấy lên
        public TaiKhoan GetBy(string tendangnhap)
        {
            return db.TaiKhoans.FirstOrDefault(x=>x.TenDangNhap == tendangnhap);
        }
        //Hàm xóa
        public bool Delete(string TenDangNhap)
        {
            //Tìm tài khoản trong database thông qua tendangnhap
            var tk = GetBy(TenDangNhap);
            //Nếu tìm thấy
            if (tk != null)
            {
                //Tiền hành xóa khỏi bẳng TaiKhoan
                db.TaiKhoans.Remove(tk);
            }
            //Lưu lại
            return SaveToDb();
        }
        //Lưu tài khoản vào bẳng taikhoan trong database
        public bool Save(TaiKhoan tknew)
        {
            //Tìm tài khoản trong database thông qua tendangnhap
            var tk = GetBy(tknew.TenDangNhap);
            //nếu có thì tiến hành sửa đổi
            if (tk != null)
            {
                tk.HoTen = tknew.HoTen;
                tk.MatKhau = tknew.MatKhau;
                tk.Groups = tknew.Groups;
            }
            //Không có thì thêm mới
            else
            {
                tknew.MatKhau = "1234567890";
                db.TaiKhoans.Add(tknew);
            }
            //Lưu lại
            return SaveToDb();
        }
    }
}
