﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BusinessLogic;
using PBL3.GUI.FrmCon;

namespace PBL3.GUI
{
    public partial class FrmMain : Form
    {
  
        public delegate void SendMessage(string ID_taiKhoan,bool UserRight);
        private static string IDTaiKhoan = "";
        private static bool UserRight = false;
        public SendMessage Sender;
        private Form currentchildform;

        private void GetMessage(string ID_taiKhoanInput, bool userRightInput)
        {
            IDTaiKhoan = ID_taiKhoanInput;
            UserRight = userRightInput;
        }
        public FrmMain()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
        }

        //Chuyển màu button khi click
        private void clickButton(Panel pn1, Panel pn2, Panel pn3, Panel pn4)
        {
            if (pn1.Visible == false) pn1.Visible = true;
            pn2.Visible = false;
            pn3.Visible = false;
            pn4.Visible = false;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            pnChay.Visible = false;
            pnChay.Height = btnBan.Height;
            pnChay_Danhmuc.Visible = false;
            pnChay_Kho.Visible = false;
            pnChay_SP.Visible = false;
            pnbtnKho.Height = 50;

            //Set label theo tên của tài khoản đăng nhập
            lblTenTaiKhoan.Text = Function.Instance.getnameOfUser(IDTaiKhoan);
        }
       
        private void motrangcon(Form trangcon)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();
            }
            currentchildform = trangcon;
            trangcon.TopLevel = false;
            trangcon.Dock = DockStyle.Fill;
            panelFormCon.Controls.Add(trangcon);
            panelFormCon.Tag = trangcon;
            trangcon.BringToFront();
            trangcon.Show();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnBan.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            motrangcon(new FrmBanHang());
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnNhap.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            FrmNhapHang frm = new FrmNhapHang();
            frm.Sender(IDTaiKhoan);
           motrangcon(frm);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnTaiKhoan.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            motrangcon(new FrmTaiKhoan());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnThongKe.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            //motrangcon(new FrmThongKe());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            clickButton(pnChay, pnChay_Danhmuc, pnChay_Kho, pnChay_SP);
            pnChay.Top = btnKhachHang.Top;
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            motrangcon(new FrmKhach());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            clickButton(pnChay_Kho, pnChay, pnChay_Danhmuc, pnChay_SP);
            if (pnbtnKho.Height == 151) pnbtnKho.Height = 50;
            else pnbtnKho.Height = 151;
        }
       
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            clickButton(pnChay_SP, pnChay, pnChay_Danhmuc, pnChay_Kho);
            motrangcon(new FrmSanPham());
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if (pnChay_Danhmuc.Visible == false) pnChay_Danhmuc.Visible = true;
            pnChay.Visible = false;
            pnChay_SP.Visible = false;
            pnChay_Kho.Visible = false;
            clickButton(pnChay_Danhmuc, pnChay, pnChay_SP, pnChay_Kho);

            motrangcon(new FrmDanhMuc());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmLogin().Show();
        }

      

        private void panelFormCon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
