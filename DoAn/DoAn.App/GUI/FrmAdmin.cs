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
using DoAn.App.Model;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DoAn.App.Model.DTO;
using DoAn.App.GUI.GUIEdit;

namespace DoAn.App.GUI
{
    public partial class FrmAdmin : DevExpress.XtraEditors.XtraForm
    {
        public string username { get; set; }
        private string currentname { get; set; }
        public FrmAdmin(string us)
        {
            username = us;
            InitializeComponent();
            InitializeMenuItems();
        }
        DXMenuItem[] menuItems;
        //Khởi tạo menu content động
        private void InitializeMenuItems()
        {
            DXMenuItem itemEdit = new DXMenuItem("Chỉnh sửa", ItemEdit_Click);
            DXMenuItem itemDelete = new DXMenuItem("Xóa", ItemDelete_Click);
            menuItems = new DXMenuItem[] { itemEdit, itemDelete };
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.BringToFront();
            var dataquyen = new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int, string>(1,"Admin"),
                new KeyValuePair<int, string>(2,"Nhân viên")
            };
            slRole.Properties.DataSource = dataquyen;
            slRole.Properties.DisplayMember = "Value";
            slRole.Properties.ValueMember = "Key";


            var loaiDAO = new LoaiSanPhamDAO();
            slLoaiSanPham.Properties.DataSource = loaiDAO.GetAll();
            slLoaiSanPham.Properties.DisplayMember = "TenLoai";
            slLoaiSanPham.Properties.ValueMember = "MaLoai";

            SearchUser();
            SearchLoaiSanPham();
            SearchSanPham();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            SearchUser();
        }
        public void SearchUser()
        {
            var role = slRole.EditValue + "";
            if (string.IsNullOrEmpty(role))
            {
                role = "0";
            }
            var text = (txtSearchUser.EditValue + "").Trim();
            var tkDAO = new TaiKhoanDAO();
            List<TaiKhoan> data = new List<TaiKhoan>();
            if (!string.IsNullOrEmpty(text) && int.Parse(role) > 0)
            {
                data = tkDAO.GetAll(int.Parse(role), text);
            }
            else if (!string.IsNullOrEmpty(text) && int.Parse(role) <= 0)
            {
                data = tkDAO.GetAll(text);
            }
            else if (string.IsNullOrEmpty(text) && int.Parse(role) > 0)
            {
                data = tkDAO.GetAll(int.Parse(role));
            }
            else if (string.IsNullOrEmpty(text) && int.Parse(role) <= 0)
            {
                data = tkDAO.GetAll();
            }
            grcTaiKhoan.DataSource = data.Select(x => new TaiKhoanDTO
            {
                TenDangNhap = x.TenDangNhap,
                HoTen = x.HoTen,
                Groups = x.Groups,
                MatKhau = x.MatKhau
            }).ToList();
        }

        private void btnSearchLoaiSanPham_Click(object sender, EventArgs e)
        {
            SearchLoaiSanPham();
        }
        public void SearchLoaiSanPham()
        {
            var text = (txtSearchLoaiSanPham.EditValue + "").Trim();
            var loaiDAO = new LoaiSanPhamDAO();
            List<LoaiSanPham> data = new List<LoaiSanPham>();
            if (!string.IsNullOrEmpty(text))
            {
                data = loaiDAO.GetAll(text);
            }
            else
            {
                data = loaiDAO.GetAll();
            }
            grcLoaiSanPham.DataSource = data.ToList();
        }

