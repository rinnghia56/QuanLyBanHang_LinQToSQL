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
            txtMaPN.Text = Function.Instance.CreateKey("PN");
            txtMaTK.Text = IDTaiKhoan.Trim();
            txtTenTK.Text = Function.Instance.getnameOfUser(IDTaiKhoan.Trim());
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //if (txtMaPN.Text.Length < 1)
            //{
            //    MessageBox.Show("Hãy tạo mới phiếu nhập");
            //    return;
            //}
            //if ((cbbSanPham.SelectedIndex == -1) || txtSoLuong.Text.Length < 1)
            //{
            //    MessageBox.Show("Không được bỏ trống thông tin");
            //    return;
            //}
            //int a = 0;
            //if(!Int32.TryParse(txtSoLuong.Text,out a))
            //{
            //    MessageBox.Show("Thông tin ko hợp lệ");
            //    return;
            //}
            //MessageBox.Show(dateTimePicker1.Value.ToString());
            if (lvsanpham.Items.Count == 0)
            {
                MessageBox.Show("Hãy thêm sản phẩm vào danh sách");
                return;
            }
         
            MessageBox.Show("Tạo mới phiếu nhập thành công");
            txtMaPN.Text = "";
            txtMaTK.Text = "";
            txtTenTK.Text = "";
            lvsanpham.Items.Clear();
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
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
            cbbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void hihiToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            lvsanpham.SelectedItems[0].SubItems[2].Text=txtSoLuong.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            CT_PhieuNhap ct = Function.Instance.getCTPhieuNhap(txtMaPN.Text, lvsanpham.SelectedItems[0].SubItems[0].Text.Trim());
            MessageBox.Show(ct.MaPhieuNhap + ct.MaSP + ct.SoLuong);
        }
    }
}
