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
    public partial class FrmTaiKhoan : Form
    {
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            hienThiTaiKhoanLenListView(Function.Instance.getAllTaiKhoan());
            
        }
        private void hienThiTaiKhoanLenListView(List<TaiKhoan> dsTaiKhoan)
        {
            lvTaiKhoan.Items.Clear();
            dsTaiKhoan.ForEach(tk =>
            {
                ListViewItem lvi = new ListViewItem(tk.ID_TK);
                lvi.SubItems.Add(tk.HoTen);
                lvi.SubItems.Add(tk.SDT);
                lvi.SubItems.Add(tk.Username );
                lvi.SubItems.Add(tk.Password );
                lvi.SubItems.Add(tk.type + "");
                lvTaiKhoan.Items.Add(lvi);
            });
            lvTaiKhoan.Items[0].ForeColor = Color.Red;
        }

        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtUsername.ReadOnly == false) txtUsername.ReadOnly = true;
            if (lvTaiKhoan.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvTaiKhoan.SelectedItems[0];
            txtMa.Text = lvi.SubItems[0].Text.Trim();
            txtName.Text = lvi.SubItems[1].Text.Trim();
            txtSDT.Text = lvi.SubItems[2].Text.Trim();
            txtUsername.Text = lvi.SubItems[3].Text.Trim();
            txtPass.Text = lvi.SubItems[4].Text.Trim();
            if (lvi.SubItems[5].Text == "True") radYes.Checked = true;
            else radNo.Checked = true;
            if (lvTaiKhoan.SelectedItems.Count > 1)
            {
                txtMa.Text = "";
                txtName.Text = "";
                txtSDT.Text = "";
                txtUsername.Text = "";
                txtPass.Text = "";
                if (radNo.Checked == true) radNo.Checked = false;
                if (radYes.Checked == true) radYes.Checked = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtUsername.ReadOnly == true)
                txtUsername.ReadOnly = false;
            txtName.Text = "";
            txtSDT.Text = "";
            txtUsername.Text = "";
            txtPass.Text = "";
            if (radNo.Checked == false) radNo.Checked = true;

            string lastID = lvTaiKhoan.Items[lvTaiKhoan.Items.Count - 1].SubItems[0].Text.Trim();
            if (lastID == "ADMIN")
            {
                txtMa.Text = "NV001";
                return;
            }
            int sttTK = Function.Instance.layThuTuCuaMaTK(lvTaiKhoan.Items[lvTaiKhoan.Items.Count - 1].SubItems[0].Text.Trim());
            txtMa.Text = Function.Instance.setMaTK(sttTK + 1);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            bool type = false;
            if (radYes.Checked == true) type = true;
            
            //Nếu tài khoản chưa có
            if (!Function.Instance.checkMaTK(txtMa.Text))
            {
                if(Function.Instance.insertNewTaiKhoan(txtMa.Text, txtName.Text, txtSDT.Text, txtUsername.Text, txtPass.Text, type))
                {
                    MessageBox.Show("Thêm mới thành công");
                    hienThiTaiKhoanLenListView(Function.Instance.getAllTaiKhoan());
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }

            }
            else //Có rồi thì update
            {
                
                if (Function.Instance.updateTaiKhoan(txtMa.Text,txtName.Text,txtSDT.Text,txtPass.Text,type))
                {
                    MessageBox.Show("Update thành công");
                    hienThiTaiKhoanLenListView(Function.Instance.getAllTaiKhoan());
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn tài khoản cần xoá");
                return;
            }
            if (lvTaiKhoan.SelectedItems.Count >1 )
            {
                MessageBox.Show("Chỉ chọn 1 tài khoản để xoá");
                return;
            }
            string ma = lvTaiKhoan.SelectedItems[0].SubItems[0].Text.Trim();
            if (ma == "ADMIN")
            {
                MessageBox.Show("Không thể xoá tài khoản admin của hệ thống");
                return;
            }
            if (Function.Instance.isTaiKhoanUsed(ma))
            {
                MessageBox.Show("Ko thể xoá tài khoản này");
                return;
            }
            if (Function.Instance.deleteTaiKhoan(ma))
            {
                MessageBox.Show("Xoá thành công");
                hienThiTaiKhoanLenListView(Function.Instance.getAllTaiKhoan());
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
