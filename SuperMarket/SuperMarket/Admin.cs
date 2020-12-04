using SuperMarket.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadKH();
            LoadThongTin();
            //-----------------
            LoadTaiKhoan();
            LoadThongTinTK();
            //--------------------
            LoadNCC();
            LoadThongTinNCC();

            //---------------------------
            LoadNS();
            LoadThongTinNS();
            //----------------------
            LoadSP();
            LoadThongTinSP();
            //-----------------------------
            
        }

        BindingSource KhachHang = new BindingSource(); //Rat Hay
        void LoadKH()
        {
            string query = "SELECT * FROM dbo.KhachHang";
            KhachHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadThongTin()
        {
            dataGridView3.DataSource = KhachHang;  //Rat Hay
            textBox27.DataBindings.Add(new Binding("text", dataGridView3.DataSource, "Ma", true, DataSourceUpdateMode.Never));
            textBox26.DataBindings.Add(new Binding("text", dataGridView3.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            textBox19.DataBindings.Add(new Binding("text", dataGridView3.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            textBox18.DataBindings.Add(new Binding("text", dataGridView3.DataSource, "SDT", true, DataSourceUpdateMode.Never));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string Ten = textBox26.Text;
            string DiaChi = textBox19.Text;
            string SDT = textBox18.Text;
            string Ma = textBox27.Text;
            if (KhachHangDAO.Instance.UpdateKH(Ma, Ten, DiaChi, SDT))
            {
                MessageBox.Show("Sửa thành công");
                LoadKH();
            }
            else
            {
                MessageBox.Show("Không sửa được");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = KhachHang;
            LoadKH();
        }

        public void LoadSearch(string Ten)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE Ten LIKE N'%" + Ten + "%'";
            KhachHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string Ten = textBox13.Text;
            if (KhachHangDAO.Instance.Search(Ten))
            {
                LoadSearch(Ten);
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }

        // TAI KHOAN_________________________________________________________________________________________________________
        BindingSource TaiKhoan = new BindingSource();
        void LoadTaiKhoan()
        {
            string query = "select * from TaiKhoan";
            TaiKhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadThongTinTK()
        {
            dataGridView5.DataSource = TaiKhoan;
            textBox33.DataBindings.Add(new Binding("text", dataGridView5.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            comboBox1.DataBindings.Add(new Binding("text", dataGridView5.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            textBox32.DataBindings.Add(new Binding("text", dataGridView5.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));
            textBox31.DataBindings.Add(new Binding("text", dataGridView5.DataSource, "TenDayDu", true, DataSourceUpdateMode.Never));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string Ten = textBox33.Text;
            string MatKhau = textBox32.Text;
            string ChucVu = comboBox1.Text;
            string TenDayDu = textBox31.Text;
            if (TaiKhoanDAO.Instance.UpdateTK(Ten, MatKhau, ChucVu, TenDayDu))
            {
                MessageBox.Show("Sửa thành công");
                LoadTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string Ten = textBox33.Text;
            if (TaiKhoanDAO.Instance.DeleteTK(Ten))
            {
                MessageBox.Show("Xoá thành công");
                LoadTaiKhoan();
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        public void LoadSearchTK(string Ten)
        {
            string query = "SELECT * FROM dbo.TaiKhoan WHERE Ten LIKE N'%" + Ten + "%'";
            TaiKhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string Ten = textBox15.Text;
            if (TaiKhoanDAO.Instance.SearchTK(Ten))
            {
                LoadSearchTK(Ten);
            }
            else
            {
                MessageBox.Show("Không tồn tại");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = TaiKhoan;
            LoadTaiKhoan();
        }
        //--------------------------------------NhaCUngCap---------------------------------------------------------------------

        BindingSource NCC = new BindingSource();
        void LoadNCC()
        {
            string query = "SELECT * FROM dbo.NhaCungCap";
            NCC.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadThongTinNCC()
        {
            dataGridView4.DataSource = NCC;  //Rat Hay
            textBox29.DataBindings.Add(new Binding("text", dataGridView4.DataSource, "Ma", true, DataSourceUpdateMode.Never));
            textBox28.DataBindings.Add(new Binding("text", dataGridView4.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            textBox17.DataBindings.Add(new Binding("text", dataGridView4.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            textBox16.DataBindings.Add(new Binding("text", dataGridView4.DataSource, "SDT", true, DataSourceUpdateMode.Never));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Ma = textBox29.Text;
            string Ten = textBox28.Text;
            string DiaChi = textBox17.Text;
            string Sdt = textBox16.Text;
            if (NccDAO.Instance.Update(Ma, Ten, DiaChi, Sdt))
            {
                MessageBox.Show("Sửa thành công");
                LoadNCC();
            }
            else
            {
                MessageBox.Show("Không sửa được");
            }
        }

        public void SearchNCC(string Ten)
        {
            string query = "SELECT * FROM dbo.NhaCungCap WHERE Ten LIKE N'%" + Ten + "%'";
            NCC.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string Ten = textBox12.Text;
            if (NccDAO.Instance.Search(Ten))
            {
                SearchNCC(Ten);
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = NCC;
            LoadNCC();
        }

        //-----------------------------------NhanVien-----------------------------------------------------

        BindingSource NS = new BindingSource();
        void LoadNS()
        {
            string query = "select Ma AS [Mã],Ten AS [Tên],NgaySinh AS [Ngày Sinh],DiaChi AS [Địa chỉ],SDT AS [SĐT],ChucVu AS [Chức vụ],LuongCb AS [Lương CB],PhuCap AS [Phụ cấp],Thuong AS [Thưởng] ,Luong AS [Lương] from NhanSu";
            NS.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadThongTinNS()
        {
            dataGridView1.DataSource = NS;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            string Ma = textBox1.Text;
            string Ten = textBox2.Text;
            string NgaySinh = textBox3.Text;
            string DiaChi = textBox4.Text; ;
            string SDT = textBox5.Text;
            string ChucVu = comboBox2.Text;
            string LuongCb = textBox7.Text; ;
            string PhuCap = textBox8.Text;
            string Thuong = textBox9.Text;
            string Luong = textBox10.Text;
            if (NhanSuDAO.Instance.Update(Ma,Ten, NgaySinh, DiaChi, SDT, ChucVu, int.Parse(LuongCb), int.Parse(PhuCap), int.Parse(Thuong), int.Parse(Luong)))
            {
                MessageBox.Show("Sửa thành công");
                LoadNS();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        void SearchNS(string Ten)
        {
            string query = "SELECT * FROM dbo.NhanSu WHERE Ten LIKE N'%" + Ten + "%'";
            NS.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ten = textBox11.Text;
            if (NhanSuDAO.Instance.Search(Ten))
            {
                SearchNS(Ten);
               
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = NS;
            LoadNS();
        }

        int Luong;

        private void button5_Click(object sender, EventArgs e)
        {
            int LuongCb = int.Parse(textBox7.Text);
            int PhuCap = int.Parse(textBox8.Text);
            int Thuong = int.Parse(textBox9.Text);
            Luong = LuongCb + PhuCap + Thuong;
            textBox10.Text = Luong.ToString();

            Luong = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Ma = textBox1.Text;
            if (NhanSuDAO.Instance.Delete(Ma))
            {
                MessageBox.Show("Xoá thành công");
                LoadNS();
            }
            else
            {
                MessageBox.Show("Không xoá được");
            }
            LoadImage(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        //--------------------------------------------------SanPham---------------------------------------------------------------------------------------
        BindingSource SP = new BindingSource();
        void LoadSP()
        {
            string query = "SELECT Ma ,Ten,MaNCC,SoLuong,Gia,DonVi FROM dbo.SanPham";
            SP.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadThongTinSP()
        {
            dataGridView2.DataSource = SP;  //Rat Hay
            textBox25.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "Ma", true, DataSourceUpdateMode.Never));
            textBox24.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            textBox23.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            textBox22.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            textBox21.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "Gia", true, DataSourceUpdateMode.Never));
            textBox20.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "DonVi", true, DataSourceUpdateMode.Never));
        }

        public void SearchSP(string Ten)
        {
            string query = "SELECT * FROM dbo.SanPham WHERE Ten LIKE N'%" + Ten + "%'";
            SP.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            string Ma = textBox25.Text;
            string Ten = textBox24.Text;
            string MaNCC = textBox23.Text;
            string SoLuong = textBox22.Text;
            string Gia = textBox21.Text;
            string DonVi = textBox20.Text;
            if (SanPhamDAO.Instance.Update(Ma, Ten, MaNCC, int.Parse(SoLuong), int.Parse(Gia), DonVi))
            {
                MessageBox.Show("Sửa thành công");
                LoadSP();
            }
            else
            {
                MessageBox.Show("Không sửa được");
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
                dataGridView2.DataSource = SP;
                LoadSP();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string Ten = textBox14.Text;
            if (SanPhamDAO.Instance.Search(Ten))
            {

                SearchSP(Ten);
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string Ma = textBox29.Text;
            if (NccDAO.Instance.Delete(Ma))
            {
                MessageBox.Show("Xoá thành công");
                LoadNCC();
            }
            else
            {
                MessageBox.Show("Không xoá được");
            }
        }

        //--------------------------------------------------ChenAnh-----------------------------------------------------------------------------------
        string url = "" ;
     
        private void button24_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaglog = new OpenFileDialog();
            
            if(diaglog.ShowDialog() == DialogResult.OK)
            {
                url = diaglog.FileName;
                pictureBox1.Image = Image.FromFile(url);

            }
        }
      
        private void button25_Click(object sender, EventArgs e)
        {
            string Ma = textBox1.Text;
            if (NhanSuDAO.Instance.InsertImage(Ma, url))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        void LoadImage(string Ma)
        {
            string query = "select Anh from NhanSu where Ma = N'" + Ma + "'";
            string url = DataProvider.Instance.DuLieu(query);
            if(url != "")
            {
                pictureBox1.Image = Image.FromFile(url);
            }
            else
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\HP\\Pictures\\Screenshots\\anh.png");
            }          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadImage(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        //-----------------------------------THONG KE---------------------------------------------------------
        void ThongKe(string Tu , string Den)
        {
            string query = "SELECT hd.TenNhanVien as[Nhân viên] , SUM(hd.ThanhTien) as[Tổng tiền] FROM dbo.HoaDon hd  WHERE hd.NgayBan BETWEEN '"+Tu+"' AND '"+Den+"' GROUP BY hd.TenNhanVien ";
            dataGridView6.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        string worse(string Tu, string Den)
        {
            string query = "SELECT TOP 1 hd.TenNhanVien, SUM(hd.ThanhTien) AS t FROM dbo.HoaDon hd WHERE hd.NgayBan BETWEEN '" + Tu + "' AND '" + Den + "' GROUP BY hd.TenNhanVien ORDER BY t ASC";
            return DataProvider.Instance.DuLieu(query);
        }

        string best(string Tu, string Den)
        {
            string query = "SELECT TOP 1 hd.TenNhanVien, SUM(hd.ThanhTien) AS t FROM dbo.HoaDon hd WHERE hd.NgayBan BETWEEN '" + Tu + "' AND '" + Den + "' GROUP BY hd.TenNhanVien ORDER BY t DESC";
            return DataProvider.Instance.DuLieu(query);
        }

        string Thu(string Tu, string Den)
        {
            string query = "SELECT  SUM(hd.ThanhTien)  FROM dbo.HoaDon hd WHERE hd.NgayBan BETWEEN '" + Tu + "' AND '" + Den + "'";
            return DataProvider.Instance.DuLieu(query);
        }

        string Chi(string Tu, string Den)
        {
            string query = "SELECT  SUM(a.ThanhTien)  FROM dbo.NhapSpBaoQuat a WHERE a.NgayNhap BETWEEN '" + Tu + "' AND '" + Den + "'";
            return DataProvider.Instance.DuLieu(query);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox39.Text != "" && textBox38.Text != "" && textBox37.Text != "" && textBox40.Text != "" && textBox41.Text != "" && textBox42.Text != "" ) {
                if (int.Parse(textBox37.Text) < 32 && int.Parse(textBox40.Text) < 32 && int.Parse(textBox38.Text) < 13 && int.Parse(textBox41.Text) < 13)
                {
                    string Tu = textBox39.Text + "-" + textBox38.Text + "-" + textBox37.Text;
                    string Den = textBox42.Text + "-" + textBox41.Text + "-" + textBox40.Text;
                    ThongKe(Tu, Den);
                    textBox30.Text = worse(Tu, Den);
                    textBox6.Text = best(Tu, Den);
                    textBox34.Text = Thu(Tu, Den);
                    textBox35.Text = Chi(Tu, Den);
                    textBox36.Text = (int.Parse(Thu(Tu, Den)) - int.Parse(Chi(Tu, Den))).ToString();
                }
                else
                {
                    MessageBox.Show("Lỗi ngày hoặc tháng.Xem lại!!!");
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thời gian");
            }
        }
    }
}