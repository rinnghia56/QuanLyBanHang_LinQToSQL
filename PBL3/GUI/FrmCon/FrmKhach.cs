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
    public partial class FrmKhach : Form
    {
        public FrmKhach()
        {
            InitializeComponent();
        }

        private void FrmKhach_Load(object sender, EventArgs e)
        {
            hienThiToanBokhachHang();
        }
        public void hienThiToanBokhachHang()
        {
            lvKhachHang.Items.Clear();
            foreach (KhachHang kh in Function.Instance.getAllKhachHang())
            {
                ListViewItem lvi = new ListViewItem(kh.ID_KH);
                lvi.SubItems.Add(kh.TenKH);
                lvi.SubItems.Add(kh.SDT);
                lvi.SubItems.Add(kh.DiemTichLuy + "");
                lvKhachHang.Items.Add(lvi);
            }
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            int sttKH = Function.Instance.layThuTuCuaMaDM(lvKhachHang.Items[lvKhachHang.Items.Count - 1].SubItems[0].Text.Trim());
            txtMa.Text = Function.Instance.setMaKH(sttKH + 1);
            txtDiem.Text = "0";
        }

        private void lvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKhachHang.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvKhachHang.SelectedItems[0];
            txtMa.Text = lvi.SubItems[0].Text;
            txtTen.Text = lvi.SubItems[1].Text;
            txtSDT.Text= lvi.SubItems[2].Text;
            txtDiem.Text= lvi.SubItems[3].Text;

            if (lvKhachHang.SelectedItems.Count > 1)
            {
                resetControl();
            }

        }
        private void resetControl()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtDiem.Text = "";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Length < 1 || txtSDT.Text.Length < 1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return;
            }
            if (Function.Instance.checkMaKH(txtMa.Text))
            {
                if (Function.Instance.updateKH(txtMa.Text, txtTen.Text, txtSDT.Text))
                {
                    MessageBox.Show("Cập nhật thành công");
                    hienThiToanBokhachHang();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else
            {
                if (Function.Instance.insertKhachHang(txtMa.Text, txtTen.Text, txtSDT.Text,Convert.ToInt32(txtDiem.Text)))
                {
                    MessageBox.Show("Thêm thành công");
                    hienThiToanBokhachHang();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvKhachHang.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn khách cần xoá");
                return;
            }
            List<KhachHang> dsKHXoa = new List<KhachHang>();
            foreach (ListViewItem lvi in lvKhachHang.SelectedItems)
            {
                string maKH = lvi.SubItems[0].Text;
                dsKHXoa.Add(Function.Instance.GetKhach(maKH));
            }
            if (Function.Instance.isKhUsed(dsKHXoa))
            {
                MessageBox.Show("Không thể xoá khách hàng này");
                return;
            }
            else
            {
                if (Function.Instance.xoaKH(dsKHXoa))
                {
                    MessageBox.Show("Xoá thành công");
                    hienThiToanBokhachHang();
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }
    }
}
