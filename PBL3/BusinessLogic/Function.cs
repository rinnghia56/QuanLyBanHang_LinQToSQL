using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BusinessLogic
{
    public class Function
    {
        private DoAnPBL3Entities1 db=new DoAnPBL3Entities1();

        public static Function _Instance;
        public static Function Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Function();
                return _Instance;
            }
        }
        private Function() { }
        public TaiKhoan checkValidAccount(string usernInput, string passInput)
        {
            //DoAnPBL3Entities1 db = new DoAnPBL3Entities1();
            TaiKhoan tkReturn = db.TaiKhoans.FirstOrDefault(tk => tk.Username == usernInput && tk.Password == passInput);
            return tkReturn;
        }

        public string getnameOfUser(string ID_TaiKhoanInput)
        {
            //db = new DoAnPBL3Entities1();
            TaiKhoan tkReturn = db.TaiKhoans.FirstOrDefault(x => x.ID_TK == ID_TaiKhoanInput);
            return tkReturn.HoTen;
        }

        public List<DanhMuc> getAllDanhMuc()
        {
            return db.DanhMucs.ToList();
        }

        //Lấy tài khoản từ mã tài khoản
        public DanhMuc GetDanhMuc(string maDM_InPut)
        {
            DanhMuc dm = db.DanhMucs.FirstOrDefault(x => x.MaDM == maDM_InPut);
            return dm;
        }
        public bool updateDanhMuc(string maDM_InPut, string nameDM_Input)
        {
            DanhMuc dm = Function.Instance.GetDanhMuc(maDM_InPut);
            if (dm != null)
            {
                try
                {
                    dm.MaDM = maDM_InPut;
                    dm.TenDM = nameDM_Input;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool xoaDanhMuc(List<DanhMuc> dsInput)
        {
            try {
                    db.DanhMucs.RemoveRange(dsInput);
                    db.SaveChanges();
                    return true;
            }
            catch
            {
                return false;
            }
            
        }

        //Kiểm tra danh mục có sản phẩm nào ko
        public DanhMuc checkSanPhamTrongDM(List<DanhMuc> dsInput)
        {
            foreach(DanhMuc dm in dsInput)
            {
                if (dm.SanPhams.Count > 0) return dm;
            }
            return null;
        }

        //Set maDm dạng DM001,DM002
        public string setMaDM(int valueInput)
        {
            if(valueInput>0 && valueInput  <= 9)
            {
                return "DM00" + valueInput;
            }
            if(valueInput > 9 && valueInput <=99 ) return "DM0" + valueInput;
            return "DM" + valueInput;
        }

        //Lấy mã của danh mục cuối cùng, tách lấy số rồi trả về gí trị đó
        public int layThuTuCuaMaDM(string maInPut)
        {
            string chuoiCon = maInPut.Substring(2);
            int thuTuMa = 0;
            do
            {
                if (!Int32.TryParse(chuoiCon, out thuTuMa))
                {
                    chuoiCon = maInPut.Substring(1);
                }

            } while (!Int32.TryParse(chuoiCon, out thuTuMa));
            return thuTuMa;
        }



        //Thêm mới 1 danh mục
        public bool insertNewDanhMuc(string maInput,string nameInput)
        {
            try
            {
                db.DanhMucs.Add(new DanhMuc()
                {
                    MaDM = maInput,
                    TenDM = nameInput,
                });
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        //Check maDM đã tồn tại chưa
        public bool checkMaDM(String maInput)
        {
            if (GetDanhMuc(maInput) != null)
            {
                return false;
            }
            return true;
        }

       //=================================Sản phẩm==============

        //Lấy danh sách có mã danh mục là ...
       public List<SanPham> GetListSanPhamsByDM(string maDmInput)
       {
            List<SanPham> dsSP = db.SanPhams
                .Where(sp => sp.MaDM == maDmInput).ToList();
            return dsSP;
       }
        public SanPham GetSanPham(string maSP_InPut)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.MaSP == maSP_InPut);
            return sp;
        }
        public List<SanPham> getAllSanPham()
        {
            return db.SanPhams.ToList();
        }

        //Set maSP dạng SP0001,SP0002
        public string setMaSP(int valueInput)
        {
            if (valueInput > 0 && valueInput <= 9)
            {
                return "SP000" + valueInput;
            }
            if (valueInput > 9 && valueInput <= 99) return "SP00" + valueInput;
            if (valueInput > 99 && valueInput <= 999) return "SP0" + valueInput;
            return "SP" + valueInput;
        }
        public bool checkMaSP(String maInput) //Kiểm tra mã sp đã có chưa
        {
            return db.SanPhams.Any(sp => sp.MaSP == maInput); //return true neu có
        }
        public bool insertSanPham(string maspInput, string nameInput, string maDanhmucInput, int soLuongInput, decimal giaInput)
        {
            try
            {
                db.SanPhams.Add(new SanPham()
                {
                    MaSP = maspInput,
                    TenSP = nameInput,
                    MaDM = maDanhmucInput,
                    SLTon = soLuongInput,
                    GiaBan = giaInput
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateSanPham(string maspInput, string nameInput, string maDanhmucInput, int soLuongInput, decimal giaInput)
        {
            SanPham sp = GetSanPham(maspInput);
            if (sp != null)
            {
                try
                {
                    {
                        sp.TenSP = nameInput;
                        sp.MaDM = maDanhmucInput;
                        sp.SLTon = soLuongInput;
                        sp.GiaBan = giaInput;
                        db.SaveChanges();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;  
        }
       
        public bool isSanPhamUsed(List<SanPham> dsInput) //check xem sản phẩm đã đc bán hay nhập mới chưa
        {
            foreach (SanPham sp in dsInput)
            {
                if(db.CT_HoaDon.Any(x => x.MaSP == sp.MaSP)==true || db.CT_PhieuNhap.Any(x => x.MaSP == sp.MaSP) == true) return true;
            }
            return false;
        }
        public bool xoaSanPham(List<SanPham> dsInput)
        {
            try
            {
                db.SanPhams.RemoveRange(dsInput);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Những sản phẩm ko xoá đc thì cho số lượng tồn về 0
        public bool capNhatSanPhamXoa(List<SanPham> dsInput)
        {
            try
            {
                dsInput.ForEach(sp =>
                {
                    sp.SLTon = 0;
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //========================Khách hàng===================
        public List<KhachHang> getAllKhachHang()
        {
            return db.KhachHangs.ToList();
        }
        public bool checkMaKH(string maInput)
        {
            return db.KhachHangs.Any(sp => sp.ID_KH == maInput);
        }
        public string setMaKH(int valueInput)
        {
            if (valueInput > 0 && valueInput <= 9)
            {
                return "KH000" + valueInput;
            }
            if (valueInput > 9 && valueInput <= 99) return "KH00" + valueInput;
            if (valueInput > 99 && valueInput <= 999) return "KH0" + valueInput;
            return "KH" + valueInput;
        }
        public bool insertKhachHang(string maInput, string nameInput, string sdt, int diem)
        {
            try
            {
                db.KhachHangs.Add(new KhachHang()
                {
                    ID_KH=maInput,
                    TenKH=nameInput,
                    SDT=sdt,
                    DiemTichLuy = diem
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public KhachHang GetKhach(string maInPut)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(x => x.ID_KH == maInPut);
            return kh;
        }

        public bool updateKH(string maInput, string nameInput, string sdt)
        {
            KhachHang kh = GetKhach(maInput);
            if (kh != null)
            {
                try
                {
                    kh.TenKH = nameInput;
                    kh.SDT = sdt;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool xoaKH(List<KhachHang> dsInput)
        {
            try
            {
                db.KhachHangs.RemoveRange(dsInput);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool isKhUsed(List<KhachHang> dsInput) //Check khach hàng đã mua từng mua hàng chưa
        {
            //Nếu trong danh sách khách hàng có 1 khách hàng với điểm lớn hơn 0  thì trả về true
            return (dsInput.Any(kh => kh.DiemTichLuy > 0));  
        }
        //=======================Tai khoan=============================
        public List<TaiKhoan> getAllTaiKhoan()
        {
            return db.TaiKhoans.ToList();
        }
        public int layThuTuCuaMaTK(string maInPut)
        {
            string chuoiCon = maInPut.Substring(2);
            int thuTuMa = 0;
            do
            {
                if (!Int32.TryParse(chuoiCon, out thuTuMa))
                {
                    chuoiCon = maInPut.Substring(1);
                }

            } while (!Int32.TryParse(chuoiCon, out thuTuMa));
            return thuTuMa;
        }
        public string setMaTK(int valueInput)
        {
            if (valueInput > 0 && valueInput <= 9)
            {
                return "NV00" + valueInput;
            }
            if (valueInput > 9 && valueInput <= 99) return "NV0" + valueInput;
            return "NV" + valueInput;
        }
        public bool insertNewTaiKhoan(string maInput, string nameInput,string sdtInput, string username, string pass,bool typeInput)
        {
            try
            {
                db.TaiKhoans.Add(new TaiKhoan()
                {
                    ID_TK = maInput,
                    HoTen =nameInput,
                    SDT = sdtInput,
                    Username = username,
                    Password=pass,
                    type=typeInput
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool checkMaTK(string maInput)
        {
            return db.TaiKhoans.Any(tk => tk.ID_TK == maInput);
        }

        private TaiKhoan getTaiKhoan(string maTK) 
        {
            TaiKhoan tk = db.TaiKhoans.FirstOrDefault(x => x.ID_TK == maTK);
            return tk;
        }

        public bool updateTaiKhoan(string maInput, string tenTK, string sdt,string pass,bool type)
        {
            TaiKhoan tk = getTaiKhoan(maInput);
            if (tk != null)
            {
                try
                {
                    tk.HoTen = tenTK;
                    tk.SDT = sdt;
                    tk.Password = pass;
                    tk.type = type;

                    db.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            return false;
        }

        //Kiểm tra tài khoản này đã được dùng để nhập haowcj bán hàng chưa
        public bool isTaiKhoanUsed(string ma)
        {
            if (db.PhieuNhaps.Any(pn => pn.ID_TK == ma)) return true;//Nếu có ma TK trong danh sách phiếu nhập
            if (db.HoaDons.Any(hd => hd.ID_TK == ma))
                return true;//Nếu có ma TK trong danh sách hoá đơn
            return false;
        }
        public bool deleteTaiKhoan(string maInput)
        {
            TaiKhoan tk = getTaiKhoan(maInput);
            if (tk != null)
            {
                try
                {
                    db.TaiKhoans.Remove(tk);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        //=========================Nhập hàng=================
        private PhieuNhap getPN(string mapn)
        {
            if (!checkPhieuNhap(mapn)) return null;
            return db.PhieuNhaps.FirstOrDefault(pn => pn.MaPhieuNhap == mapn);
        }
        private CT_PhieuNhap getCTPN(string maphieu)
        {
            CT_PhieuNhap ct = db.CT_PhieuNhap.FirstOrDefault(x => (x.MaPhieuNhap == maphieu));
            return ct;
        }
        public bool HuyNhapHang(String maPn)
        {
            try
            {
                CT_PhieuNhap ct = getCTPN(maPn);
                db.CT_PhieuNhap.Remove(ct);
                PhieuNhap pn = getPN(maPn);
                db.PhieuNhaps.Remove(pn);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool checkPhieuNhap(string maPN)
        {
            return db.PhieuNhaps.Any(pn => pn.MaPhieuNhap == maPN);
        }
        
        //Chuyển đổi từ PM sang dạng 24h
        public string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }

        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }

        public bool createPhieuNhap(string maPhieu, string maTK, DateTime ngayTao)
        {
            try
            {
                db.PhieuNhaps.Add(new PhieuNhap
                {
                    MaPhieuNhap=maPhieu,
                    ID_TK=maTK,
                    NgayNhap = ngayTao
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool creatCTPhieuNhap(string maphieu,string maSP,string soLuong)
        {
            try
            {
                int soLuongSP = Convert.ToInt32(soLuong);
                db.CT_PhieuNhap.Add(new CT_PhieuNhap
                {
                    MaPhieuNhap=maphieu,
                    MaSP=maSP,
                    SoLuong=soLuongSP
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public CT_PhieuNhap getCTPhieuNhap(string maphieu, string maSp) {
            CT_PhieuNhap ct = db.CT_PhieuNhap.FirstOrDefault(x => (x.MaPhieuNhap == maphieu && x.MaSP == maSp) );
            return ct;
        }
        public bool updatePhieuNhap(string maphieu,string maSp, string soLuong)
        {
            try
            {
                int soLuongSP = Convert.ToInt32(soLuong);
                CT_PhieuNhap ct = getCTPhieuNhap( maphieu,  maSp);
                ct.SoLuong = soLuongSP;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deletePhieuNhapCT(string maphieu,String maSp)
        {
            try {
                CT_PhieuNhap ct = getCTPhieuNhap(maphieu, maSp);
                db.CT_PhieuNhap.Remove(ct);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=====================Bán hàng================
        public bool checkHoaDon(string maHD)
        {
            return db.HoaDons.Any(hd => hd.MaHD == maHD);
        }
        public bool createHoaDon(string maHD, string maTK, DateTime ngayTao)
        {
            try
            {
                db.HoaDons.Add(new HoaDon
                {
                    MaHD = maHD,
                    ID_TK = maTK,
                    NgayLap = ngayTao
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool creatCTHoaDon(string maphieu, string maSP, string soLuong,decimal thanhTien)
        {
            try
            {
                int soLuongSP = Convert.ToInt32(soLuong);
                db.CT_HoaDon.Add(new CT_HoaDon
                {
                    MaHD = maphieu,
                    MaSP = maSP,
                    SoLuong = soLuongSP,
                    ThanhTien = thanhTien
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public CT_HoaDon getCTHoaDon(string maphieu, string maSp)
        {
            CT_HoaDon hd = db.CT_HoaDon.FirstOrDefault(x => (x.MaHD == maphieu && x.MaSP == maSp));
            return hd;
        }

        public bool updateCTHoaDon(string maphieu, string maSp, string soLuong,decimal thanhTien)
        {
            try
            {
                int soLuongSP = Convert.ToInt32(soLuong);
                CT_HoaDon ct = getCTHoaDon(maphieu, maSp);
                ct.SoLuong = soLuongSP;
                ct.ThanhTien = thanhTien;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int getSoLuongTon(string maSp)
        {
            SanPham sp = GetSanPham(maSp);
            return (int)sp.SLTon;
        }
        public KhachHang getKhachBySDT(string sdt)
        {
           KhachHang khReturn =  db.KhachHangs.FirstOrDefault(kh => kh.SDT == sdt);
            return khReturn;
        }
        private decimal getGiaSP(string maSP)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
            return (decimal)sp.GiaBan;
        }
        public decimal getTongGiaSP(string maSp,int soLuong)
        {
            return getGiaSP(maSp) * (decimal)soLuong; 
        }
        private HoaDon getHD(string maHD)
        {
            if (!checkHoaDon(maHD)) return null;
            return db.HoaDons.FirstOrDefault(hd => hd.MaHD == maHD);
        }
        private CT_HoaDon getCTHoaDon_Ma(string maphieu)
        {
            CT_HoaDon cthd = db.CT_HoaDon.FirstOrDefault(x => (x.MaHD == maphieu));
            return cthd;
        }
        public bool HuyHD(String maHD)
        {
            try
            {
                CT_HoaDon ct = getCTHoaDon_Ma(maHD);
                db.CT_HoaDon.Remove(ct);
                HoaDon hd = getHD(maHD);
                db.HoaDons.Remove(hd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateHoaDonBan(string maHD, decimal TongGia, string maKH)
        {
            try
            {
                HoaDon hd = getHD(maHD);
                if (hd == null) return false;
                if (maKH == null)
                {
                    hd.TongTien = TongGia;
                    db.SaveChanges();
                }
                else
                {
                    hd.TongTien = TongGia;
                    hd.ID_KH = maKH;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tangDiemKH(string maKH)
        {
            try
            {
                KhachHang kh = GetKhach(maKH);
                kh.DiemTichLuy = kh.DiemTichLuy + 1;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteHoaDonCT(string maphieu, String maSp)
        {
            try
            {
                CT_HoaDon ct = getCTHoaDon(maphieu, maSp);
                db.CT_HoaDon.Remove(ct);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //======================Thống kê==============
        public List<HoaDon> getAllHoaDon()
        {
            return db.HoaDons.OrderByDescending(x => x.MaHD).ToList();
        }
        public List<HoaDon> getHoaDonFromDateToDate(DateTime tgTruoc, DateTime tgSau)
        {
            if(tgSau==tgTruoc) return db.HoaDons.Where(hd=>hd.NgayLap == tgTruoc).OrderByDescending(hd => hd.MaHD).ToList();
            return db.HoaDons.Where(hd => hd.NgayLap >= tgTruoc && hd.NgayLap <= tgSau).OrderByDescending(hd => hd.MaHD).ToList();
        }
        
        public List<HoaDon> GetHoaDonWithDateAndMaHD(DateTime tgTruoc, DateTime tgSau,String maHD)
        {
            if (tgSau == tgTruoc) return db.HoaDons.Where(hd => hd.NgayLap == tgTruoc && hd.MaHD==maHD).OrderByDescending(hd => hd.MaHD).ToList();
            return db.HoaDons.Where(hd => hd.NgayLap >= tgTruoc && hd.NgayLap <= tgSau && hd.MaHD == maHD).OrderByDescending(hd => hd.MaHD).ToList();
        }

        public List<HoaDon> GetHoaDonWithDateAndMaNV(DateTime tgTruoc, DateTime tgSau, String maNV)
        {
            if (tgSau == tgTruoc) return db.HoaDons.Where(hd => hd.NgayLap == tgTruoc && hd.ID_TK == maNV).OrderByDescending(hd => hd.MaHD).ToList();
            return db.HoaDons.Where(hd => hd.NgayLap >= tgTruoc && hd.NgayLap <= tgSau && hd.ID_TK == maNV).OrderByDescending(hd => hd.MaHD).ToList();
        }


        
        
        public List<HoaDon> getHoaDonByMaNV(String maNV)
        {
            return db.HoaDons.Where(hd => hd.ID_TK == maNV).OrderByDescending(hd=>hd.NgayLap).ToList();
        }

        public List<HoaDon> getHoaDonByMaHD(String maHD)
        {
            return db.HoaDons.Where(hd => hd.MaHD == maHD).OrderByDescending(hd => hd.NgayLap).ToList();
        }

        public List<PhieuNhap> getPhieuNhapByMaNV(String maNV)
        {
            return db.PhieuNhaps.Where(hd => hd.ID_TK == maNV).OrderByDescending(hd => hd.NgayNhap).ToList();
        }

        public List<PhieuNhap> getPhieuNhapByMaPN(String maPN)
        {
            return db.PhieuNhaps.Where(hd => hd.MaPhieuNhap == maPN).OrderByDescending(hd => hd.NgayNhap).ToList();
        }

        public List<PhieuNhap> getAllPhieuNhap()
        {
            return db.PhieuNhaps.OrderByDescending(x => x.MaPhieuNhap).ToList();
        }

        public List<CT_HoaDon> GetCT_HoaDonTheoMaHD(string maHD)
        {
            return db.CT_HoaDon.Where(ct => ct.MaHD == maHD).ToList();
        }

        public List<PhieuNhap> getPhieuNhapFromDateToDate(DateTime tgTruoc, DateTime tgSau)
        {
            if (tgSau == tgTruoc) return db.PhieuNhaps.Where(pn => pn.NgayNhap == tgTruoc).OrderByDescending(pn => pn.MaPhieuNhap).ToList();
            return db.PhieuNhaps.Where(pn => pn.NgayNhap >= tgTruoc && pn.NgayNhap <= tgSau).OrderByDescending(hd => hd.MaPhieuNhap).ToList();
        }
        public List<PhieuNhap> GetPhieuNhapWithDateAndMaPN(DateTime tgTruoc, DateTime tgSau, string maPN)
        {
            if (tgSau == tgTruoc) return db.PhieuNhaps.Where(pn => pn.NgayNhap == tgTruoc && pn.MaPhieuNhap==maPN).OrderByDescending(pn => pn.MaPhieuNhap).ToList();
            return db.PhieuNhaps.Where(pn => pn.NgayNhap >= tgTruoc && pn.NgayNhap <= tgSau && pn.MaPhieuNhap == maPN).OrderByDescending(hd => hd.MaPhieuNhap).ToList();
        }
        public List<PhieuNhap> GetPhieuNhapWithDateAndMaNV(DateTime tgTruoc, DateTime tgSau, string maNV)
        {
            if (tgSau == tgTruoc) return db.PhieuNhaps.Where(pn => pn.NgayNhap == tgTruoc && pn.ID_TK == maNV).OrderByDescending(pn => pn.MaPhieuNhap).ToList();
            return db.PhieuNhaps.Where(pn => pn.NgayNhap >= tgTruoc && pn.NgayNhap <= tgSau && pn.ID_TK == maNV).OrderByDescending(hd => hd.MaPhieuNhap).ToList();
        }

        public List<CT_PhieuNhap> GetCT_PhieuNhapTheoMaPN(string maPN)
        {
            return db.CT_PhieuNhap.Where(ct => ct.MaPhieuNhap == maPN).ToList();
        }


        //Tìm kiếm danh mục theo tên hoặc mã
        public List<DanhMuc> findDanhMucs_ma(String ma_input)
        {
            return db.DanhMucs.Where(x => x.MaDM.Contains(ma_input)).ToList();
        }
        public List<DanhMuc> findDanhMucs_name(String nameInput)
        {
            return db.DanhMucs.Where(x => x.TenDM.Contains(nameInput)).ToList();
        }

       
    }
}


