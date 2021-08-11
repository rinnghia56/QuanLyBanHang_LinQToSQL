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
    public partial class FrmNhapHang : Form
    {
        public delegate void SendMessage(string ID_taiKhoan);
        private static string IDTaiKhoan = "";
        public SendMessage Sender;
        private static bool chk = false;
        private void GetMessage(string ID_taiKhoanInput)
        {
            IDTaiKhoan = ID_taiKhoanInput;
        }
        public FrmNhapHang()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
        }
        private void setcbb()
        {
            cbbSanPham.DataSource = Function.Instance.getAllSanPham();
            cbbSanPham.ValueMember = "MaSP";
            cbbSanPham.DisplayMember = "TenSP";
            cbbSanPham.SelectedIndex = -1;
        }    
        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            setcbb();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Length > 1)
            {
                MessageBox.Show("Bạn chưa lưu phiếu nhập");
                return;
            }
            txtMaPN.Text = Function.Instance.CreateKey("PN");
            txtMaTK.Text = IDTaiKhoan.Trim();
            txtTenTK.Text = Function.Instance.getnameOfUser(IDTaiKhoan.Trim());
            dateTimePicker1.Value = DateTime.Now;
            txtTime.Text = dateTimePicker1.Value.ToString("MM/dd/yyyy  HH:mm:ss");
            chk = false;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lvsanpham.Items.Count == 0)
            {
                MessageBox.Show("Hãy thêm sản phẩm vào danh sách");
                return;
            }
            MessageBox.Show("Tạo mới phiếu nhập thành công");
            chk = false;
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Length < 1)
            {
                MessageBox.Show("Hạy tạo phiếu nhập");
                return;
            }
            if ((cbbSanPham.SelectedIndex == -1) || txtSoLuong.Text.Length < 1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return;
            }
            string masp = cbbSanPham.SelectedValue.ToString();
            
            foreach(ListViewItem i in lvsanpham.Items)
            {
                if(i.SubItems[0].Text == masp)
                {
                    MessageBox.Show("Sản phẩm này đã có trong danh sách, hãy cập nhật số lượng");
                    cbbSanPham.SelectedIndex = -1;
                    txtSoLuong.Text = "";
                    return;
                }
            }

            int soLuong;
            if(!Int32.TryParse(txtSoLuong.Text,out soLuong))
            {
                MessageBox.Show("Số lượng ko hợp lệ");
                txtSoLuong.Focus();
                return;
            }
           
             if (!Function.Instance.checkPhieuNhap(txtMaPN.Text)) //Nếu mã phiếu nhập chưa đc tạo
             {
                if(!Function.Instance.createPhieuNhap(txtMaPN.Text, txtMaTK.Text, dateTimePicker1.Value))
                {
                    MessageBox.Show("Lỗi");
                    return;
                }
             }
            ListViewItem lvi = new ListViewItem(masp);
            lvi.SubItems.Add(Function.Instance.GetSanPham(masp.Trim()).TenSP);
            lvi.SubItems.Add(txtSoLuong.Text);
            lvsanpham.Items.Add(lvi);
            
            if (!Function.Instance.creatCTPhieuNhap(txtMaPN.Text, cbbSanPham.SelectedValue.ToString().Trim(), txtSoLuong.Text))
            {
                MessageBox.Show("Lỗi");
                return;
            }
            chk = true;
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
        }

        

        private void hihiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Function.Instance.deletePhieuNhapCT(txtMaPN.Text, cbbSanPham.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Lỗi");
                return;
            }
            lvsanpham.Items.Remove(lvsanpham.SelectedItems[0]);
            txtSoLuong.Text="";


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(lvsanpham.SelectedItems.Count==0 || lvsanpham.SelectedItems.Count > 1)
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
                return;
            }

            lvsanpham.SelectedItems[0].SubItems[2].Text = txtSoLuong.Text;
            if (!Function.Instance.updatePhieuNhap(txtMaPN.Text, masp.Trim(), txtSoLuong.Text))
            {
                MessageBox.Show("Loi");
            }
            else
            {
                MessageBox.Show("Update thành công");
            }

        }

        private void lvsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvsanpham.SelectedItems.Count == 0 || lvsanpham.SelectedItems.Count>1) return;
            ListViewItem lvi = lvsanpham.SelectedItems[0];
            txtSoLuong.Text = lvi.SubItems[2].Text.Trim();
            cbbSanPham.SelectedValue = lvi.SubItems[0].Text;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!Function.Instance.checkPhieuNhap(txtMaPN.Text))
            {
                clear();
                return;
            }
            if (chk==false)
            {
                return;
            }
            if (Function.Instance.HuyNhapHang(txtMaPN.Text))
            {
                MessageBox.Show("Huỷ thành công");
                chk = false;
                clear();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
        private void clear()
        {
            txtMaPN.Text = "";
            txtMaTK.Text = "";
            txtTenTK.Text = "";
            lvsanpham.Items.Clear();
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtTime.Text = "";
        }
    }
}
