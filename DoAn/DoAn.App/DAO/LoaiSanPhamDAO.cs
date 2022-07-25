using DoAn.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    
    public class LoaiSanPhamDAO : BaseDAO
    {
        //Lấy tất cả dữ liệu loại sản phẩm trong database
        public List<LoaiSanPham> GetAll()
        {
            return db.LoaiSanPhams.ToList();
        }
        //Tìm kiếm dữ liệu trong LoaiSanPham trong database qua ký tự
        public List<LoaiSanPham> GetAll(string search)
        {
            return db.LoaiSanPhams.Where(x => x.TenLoai.Contains(search) || x.MoTa.Contains(search)).ToList();
        }
        //Lấy tất cả dữ liệu bằng LoaiSanPham trong database thông qua cột MaLoai
        public LoaiSanPham GetBy(int id)
        {
            return db.LoaiSanPhams.FirstOrDefault(x=>x.MaLoai == id);
        }
        //Hàm xóa
        public bool Delete(int MaLoai)
        {
            //Tìm loại sản phẩm thông qua maloai
            var lsp = GetBy(MaLoai);
            //Nếu tìm thấy
            if (lsp != null)
            {
                //Tiến hành xóa khỏi bảng LoaiSanPham
                db.LoaiSanPhams.Remove(lsp);
            }
            //Lưu lại
            return SaveToDb();
        }
        // Lưu loại sản phẩm vào bảng sản phẩm trong database
        public bool Save(LoaiSanPham item)
        {
            // Tìm loại sản phẩm thông qua maloai
            var check = GetBy(item.MaLoai);
           //Nếu có thì tiến hành sửa
            if (check != null)
            {
                check.TenLoai = item.TenLoai;
                check.MoTa = item.MoTa;
            }
            else
            //Không có thì thêmmới 
            {
                db.LoaiSanPhams.Add(item);
            }
            //Lưu lại
            return SaveToDb();
        }
    }
}
