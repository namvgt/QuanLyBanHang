using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class NhapHangDAO
    {
        private static NhapHangDAO instance;
        public static NhapHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhapHangDAO();
                return NhapHangDAO.instance;
            }
            private set
            {
                NhapHangDAO.instance = value;
            }
        }


        private NhapHangDAO() { }
        public bool NhapHang(int Ma , string TenSP, string MaNCC, string TenNCC, int GiaNhap, int SoLuong ,string DonVi)
        {
            string query = "INSERT INTO dbo.NhapSP(Ma,TenSP ,MaNCC,TenNCC , GiaNhap,SoLuong,GhiChu )VALUES  ( "+Ma+",  N'" + TenSP + "' ,  '" + MaNCC + "' ,  '" + TenNCC + "' ," + GiaNhap + ",  " + SoLuong + " , '"+DonVi+"' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool NhapSpBaoQuat(int MaPhieu , string NgayNhap , int ThanhTien)
        {
            string query = "INSERT INTO dbo.NhapSpBaoQuat( MaPhieu , NgayNhap , ThanhTien )VALUES  ( " + MaPhieu + " ,  '" + NgayNhap + "' , "+ThanhTien+")";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Insert(string Ma, string Ten, string MaNCC, int SoLuong,  string DonVi)
        {
            string query = "INSERT INTO dbo.SanPham ( Ma, Ten, MaNCC, SoLuong,  DonVi ) VALUES  ( '" + Ma + "',  N'" + Ten + "',  '" + MaNCC + "',  " + SoLuong + ",  N'" + DonVi + "'  )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Update(int SoLuong,string Ma)
        {
            string query = "UPDATE dbo.SanPham SET SoLuong = '" + SoLuong + "' WHERE Ma= N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool Search(string Ten)
        {
            string query = "select * from NhapSP where TenSP like '%" + Ten + "%'";
            DataTable results = DataProvider.Instance.ExecuteQuery(query);
            return results.Rows.Count > 0;
        }
    }
}
