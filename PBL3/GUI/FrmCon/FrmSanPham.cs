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
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            hienThiDanhMucLenListBox();
            lbDanhMuc.SelectedIndex = -1;
            btnAll.PerformClick();
            setDataCombobox();
        }

        bool isFinishedForListBox = false;
        private void hienThiDanhMucLenListBox()
        {
            lbDanhMuc.DataSource = Function.Instance.getAllDanhMuc();
            lbDanhMuc.ValueMember = "MaDM";
            lbDanhMuc.DisplayMember = "TenDM";
            isFinishedForListBox = true;
        }

        private void lbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFinishedForListBox) return;//Chưa tải xong dữ liệu lên listbox
            if (lbDanhMuc.SelectedValue == null) return; //Chưa chọn danh mục trên listbox
            string maDm = lbDanhMuc.SelectedValue.ToString();
            hienThiSanPhamLenListView(SearchSanPham(getMaDMfromListBox(), txtSearch.Text));
            //hienThiSanPhamLenListView(Function.Instance.GetListSanPhamsByDM(maDm));
        }
        private void hienThiSanPhamLenListView(List<SanPham>dsSanPhams)
        {
            lvSanPham.Items.Clear();
            dsSanPhams.ForEach(sp =>
            {
                ListViewItem lvi = new ListViewItem(sp.MaSP);
                lvi.SubItems.Add(sp.TenSP);
                lvi.SubItems.Add(sp.MaDM);
                lvi.SubItems.Add(sp.SLTon + "");
                lvi.SubItems.Add(sp.GiaBan + "");
                lvSanPham.Items.Add(lvi);
            });
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetControl();
            int sttSanPham = Function.Instance.layThuTuCuaMaDM(lvSanPham.Items[lvSanPham.Items.Count - 1].SubItems[0].Text.Trim());
            txtMa.Text = Function.Instance.setMaSP(sttSanPham + 1);
            txtSoLuong.Text = 0+"";
        }

        private void lvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count == 0) return;

            ListViewItem lvi = lvSanPham.SelectedItems[0];
            txtMa.Text = lvi.SubItems[0].Text;
            txtTen.Text = lvi.SubItems[1].Text;
            cbbDanhMuc.SelectedValue = lvi.SubItems[2].Text;
            txtSoLuong.Text = lvi.SubItems[3].Text;
            txtDonGia.Text = lvi.SubItems[4].Text;
            if (lvSanPham.SelectedItems.Count > 1)
            {
                resetControl();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienThiSanPhamLenListView(Function.Instance.getAllSanPham());
            lbDanhMuc.SelectedIndex = -1;
            resetControl();
        }

        private void setDataCombobox()
        {
            cbbDanhMuc.DataSource = Function.Instance.getAllDanhMuc();
            cbbDanhMuc.ValueMember = "MaDM";
            cbbDanhMuc.DisplayMember = "TenDM";
            cbbDanhMuc.SelectedIndex = -1;
        }

        
        private void resetControl()
        {
            txtDonGia.Text = "";
            txtMa.Text = "";
            txtSoLuong.Text = "";
            txtTen.Text = "";
            cbbDanhMuc.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool checkValidSoLuong = false;
            bool checkValidGiaBan = false;
            
            int soLuong;
            checkValidSoLuong = Int32.TryParse(txtSoLuong.Text, out soLuong);
            decimal giaBan;
            checkValidGiaBan = Decimal.TryParse(txtDonGia.Text, out giaBan);

            if(txtTen.Text.Length<1 || cbbDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return;
            }
            string maDM = cbbDanhMuc.SelectedValue.ToString().Trim();
            if ((!checkValidGiaBan) || (!checkValidSoLuong))
            {
                MessageBox.Show("Vui lòng điền thông tin hợp lệ");
                return;
            }

            if (!Function.Instance.checkMaSP(txtMa.Text))  //Nếu mã sp chưa tồn tại
            {
                if (Function.Instance.insertSanPham(txtMa.Text, txtTen.Text, maDM, soLuong, giaBan))
                {
                    MessageBox.Show("Thêm thành công");
                    btnAll.PerformClick();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else
            {
                if (Function.Instance.updateSanPham(txtMa.Text, txtTen.Text, maDM, soLuong, giaBan))
                {
                    MessageBox.Show("Update thành công");
                    btnAll.PerformClick();
                }
                else MessageBox.Show("Thất bại");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn sản phẩm cần xoá");
                return;
            }

            List<SanPham> dsSsanPhamXoa = new List<SanPham>();
            foreach (ListViewItem lvi in lvSanPham.SelectedItems)
            {
                string maSP = lvi.SubItems[0].Text;
                dsSsanPhamXoa.Add(Function.Instance.GetSanPham(maSP));
            }

            
            if (!Function.Instance.isSanPhamUsed(dsSsanPhamXoa))
            {
                if (Function.Instance.xoaSanPham(dsSsanPhamXoa))
                {
                    MessageBox.Show("Xoá thành công");
                    btnAll.PerformClick();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else
            {
                MessageBox.Show("Không thể xoá sản phẩm này, chỉ có thể cập nhật số lượng về 0");
                if (!Function.Instance.capNhatSanPhamXoa(dsSsanPhamXoa)) MessageBox.Show("Lỗi");
                else btnAll.PerformClick();
            }
        }

        private string getMaDMfromListBox()
        {
            if (lbDanhMuc.SelectedIndex == -1)
            {
                return null;
            }
            else return lbDanhMuc.SelectedValue.ToString().Trim();
        }

        //Hiển thị sản phẩm theo listbox danh mục và textbox sản phẩm
        private List<SanPham> SearchSanPham(string maDmInput, string nameSpInput)
        {
            List<SanPham> dsSpReturn = new List<SanPham>();
            if(maDmInput == null) //Chọn tất cả danh mục  
            {
                if (nameSpInput == null || nameSpInput == "") //KO nhập gì vào ô tìm kiếm
                    return Function.Instance.getAllSanPham();
                else //Nhập vào ô tìm kiếm
                {
                    foreach (SanPham sp in Function.Instance.getAllSanPham())
                    {
                        if (sp.TenSP.ToLower().Contains(nameSpInput))
                        {
                            dsSpReturn.Add(sp);
                        }
                    }
                }
            }

            else  //Chọn danh mục nào đó bên listbox
            {
                if (nameSpInput == null || nameSpInput == "") 
                {
                    return Function.Instance.GetListSanPhamsByDM(maDmInput);
                }
                else
                {
                    foreach(SanPham sp in Function.Instance.GetListSanPhamsByDM(maDmInput))
                    {
                        if(sp.TenSP.ToLower().Contains(nameSpInput) )
                        {
                            dsSpReturn.Add(sp);
                        }
                    }
                }
            }
            return dsSpReturn;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            hienThiSanPhamLenListView(SearchSanPham(getMaDMfromListBox(), txtSearch.Text));
        }
        
    }
}
