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
    public partial class FrmCTNhap : Form
    {
        string maPhieuNhap = "";
        public FrmCTNhap(string maPN)
        {
            InitializeComponent();
            maPhieuNhap = maPN;
        }

        private void FrmCTNhap_Load(object sender, EventArgs e)
        {
            ListViewItem lvi;
            listView1.Items.Clear();
            foreach (CT_PhieuNhap ct in Function.Instance.GetCT_PhieuNhapTheoMaPN(maPhieuNhap))
            {
                lvi = new ListViewItem(Function.Instance.GetSanPham(ct.MaSP).TenSP);
                lvi.SubItems.Add(ct.SoLuong + "");
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
