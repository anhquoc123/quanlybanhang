using DoAn.App.Model;
using DoAn.App.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.App.DAO
{
    public class ReportDAO: BaseDAO
    {
        public List<ReportDTO> GetAll(DateTime datestart, DateTime dateend)
        {
            return db.Database.SqlQuery<ReportDTO>(@"select 
            CAST(NgayLap as date) NgayLap,
            sum(case when TrangThai = 0 then SoLuong else 0 end) SoLuongNot,
            sum(case when TrangThai = 1 then SoLuong else 0  end) SoLuong,
            sum(case when TrangThai = 0 then TongTien else 0  end) [No],
            sum(case when TrangThai = 1 then TongTien else 0  end) [ThanhTien]
            from HoaDon hd 
            where CAST(NgayLap as date) between '" + datestart.ToString("yyyy/MM/dd")+"' and '" + dateend.ToString("yyyy/MM/dd") + "'" +
            "group by CAST(NgayLap as date)  ").ToList();
        }
    }
}
