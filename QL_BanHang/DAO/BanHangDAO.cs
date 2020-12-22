using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{

    class BanHangDAO
    {
        private static BanHangDAO instance;
        public static BanHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanHangDAO();
                return BanHangDAO.instance;
            }
            private set
            {
               BanHangDAO.instance = value;
            }
        }


        private  BanHangDAO() { }
        public bool InsertKH(string Ten, String DiaChi, string Sdt)
        {
            string query = "INSERT INTO dbo.KhachHang (Ten, DiaChi, SDT ) VALUES  (N'" + Ten + "',  N'" + DiaChi + "', '" + Sdt + "'  )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertHoaDonChiTiet(int MaHD, string TenSP , int Gia, int SoLuong ,string MaSP)
        {
            string query = "INSERT INTO dbo.HoaDonChiTiet ( MaHD, TenSP, Gia, SoLuong, MaSP ) VALUES  ( " +MaHD + ", N'" +TenSP + "'," +Gia + "," +SoLuong + ", '" +MaSP +"' )";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool InsertHoaDon(int MaKH,string ThoiGian, int ThanhTien , string TenNhanVien )
        {        
            string query = "INSERT INTO dbo.HoaDon(MaKH, NgayBan, ThanhTien,TenNhanVien ) VALUES  ( " + MaKH + ",'"+ThoiGian+"', " + ThanhTien + ",'" + TenNhanVien + " '  )";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool UpdateSanPham(int slTrongKho , int slBan,string Ten)
        {
            string query = "UPDATE dbo.SanPham SET SoLuong = '" + (slTrongKho - slBan) + "' WHERE Ten = N'" + Ten + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }

        public bool SearchSP(string TenSP) 
        {
            string query = string.Format("select * from dbo.SanPham where Ten like N'%{0}%'", TenSP);
            DataTable results = DataProvider.Instance.ExecuteQuery(query); // ExcuteNonQuery thi return ra -1
            return results.Rows.Count > 0;
        }
        public bool SearchKH(string TenKH)
        {
            string query = string.Format("select * from dbo.KhachHang where Ten like N'%{0}%'", TenKH);
            DataTable results = DataProvider.Instance.ExecuteQuery(query); // ExcuteNonQuery thi return ra -1
            return results.Rows.Count > 0;
        }
        public bool UpdateSanPham2(int slTrongKho, int slXoa, string Ten)
        {
            string query = "UPDATE dbo.SanPham SET SoLuong = '" + (slTrongKho + slXoa) + "' WHERE Ten = N'" + Ten + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
    }
}
