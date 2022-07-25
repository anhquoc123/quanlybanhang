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
    public partial class FrmMainForm : DevExpress.XtraEditors.XtraForm
    {
        public string username { get; set; }
        FrmPOS posform = null;
        FrmAdmin adminform = null;
        FrmOrder orderform = null;
        FrmReport reportform = null;

        public FrmMainForm()
        {
            InitializeComponent();
            flowLayoutPanel1.Location = new Point(
                this.ClientSize.Width / 2 - flowLayoutPanel1.Size.Width / 2,
                this.ClientSize.Height / 2 - flowLayoutPanel1.Size.Height / 2);
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            lbHello.Location = new Point(
                this.ClientSize.Width / 2 - flowLayoutPanel1.Size.Width / 2,
                flowLayoutPanel1.Location.Y - 39);
            lbHello.Anchor = AnchorStyles.None;
            GetLogin("", true);
        }
        private void GetLogin(string us, bool isClose)
        {
            //Khóa hết các button trên giao diện
            btnPOS.Enabled = btnOrder.Enabled = btnAdmin.Enabled = btnAccount.Enabled = btnReport.Enabled = false;
            //Tiến hành đăng nhập
            FrmLogin frm = new FrmLogin(us);
            if (!isClose)
            {
                frm.ShowInTaskbar = false;
                frm.ShowIcon = false;
            }
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                username = frm.username;
                var tkbase = new TaiKhoanDAO();
                var tk = tkbase.GetBy(username);
                //Gán lời chào
                lbHello.Text = "Xin chào: " + tk.HoTen + "!";
                //mở lại các button
                btnPOS.Enabled = btnOrder.Enabled = btnAccount.Enabled = true;
                //Nếu Group = 1 thì là admin
                //sẽ mở các button Admin và Report
                if (tk.Groups == 1)
                {
                    btnAdmin.Enabled = btnReport.Enabled = true;
                }
                else
                {
                    btnAdmin.Enabled = btnReport.Enabled = false;
                }
            }
            if (isClose && result == DialogResult.No)
            {
                if (Application.MessageLoop)
                    Application.Exit();
                else
                    Environment.Exit(1);
            }
        }
        private void btnPOS_Click(object sender, EventArgs e)
        {
            if (posform != null)
            {
                posform.BringToFront();
            }
            else
            {
                posform = new FrmPOS(username,0,false);
                posform.FormClosed += Frm_FormPOSClosed;
                posform.Show();
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            var accountform = new FrmAccount(username);
            var result = accountform.ShowDialog();
            if (result == DialogResult.OK)
            {
                var tkbase = new TaiKhoanDAO();
                var tk = tkbase.GetBy(username);
                lbHello.Text = "Xin chào: " + tk.HoTen + "!";
                btnAdmin.Enabled = tk.Groups == 1;
            }
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (adminform != null)
            {
                adminform.BringToFront();
            }
            else
            {
                adminform = new FrmAdmin(username);
                adminform.FormClosed += Frm_FormAdminClosed;
                adminform.Show();
            }
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (orderform != null)
            {
                orderform.BringToFront();
            }
            else
            {
                orderform = new FrmOrder();
                orderform.FormClosed += Frm_FormOrderClosed;
                orderform.Show();
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (reportform != null)
            {
                reportform.BringToFront();
            }
            else
            {
                reportform = new FrmReport();
                reportform.FormClosed += Frm_FormReportClosed;
                reportform.Show();
            }
        }
        private void Frm_FormReportClosed(object sender, FormClosedEventArgs e)
        {
            reportform = null;
        }
        private void Frm_FormOrderClosed(object sender, FormClosedEventArgs e)
        {
            orderform = null;
        }
        private void Frm_FormPOSClosed(object sender, FormClosedEventArgs e)
        {
            posform = null;
        }
        private void Frm_FormAdminClosed(object sender, FormClosedEventArgs e)
        {
            adminform = null;
            var tkbase = new TaiKhoanDAO();
            var tk = tkbase.GetBy(username);
            lbHello.Text = "Xin chào: " + tk.HoTen + "!";
            btnAdmin.Enabled = tk.Groups == 1;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (posform != null)
            {
                posform.Close();
            }
            if (adminform != null)
            {
                adminform.Close();
            }
            if (orderform != null)
            {
                orderform.Close();
            }
            if (reportform != null)
            {
                reportform.Close();
            }
            btnLock.Text = "Khóa";
            GetLogin(username, false);
        }

        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.BringToFront();
        }

    }
}