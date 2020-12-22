using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanDAO();
                return TaiKhoanDAO.instance;
            }
            private set
            {
                TaiKhoanDAO.instance = value;
            }
            
        }
        private TaiKhoanDAO() { }
     
       
        public bool Login(string userName, string passWord)
        {
            //string query = "SELECT * FROM dbo.TaiKhoan WHERE Ten = N'" + userName + "' AND MatKhau = N'" + passWord + "'";
            //DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string query = "USP_Login @Ten , @MatKhau";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return data.Rows.Count > 0;
        }
        public bool InsertTK(string Ten, string MatKhau, string ChucVu, string TenDayDu)
        {
            string query = "INSERT INTO dbo.TaiKhoan( Ten, MatKhau, ChucVu, TenDayDu ) VALUES  ( '"+Ten+"', '"+MatKhau+"', N'"+ChucVu+"', N'"+TenDayDu+"' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTK(string Ten, string MatKhau, string ChucVu, string TenDayDu)
        {
            string query = "UPDATE dbo.TaiKhoan SET Ten = N'"+Ten+"' , MatKhau=N'"+MatKhau+"', ChucVu=N'"+ChucVu+"', TenDayDu=N'"+TenDayDu+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTK(string Ten)
        {
            string query = "DELETE dbo.TaiKhoan WHERE Ten=N'" + Ten + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
      
        public bool SearchTK(string Ten)
        {
            string query = string.Format("select * from dbo.TaiKhoan where Ten like N'%{0}%'", Ten);
            DataTable results = DataProvider.Instance.ExecuteQuery(query);
            return results.Rows.Count > 0;
        }
    }
}
