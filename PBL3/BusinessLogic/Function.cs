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

    }
}


