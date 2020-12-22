using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DTO
{
    class KhachHang
    {
        public KhachHang(string Ma , string Ten , string DiaChi, string SDT)
        {
            this.Ma = Ma;
            this.Ten = Ten;
            this.DiaChi = DiaChi;
            this.SDT = SDT; 
        }
        public KhachHang(DataRow row)
        {
            this.Ma = row["Ma"].ToString();
            this.Ten = row["Ten"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.SDT = row["SDT"].ToString();
        }
        private string sDT;
        private string diaChi;
        private string ten;
        private string ma;
        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
    }
}
