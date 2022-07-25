using DoAn.App.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.Model.DTO
{
    public class ChiTietHoaDonDTO: ChiTietHoaDon
    {
        public string TenSanPham
        {
            get
            {
                var spDAO = new SanPhamDAO();
                return spDAO.GetBy(MaSanPham ?? 0) == null ? "" : spDAO.GetBy(MaSanPham ?? 0).TenSanPham;
            }
        }
    }
}
