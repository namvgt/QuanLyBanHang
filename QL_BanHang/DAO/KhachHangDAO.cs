using SuperMarket.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return KhachHangDAO.instance;
            }
            private set
            {
                KhachHangDAO.instance = value;
            }
        }

       
        private KhachHangDAO() { }
        public bool InsertKH(string Ma, string Ten, string DiaChi, string Sdt)
        {
            string query = "INSERT INTO dbo.KhachHang (Ten, DiaChi, SDT ) VALUES  (N'" + Ten + "',  N'" + DiaChi + "', '" + Sdt + "'  )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateKH(string Ma, string Ten, string DiaChi, string SDT)
        {
            string query = "UPDATE dbo.KhachHang SET Ten = N'" + Ten + "',DiaChi = N'" + DiaChi + "', SDT = N'" + SDT + "' WHERE Ma= N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool Delete(string Ma)
        {
            string query = "DELETE dbo.KhachHang WHERE Ma=N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);

            return results > 0;
        }
        public bool Search(string Ten)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE Ten LIKE N'%"+Ten+"%'";
            DataTable results = DataProvider.Instance.ExecuteQuery(query);
            return results.Rows.Count > 0;
        }

    }
}
