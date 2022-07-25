using DoAn.App.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.Model.DTO
{
    public class OrderDTO : HoaDon
    {
        public string HoTen { get; set; }
        public decimal GiamGiaTram
        {
            get
            {
                return (GiamGia ?? 0) * 100;
            }
        }
        public string TenTrangThai
        {
            get
            {
                return (TrangThai ?? 0) == 0 ? "Chưa thanh toán" : "Đã thanh toán";
            }
        }
    }
}
