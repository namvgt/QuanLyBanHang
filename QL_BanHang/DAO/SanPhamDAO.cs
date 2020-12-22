using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DAO
{
    class SanPhamDAO
    {
        
            private static SanPhamDAO instance;
            public static SanPhamDAO Instance
            {
                get
                {
                    if (instance == null)
                        instance = new SanPhamDAO();
                    return SanPhamDAO.instance;
                }
                private set
                {
                    SanPhamDAO.instance = value;
                }
            }


            private SanPhamDAO() { }
        public bool Insert(string Ma, string Ten, string MaNCC, int SoLuong ,int Gia, string DonVi)
        {
            string query = "INSERT INTO dbo.SanPham ( Ma, Ten, MaNCC, SoLuong, Gia, DonVi ) VALUES  ( '"+Ma+"',  N'"+Ten+ "',  '"+MaNCC+"',  "+SoLuong+", "+Gia+",  N'"+DonVi+"'  )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Update(string Ma, string Ten, string MaNCC, int SoLuong, int Gia,string DonVi)
        {
            string query = "UPDATE dbo.SanPham SET Ten = N'" + Ten + "',MaNCC = N'" + MaNCC + "', SoLuong = '" + SoLuong + "',Gia = '"+Gia+"',DonVi = N'"+DonVi+"' WHERE Ma= N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);
            return results > 0;
        }
        public bool Delete(string Ma)
        {
            string query = "DELETE dbo.SanPham WHERE Ma=N'" + Ma + "'";
            int results = DataProvider.Instance.ExecuteNonQuery(query);

            return results > 0;
        }
        public bool Search(string Ten)
        {
            string query = string.Format("select * from dbo.SanPham where Ten like N'%{0}%'", Ten);
            DataTable results = DataProvider.Instance.ExecuteQuery(query);
            return results.Rows.Count > 0;
        }
    }
    }

