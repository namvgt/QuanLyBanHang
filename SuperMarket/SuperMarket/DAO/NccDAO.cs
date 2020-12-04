using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class NccDAO
    {
        private static NccDAO instance;
        public static NccDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NccDAO();
                return NccDAO.instance;
            }
            private set
            {
                NccDAO.instance = value;
            }
        }


        private NccDAO() { }

        public bool Insert(string Ma, string Ten, string DiaChi, string Sdt)
        {
            string query = "INSERT INTO dbo.NhaCungCap (Ma,Ten, DiaChi, SDT ) VALUES  (N'" + Ma + "', N'" + Ten + "',  N'" + DiaChi + "', '" + Sdt + "'  )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Update(string Ma, string Ten, string DiaChi, string SDT)
        {
            string query = "UPDATE dbo.NhaCungCap SET Ten = N'" + Ten + "',DiaChi = N'" + DiaChi + "', SDT = N'" + SDT + "' WHERE Ma= N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool Delete(string Ma)
        {
            string query = "DELETE dbo.NhaCungCap WHERE Ma=N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);

            return results > 0;
        }
        public bool Search(string Ten)
        {
            string query = string.Format("select * from dbo.NhaCungCap where Ten like N'%{0}%'", Ten);
            DataTable results = DataProvider.Instance.ExecuteQuery(query);
            return results.Rows.Count > 0;
        }
    }
}
