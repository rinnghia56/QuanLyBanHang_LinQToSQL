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
    public partial class FrmDanhMuc : Form
    {
        private bool chk = false;
        public FrmDanhMuc()
        {
            InitializeComponent();
        }
        public void hienThiToanBoDanhMuc()
        {
            lvDanhMuc.Items.Clear();
            foreach (DanhMuc sp in Function.Instance.getAllDanhMuc())
            {
                ListViewItem lvi = new ListViewItem(sp.MaDM);
                lvi.SubItems.Add(sp.TenDM);
                lvDanhMuc.Items.Add(lvi);
            }
        }
        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            hienThiToanBoDanhMuc();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhMuc.SelectedItems.Count == 0) return;
           
            ListViewItem lvi = lvDanhMuc.SelectedItems[0];
            txtMa.Text = lvi.SubItems[0].Text;
            txtTen.Text = lvi.SubItems[1].Text;
            if (lvDanhMuc.SelectedItems.Count > 1)
            {
                txtMa.Text = "";
                txtTen.Text = "";
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Neu ma Dm đã có=> update
            if (!Function.Instance.checkMaDM(txtMa.Text))
            {
                if (Function.Instance.updateDanhMuc(txtMa.Text, txtTen.Text))
                {
                    MessageBox.Show("Update thành công");
                    hienThiToanBoDanhMuc();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else //Nếu chưa có=> thêm mới
            {
                if(Function.Instance.insertNewDanhMuc(txtMa.Text, txtTen.Text))
                {
                    MessageBox.Show("Thêm mới thành công");
                    hienThiToanBoDanhMuc();
                    txtMa.Text = "";
                    txtTen.Text = "";
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhMuc.SelectedItems.Count == 0) {
                MessageBox.Show("Chọn danh mục cần xoá");
                return;
            }
            List<DanhMuc> dsDanhMucXoa = new List<DanhMuc>();
            foreach (ListViewItem lvi in lvDanhMuc.SelectedItems)
            {
                string maDM = lvi.SubItems[0].Text;
                dsDanhMucXoa.Add(Function.Instance.GetDanhMuc(maDM));
            }
            DanhMuc dm= Function.Instance.checkSanPhamTrongDM(dsDanhMucXoa);
            if ( dm== null)  //Nếu danh mục ko có sản phẩm nào=> cho xoá, còn có sản phẩm thì xoá sản phẩm trước.
            {
                if (Function.Instance.xoaDanhMuc(dsDanhMucXoa))
                {
                    MessageBox.Show("Xoá thành công");
                    hienThiToanBoDanhMuc();
                    txtMa.Text = "";
                    txtTen.Text = "";
                }
                else MessageBox.Show("Thất bại");
            }
            else
            {
                MessageBox.Show("Có sản phâm trong danh mục " + dm.TenDM+" ,bạn " +
                    "cần xoá sản phẩm trước");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int sttDanhMuc = Function.Instance.layThuTuCuaMaDM(lvDanhMuc.Items[lvDanhMuc.Items.Count - 1].SubItems[0].Text.Trim());
            txtMa.Text = Function.Instance.setMaDM(sttDanhMuc+1);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Hehe");
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUsername.Text != "")
                {
                    timKiemDanhMuc(txtUsername.Text);
                }
                else
                {
                    hienThiToanBoDanhMuc();
                }
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (!chk)
            {
                txtUsername.Text = "";
                chk = true;
            }
        }

        private void timKiemDanhMuc(String input)
        {
            if (input.ToUpper().Contains("DM"))
            {
                lvDanhMuc.Items.Clear();
                foreach (DanhMuc dm in Function.Instance.findDanhMucs_ma(input))
                {
                    ListViewItem lvi = new ListViewItem(dm.MaDM);
                    lvi.SubItems.Add(dm.TenDM);
                    lvDanhMuc.Items.Add(lvi);
                }  
            }
            else
            {
                lvDanhMuc.Items.Clear();
                foreach (DanhMuc dm in Function.Instance.findDanhMucs_name(input))
                {
                    ListViewItem lvi = new ListViewItem(dm.MaDM);
                    lvi.SubItems.Add(dm.TenDM);
                    lvDanhMuc.Items.Add(lvi);
                }
            }
                
        }

    }
}
