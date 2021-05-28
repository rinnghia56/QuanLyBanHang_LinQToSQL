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

    }
}
//================================Khách hàng==============

