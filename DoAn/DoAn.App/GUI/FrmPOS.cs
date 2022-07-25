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
using DevExpress.XtraTab;

namespace DoAn.App.GUI
{
    public partial class FrmPOS : DevExpress.XtraEditors.XtraForm
    {
        public string username { get; set; }
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOS));
        XtraTabPage TabAdd;
        List<int> matam;
        public FrmPOS(string us, int mahoadon, bool view)
        {
            InitializeComponent();
            username = us;
            var pages = xttabMain.TabPages;
            var tab = pages.FirstOrDefault(x => x.Name == "xtraTabPanel");
            TabAdd = tab;
            xttabMain.TabPages.Remove(tab);
            if (view)
            {
                var tabadd = pages.FirstOrDefault(x => x.Name == "xtraTabPanel");
                xttabMain.TabPages.Remove(tabadd);
                xttabMain.CustomHeaderButtons.RemoveAt(0);
            }
            matam = new List<int>();
            AddTab(mahoadon);
            if (!view)
            {
                AddTab(0);
            }
        }
        private void xttabMain_CloseButtonClick(object sender, EventArgs e)
        {
            var a = xttabMain.TabPages.Count();
            var xtra = sender as XtraTabControl;
            var pages = xttabMain.TabPages;
            var tabpage = pages.FirstOrDefault(x => x.Name == xtra.SelectedTabPage.Name);
            xttabMain.TabPages.Remove(tabpage);
            xttabMain.SelectedTabPageIndex = xttabMain.TabPages.Count - 1;
        }
        private void xttabMain_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            AddTab(0);
        }
        private int Marean()
        {
            var random = new Random();
            int stt = random.Next(1, 100);
            var item = matam.Count(x => x == stt);
            if (item > 1)
            {
                stt = Marean();
            }
            matam.Add(stt);
            return stt;
        }
        private void AddTab(int mahoadon)
        {
            var stt = Marean();
            var pages = xttabMain.TabPages;
            var tabnew = new XtraTabPage();
            ucPOS uc = new ucPOS(username, mahoadon, xtraTabPanel.Name + (pages.Count + 1) + "");
            tabnew.Text = TabAdd.Text;
            tabnew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPanel.ImageOptions.SvgImage")));
            tabnew.Name = xtraTabPanel.Name + stt + "";
            tabnew.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            xttabMain.TabPages.Add(tabnew);
            xttabMain.SelectedTabPageIndex = xttabMain.TabPages.Count - 1;
        }
        private void FrmPOS_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.BringToFront();
        }

        private void FrmPOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