        private void btnSearchSanPham_Click(object sender, EventArgs e)
        {
            SearchSanPham();
        }
        public void SearchSanPham()
        {
            var lsp = slLoaiSanPham.EditValue + "";
            if (string.IsNullOrEmpty(lsp))
            {
                lsp = "0";
            }
            var text = (txtSearchSanPham.EditValue + "").Trim();
            var spDAO = new SanPhamDAO();
            List<SanPham> data = new List<SanPham>();
            if (!string.IsNullOrEmpty(text) && int.Parse(lsp) > 0)
            {
                data = spDAO.GetAll(int.Parse(lsp), text);
            }
            else if (!string.IsNullOrEmpty(text) && int.Parse(lsp) <= 0)
            {
                data = spDAO.GetAll(text);
            }
            else if (string.IsNullOrEmpty(text) && int.Parse(lsp) > 0)
            {
                data = spDAO.GetAll(int.Parse(lsp));
            }
            else if (string.IsNullOrEmpty(text) && int.Parse(lsp) <= 0)
            {
                data = spDAO.GetAll();
            }
            grcSanPham.DataSource = data.Select(x => new SanPhamDTO
            {
                MaSanPham = x.MaSanPham,
                TenSanPham = x.TenSanPham,
                LoaiSanPham = x.LoaiSanPham,
                DonGia = x.DonGia,
                Mota = x.Mota,
                SoLuong = x.SoLuong
            }).ToList();
        }
        private void ItemEdit_Click(object sender, System.EventArgs e)
        {
            if (currentname == "grvTaiKhoan")
            {
                var data = grvTaiKhoan.GetFocusedRow() as TaiKhoanDTO;

                var frm = new FrmUser(data.TenDangNhap);
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SearchUser();
                }
            }
            if (currentname == "grvLoaiSanPham")
            {
                var data = grvLoaiSanPham.GetFocusedRow() as LoaiSanPham;

                var frm = new FrmLoaiSanPham(data.MaLoai);
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SearchLoaiSanPham();
                }
            }
            if (currentname == "grvSanPham")
            {
                var data = grvSanPham.GetFocusedRow() as SanPhamDTO;
                var frm = new FrmSanPham(data.MaSanPham);
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SearchSanPham();
                }
            }
            currentname = "";
        }
        //Sự kiện xóa 
        private void ItemDelete_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                //trở về
                return;
            }
            //Con trỏ đang nằm trên tab grvTaiKhoan
            if (currentname == "grvTaiKhoan")
            {
                //Lấy dữ liệu của dòng đang click vào và kiểu nó thành TaiKhoanDTO
                var data = grvTaiKhoan.GetFocusedRow() as TaiKhoanDTO;
                //Kiểm tra tài khoản bị xóa có phải là tài khoản đang đăng nhập hay không
                if (data.TenDangNhap == username)
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    return;
                }
                //Khởi tạo TaiKhoanDAO để kết nối đến EntityFramework để thao tắc database
                var tkDAO = new TaiKhoanDAO();
                //Tiến hành xóa khỏi database
                var res = tkDAO.Delete(data.TenDangNhap);
                if (res)
                {
                    MessageBox.Show("Xóa tài khoản thành công?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Load lại lưới tài khoản
                SearchUser();
            }
            //xác định vị trí đang ở tab nào
            if (currentname == "grvLoaiSanPham")
            {
                // lấy dữ liệu từ dòng mà con chuột đang nhấp vào và ép kiểu nso về loại sản phẩm
                var data = grvLoaiSanPham.GetFocusedRow() as LoaiSanPham;
                //khởi tạo LoaiSanPhamDAO để kết nối với database
                var lspDAO = new LoaiSanPhamDAO();
                //Xóa khỏi database thông qua hàm được dựng sẳn bên LoaiSanPhamDAO
                var res = lspDAO.Delete(data.MaLoai);
                if (res)

                {
                    MessageBox.Show("Xóa loại sản phẩm thành công?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa loại sản phẩm thất bại?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SearchLoaiSanPham();
            }
            if (currentname == "grvSanPham")
            {
                var data = grvSanPham.GetFocusedRow() as SanPhamDTO;
                var lspDAO = new SanPhamDAO();
                var res = lspDAO.Delete(data.MaSanPham);
                if (res)
                {
                    MessageBox.Show("Xóa sản phẩm thành công?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SearchSanPham();
            }
            currentname = "";
        }
        private void PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                currentname = view.Name;
                foreach (DXMenuItem item in menuItems)
                    e.Menu.Items.Add(item);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new FrmUser("");
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                SearchUser();
            }
        }

        private void btnAddLoaiSanPham_Click(object sender, EventArgs e)
        {
            var frm = new FrmLoaiSanPham(0);
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                SearchLoaiSanPham();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var frm = new FrmSanPham(0);
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                SearchSanPham();
            }
        }
    }
}