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
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem lvi;
            foreach(HoaDon hd in Function.Instance.getAllHoaDon())
            {
                lvi = new ListViewItem(hd.MaHD);
                lvi.SubItems.Add(Function.Instance.getnameOfUser(hd.ID_TK));
                lvi.SubItems.Add(Convert.ToDateTime( hd.NgayLap).ToString("dd/MM/yyyy"));

                KhachHang kh = Function.Instance.GetKhach(hd.ID_KH);
                if (kh != null)
                {
                    lvi.SubItems.Add(kh.TenKH);

                }
                else
                {
                    lvi.SubItems.Add("");
                }

                lvi.SubItems.Add(hd.TongTien + "");
                listView1.Items.Add(lvi);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            decimal tong = 0;
            foreach (ListViewItem lv in listView1.Items)
            {
                tong += Convert.ToDecimal(lv.SubItems[4].Text.Trim());
            }
            txt_tong.Text = Math.Round(tong,2)+"";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem lvi;

            if(txtMa.Text == "")
            {
                foreach (HoaDon hd in Function.Instance.getHoaDonFromDateToDate(dt_ThgianTruoc.Value, dtThoiGianSau.Value))
                {
                    lvi = new ListViewItem(hd.MaHD);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(hd.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(hd.NgayLap).ToString("dd/MM/yyyy"));
                    KhachHang kh = Function.Instance.GetKhach(hd.ID_KH);
                    if (kh != null)
                    {
                        lvi.SubItems.Add(kh.TenKH);
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }
                    lvi.SubItems.Add(hd.TongTien + "");
                    listView1.Items.Add(lvi);
                }
                return;
            }
            if (txtMa.Text.Contains("HD"))
            {
                foreach (HoaDon hd in Function.Instance.GetHoaDonWithDateAndMaHD(dt_ThgianTruoc.Value, dtThoiGianSau.Value,txtMa.Text))
                {
                    lvi = new ListViewItem(hd.MaHD);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(hd.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(hd.NgayLap).ToString("dd/MM/yyyy"));
                    KhachHang kh = Function.Instance.GetKhach(hd.ID_KH);
                    if (kh != null)
                    {
                        lvi.SubItems.Add(kh.TenKH);
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }
                    lvi.SubItems.Add(hd.TongTien + "");
                    listView1.Items.Add(lvi);
                }
                return;
            }
            if (txtMa.Text.Contains("NV")||txtMa.Text.Equals("ADMIN"))
            {
                foreach (HoaDon hd in Function.Instance.GetHoaDonWithDateAndMaNV(dt_ThgianTruoc.Value, dtThoiGianSau.Value, txtMa.Text))
                {
                    lvi = new ListViewItem(hd.MaHD);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(hd.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(hd.NgayLap).ToString("dd/MM/yyyy"));
                    KhachHang kh = Function.Instance.GetKhach(hd.ID_KH);
                    if (kh != null)
                    {
                        lvi.SubItems.Add(kh.TenKH);
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }
                    lvi.SubItems.Add(hd.TongTien + "");
                    listView1.Items.Add(lvi);
                }
                return;
            }
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            lvPhieuNhap.Items.Clear();
            ListViewItem lvi;
            foreach (PhieuNhap pn in Function.Instance.getAllPhieuNhap())
            {
                lvi = new ListViewItem(pn.MaPhieuNhap);
                lvi.SubItems.Add(Function.Instance.getnameOfUser(pn.ID_TK));
                lvi.SubItems.Add(Convert.ToDateTime(pn.NgayNhap).ToString("dd/MM/yyyy"));
                lvPhieuNhap.Items.Add(lvi);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvPhieuNhap.Items.Clear();
            ListViewItem lvi;
            if (txtMa2.Text == "")
            {
                foreach (PhieuNhap pn in Function.Instance.getPhieuNhapFromDateToDate(dt_timeTruoc.Value, dt_TimeSau.Value))
                {
                    lvi = new ListViewItem(pn.MaPhieuNhap);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(pn.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(pn.NgayNhap).ToString("dd/MM/yyyy"));
                    lvPhieuNhap.Items.Add(lvi);
                }
            }
            if (txtMa2.Text.Contains("PN") )
            {
                foreach (PhieuNhap pn in Function.Instance.GetPhieuNhapWithDateAndMaPN(dt_timeTruoc.Value, dt_TimeSau.Value,txtMa2.Text))
                {
                    lvi = new ListViewItem(pn.MaPhieuNhap);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(pn.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(pn.NgayNhap).ToString("dd/MM/yyyy"));
                    lvPhieuNhap.Items.Add(lvi);
                }
            }
            if (txtMa2.Text.Contains("NV") || txtMa2.Text.Equals("ADMIN"))
            {
                foreach (PhieuNhap pn in Function.Instance.GetPhieuNhapWithDateAndMaNV(dt_timeTruoc.Value, dt_TimeSau.Value, txtMa2.Text))
                {
                    lvi = new ListViewItem(pn.MaPhieuNhap);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(pn.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(pn.NgayNhap).ToString("dd/MM/yyyy"));
                    lvPhieuNhap.Items.Add(lvi);
                }
            }
        }

        private void mnuXemCTBan_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            FormCTBan frm = new FormCTBan(listView1.SelectedItems[0].Text.Trim());
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void mnuXemChiTietNhap_Click(object sender, EventArgs e)
        {
            if (lvPhieuNhap.SelectedItems.Count == 0) return;

            FrmCTNhap frm = new FrmCTNhap(lvPhieuNhap.SelectedItems[0].Text.Trim());
            frm.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchMa_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem lvi;
            if (txtMa.Text == "")
            {
                return;
            }
            if (txtMa.Text.Contains("NV")|| txtMa.Text.Contains("ADMIN"))
            {
    
                foreach (HoaDon hd in Function.Instance.getHoaDonByMaNV(txtMa.Text))
                {
                    lvi = new ListViewItem(hd.MaHD);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(hd.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(hd.NgayLap).ToString("dd/MM/yyyy"));
                    KhachHang kh = Function.Instance.GetKhach(hd.ID_KH);
                    if (kh != null)
                    {
                        lvi.SubItems.Add(kh.TenKH);
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }
                    lvi.SubItems.Add(hd.TongTien + "");
                    listView1.Items.Add(lvi);
                }
                return;
            }
            if (txtMa.Text.Contains("HD"))
            {
                foreach (HoaDon hd in Function.Instance.getHoaDonByMaHD(txtMa.Text))
                {
                    lvi = new ListViewItem(hd.MaHD);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(hd.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(hd.NgayLap).ToString("dd/MM/yyyy"));
                    KhachHang kh = Function.Instance.GetKhach(hd.ID_KH);
                    if (kh != null)
                    {
                        lvi.SubItems.Add(kh.TenKH);
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }
                    lvi.SubItems.Add(hd.TongTien + "");
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            List<int> soChan = new List<int>();
            List<int> so = new List<int>();
            so.Add(1);
            so.Add(2);
            so.Add(3);
            so.Add(8);
            string s = "";
            soChan = so.Where(x => x % 2 == 0).ToList();
            foreach(int nb in soChan)
            {
                s += nb;
            }

            MessageBox.Show(txtMa.Text+"***");
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchMa2_Click(object sender, EventArgs e)
        {
            lvPhieuNhap.Items.Clear();
            ListViewItem lvi;
            if (txtMa2.Text.Contains("NV") || txtMa2.Text.Contains("ADMIN"))
            {
                foreach (PhieuNhap pn in Function.Instance.getPhieuNhapByMaNV(txtMa2.Text))
                {

                    lvi = new ListViewItem(pn.MaPhieuNhap);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(pn.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(pn.NgayNhap).ToString("dd/MM/yyyy"));
                    lvPhieuNhap.Items.Add(lvi);
                }
            }
            if (txtMa2.Text.Contains("PN"))
            {
                foreach (PhieuNhap pn in Function.Instance.getPhieuNhapByMaPN(txtMa2.Text))
                {
                    lvi = new ListViewItem(pn.MaPhieuNhap);
                    lvi.SubItems.Add(Function.Instance.getnameOfUser(pn.ID_TK));
                    lvi.SubItems.Add(Convert.ToDateTime(pn.NgayNhap).ToString("dd/MM/yyyy"));
                    lvPhieuNhap.Items.Add(lvi);
                }
            }
        }
    }
}
