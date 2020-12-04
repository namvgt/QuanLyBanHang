using SuperMarket.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //
        string PhanQuyen(string Ten)
        {
            string query = "SELECT ChucVu FROM dbo.TaiKhoan WHERE Ten = N'"+Ten+"'";
            return DataProvider.Instance.DuLieu(query);
        }

        //
        string TenDayDu(string Ten)
        {
            string query = "SELECT TenDayDu FROM dbo.TaiKhoan WHERE Ten = N'" + Ten + "'";
            return DataProvider.Instance.DuLieu(query);
        }

        // Su kien dang nhap
        private void dangnhap_Click(object sender, EventArgs e)
        {
            string userName = tb_TenDN.Text;
            string passWord = tb_MK.Text;          

            // Neu tai khoan
            if (TaiKhoanDAO.Instance.Login(userName,passWord))
            {
                
                this.Hide();

                if (PhanQuyen(userName) == "Quản lý")
                {
                    Admin f2 = new Admin();
                    f2.ShowDialog();
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu chưa chính xác");
            }
        }

        // Su kien thoat
        private void thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
