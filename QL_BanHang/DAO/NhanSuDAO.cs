using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class NhanSuDAO
    {
        private static NhanSuDAO instance;
        public static NhanSuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanSuDAO();
                return NhanSuDAO.instance;
            }
            private set
            {
                NhanSuDAO.instance = value;
            }
        }


        private NhanSuDAO() { }

        public bool Insert(string Ten,string NgaySinh, string DiaChi, string Sdt,string ChucVu)
        {
            string query = "INSERT INTO dbo.NhanSu ( Ten ,NgaySinh , DiaChi , SDT ,ChucVu ) VALUES  ( N'"+Ten+"' ,  '"+NgaySinh+"' ,  N'"+DiaChi+"' ,  '"+Sdt+"' , N'"+ChucVu+"' ) ";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Update(string Ma,string Ten, string NgaySinh, string DiaChi, string Sdt, string ChucVu, int LuongCB, int PhuCap, int Thuong, int Luong)
        {
            string query = "UPDATE dbo.NhanSu SET Ten = N'" + Ten + "',NgaySinh = '"+NgaySinh+"', DiaChi = N'" + DiaChi + "', SDT = N'" + Sdt + "' ,ChucVu = N'" + ChucVu + "' , LuongCb = " + LuongCB + " , PhuCap = " + PhuCap + " ,Thuong = " + Thuong + ",Luong =  " + Luong + "  WHERE Ma= N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool Delete(string Ma)
        {
            string query = "DELETE dbo.NhanSu WHERE Ma=N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);

            return results > 0;
        }
        public bool Search(string Ten)
        {
            string query = string.Format("select * from NhanSu where Ten like N'%{0}%'", Ten);
            DataTable results = DataProvider.Instance.ExecuteQuery(query);
            return results.Rows.Count > 0;
        }
        public bool InsertImage(string Ma , string url)
        {
            string query = "UPDATE dbo.NhanSu SET Anh = '"+url+"' WHERE Ma = N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }

    }
}
