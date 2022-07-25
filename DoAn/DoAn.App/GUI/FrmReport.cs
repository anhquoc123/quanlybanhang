using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DoAn.App.DAO;

namespace DoAn.App.GUI
{
    public partial class FrmReport : DevExpress.XtraEditors.XtraForm
    {
        public FrmReport()
        {
            InitializeComponent();
            dateStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,1);
            dateEnd.Value = DateTime.Now;
            Search();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.BringToFront();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {
            grcReport.DataSource = null;
            grcReport.Refresh();
            var rpDAO = new ReportDAO();
            var datestart = dateStart.Value;
            var dateend = dateEnd.Value;
            var data = rpDAO.GetAll(datestart, dateend).ToList();
            grcReport.DataSource = data;
        }
    }
}