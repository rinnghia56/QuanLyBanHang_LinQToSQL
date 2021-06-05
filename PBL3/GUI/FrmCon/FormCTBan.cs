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
    public partial class FormCTBan : Form
    {
        string maHD = "";
        public FormCTBan(String ma)
        {
            InitializeComponent();
            maHD = ma;
        }

        private void FormCTBan_Load(object sender, EventArgs e)
        {
            ListViewItem lvi;
            listView1.Items.Clear();
            foreach (CT_HoaDon ct in Function.Instance.GetCT_HoaDonTheoMaHD(maHD))
            {
                lvi = new ListViewItem(Function.Instance.GetSanPham(ct.MaSP).TenSP);
                lvi.SubItems.Add(ct.SoLuong + "");
                lvi.SubItems.Add(ct.ThanhTien + "");
                listView1.Items.Add(lvi);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
