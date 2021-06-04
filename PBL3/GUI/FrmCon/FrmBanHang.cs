using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BusinessLogic;

namespace PBL3.GUI.FrmCon
{
    public partial class FrmBanHang : Form
    {
        public delegate void SendMessage(string ID_taiKhoan);
        private static string IDTaiKhoan = "";
        public SendMessage Sender;
        private void GetMessage(string ID_taiKhoanInput)
        {
            IDTaiKhoan = ID_taiKhoanInput;
        }
        public FrmBanHang()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Length < 2)
            {
                txtMaPN.Text = Function.Instance.CreateKey("HD");
                txtMaTK.Text = IDTaiKhoan.Trim();
                txtTenTK.Text = Function.Instance.getnameOfUser(IDTaiKhoan.Trim());
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                if (lvsanpham.Items.Count == 0)
                {
                    MessageBox.Show("Hãy thêm sản phẩm vào danh sách");
                    return;
                }
                decimal tongGia = Convert.ToDecimal(txtTong.Text);
                string maKH = null;
                if (txtMaKhach.Text.Length > 2) maKH = txtMaKhach.Text.Trim();
                if (!Function.Instance.updateHoaDonBan(txtMaPN.Text, tongGia, maKH))
                {
                    MessageBox.Show("Lỗi");
                    return;
                }
                MessageBox.Show("Lưu hoá đơn thành công");
                txtMaPN.Text = "";
                txtMaTK.Text = "";
                txtTenTK.Text = "";
                txtSdt.Text = "";
                txtMaKhach.Text = "";
                txtTenKhach.Text = "";
                lvsanpham.Items.Clear();
                cbbSanPham.SelectedIndex = -1;
                txtSoLuong.Text = "";
                txtTong.Text = "";
            }
        }
        private void setcbb()
        {
            cbbSanPham.DataSource = Function.Instance.getAllSanPham();
            cbbSanPham.ValueMember = "MaSP";
            cbbSanPham.DisplayMember = "TenSP";
            cbbSanPham.SelectedIndex = -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Length < 1)
            {
                MessageBox.Show("Hạy tạo hoá đơn");
                return;
            }
            if ((cbbSanPham.SelectedIndex == -1) || txtSoLuong.Text.Length < 1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return;
            }

            string masp = cbbSanPham.SelectedValue.ToString();

            foreach (ListViewItem i in lvsanpham.Items)
            {
                if (i.SubItems[0].Text == masp)
                {
                    MessageBox.Show("Sản phẩm này đã có trong danh sách, hãy cập nhật số lượng");
                    cbbSanPham.SelectedIndex = -1;
                    txtSoLuong.Text = "";
                    return;
                }
            }

            int soLuong;
            if (!Int32.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng ko hợp lệ");
                txtSoLuong.Focus();
                return;
            }

            if (!checkSlMua(masp.Trim(), soLuong))
            {
                MessageBox.Show("Trong kho chỉ còn " + Function.Instance.getSoLuongTon(cbbSanPham.SelectedValue.ToString().Trim()) + " sản phẩm này");
                return;
            }
            

            //Tạo hoá đơn
            if (!Function.Instance.checkHoaDon(txtMaPN.Text)) //Nếu hoá đơn chưa đc tạo thì tạo mới
            {
                if (!Function.Instance.createHoaDon(txtMaPN.Text, txtMaTK.Text, dateTimePicker1.Value))
                {
                    MessageBox.Show("Lỗi");
                    return;
                }
            }
             

            ListViewItem lvi = new ListViewItem(masp);
            SanPham sp = Function.Instance.GetSanPham(masp.Trim());
            decimal thanhTien = Function.Instance.getTongGiaSP(sp.MaSP, Convert.ToInt32(txtSoLuong.Text));
            lvi.SubItems.Add(sp.TenSP);
            lvi.SubItems.Add(txtSoLuong.Text);
            lvi.SubItems.Add(sp.GiaBan + "");
            lvi.SubItems.Add(thanhTien + "");
            lvsanpham.Items.Add(lvi);

            //Cập nhật tổng
            decimal tong = 0;
            foreach(ListViewItem lv in lvsanpham.Items)
            {
                tong += Convert.ToDecimal(lv.SubItems[4].Text.Trim());
            }

            //Tạo chi tiết hoá đơn
            if (!Function.Instance.creatCTHoaDon(txtMaPN.Text, cbbSanPham.SelectedValue.ToString().Trim(), txtSoLuong.Text,thanhTien))
            {
                MessageBox.Show("Lỗi");
                return;
            }

            txtTong.Text = Math.Round(tong, 2) + "";
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvsanpham.SelectedItems.Count == 0 || lvsanpham.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chọn 1 sản phẩm cần cập nhật");
                return;
            }
            int soLuong;
            if (!Int32.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng ko hợp lệ");
                txtSoLuong.Focus();
                return;
            }

            string masp = cbbSanPham.SelectedValue.ToString();
            bool check = false;
            foreach (ListViewItem i in lvsanpham.Items)
            {
                if (i.SubItems[0].Text == masp)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                MessageBox.Show("Sản phẩm này chưa có trong danh sách, thêm vào ds");
                MessageBox.Show(masp);
                return;
            }
            if (!checkSlMua(masp.Trim(), soLuong))
            {
                MessageBox.Show("Trong kho chỉ còn " + Function.Instance.getSoLuongTon(cbbSanPham.SelectedValue.ToString().Trim()) + " sản phẩm này");
                return;
            }
            decimal tong = 0;
            SanPham sp = Function.Instance.GetSanPham(masp.Trim());
            decimal thanhTien = Function.Instance.getTongGiaSP(sp.MaSP, Convert.ToInt32(txtSoLuong.Text));
            
            //Update ListView
            lvsanpham.SelectedItems[0].SubItems[2].Text = txtSoLuong.Text;
            lvsanpham.SelectedItems[0].SubItems[4].Text = thanhTien+"";

            //Update DB
            if (!Function.Instance.updateCTHoaDon(txtMaPN.Text, masp.Trim(), txtSoLuong.Text,thanhTien))
            {
                MessageBox.Show("Loi");
            }
            else
            {
                MessageBox.Show("Update thành công");
            }

            //Update txtTong
            foreach (ListViewItem lv in lvsanpham.Items)
            {
                tong += Convert.ToDecimal(lv.SubItems[4].Text.Trim());
            }
            txtTong.Text = Math.Round(tong, 2) + "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lvsanpham.Items.Count == 0)
            {
                MessageBox.Show("Hãy thêm sản phẩm vào danh sách");
                return;
            }
            decimal tongGia = Convert.ToDecimal(txtTong.Text);
            string maKH = null;
            
            if (txtMaKhach.Text.Length > 2) maKH = txtMaKhach.Text.Trim();
            if (!Function.Instance.updateHoaDonBan(txtMaPN.Text, tongGia, maKH))
            {
                MessageBox.Show("Lỗi");
                return;
            }
            
            //Tăng điểm cho khách
            Function.Instance.tangDiemKH(txtMaKhach.Text);

            MessageBox.Show("Tạo mới hoá đơn thành công");
            txtMaPN.Text = "";
            txtMaTK.Text = "";
            txtTenTK.Text = "";
            txtSdt.Text = "";
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            lvsanpham.Items.Clear();
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtTong.Text = "";
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            setcbb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            lvsanpham.Items.Remove(lvsanpham.SelectedItems[0]);
            txtSoLuong.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachHang kh = Function.Instance.getKhachBySDT(txtSdt.Text);
            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng này");
                return;
            }
            txtMaKhach.Text = kh.ID_KH;
            txtTenKhach.Text = kh.TenKH;
        }
        
        private bool checkSlMua(string maSP, int slmua)
        {
            int slTon = Function.Instance.getSoLuongTon(maSP);
            return (slmua <= slTon);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvsanpham.SelectedItems.Count == 0 || lvsanpham.SelectedItems.Count > 1) return;
            ListViewItem lvi = lvsanpham.SelectedItems[0];
            txtSoLuong.Text = lvi.SubItems[2].Text.Trim();
            cbbSanPham.SelectedValue = lvi.SubItems[0].Text;
        }
    }
}
