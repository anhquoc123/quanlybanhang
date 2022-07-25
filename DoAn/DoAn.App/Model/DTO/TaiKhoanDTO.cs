using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.Model.DTO
{
    public class TaiKhoanDTO : TaiKhoan
    {
        public string Group { get { return Groups == 1 ? "Admin" : "Nhân viên"; } }
    }
}
