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
    public partial class QuanKhoForm : Form
    {
        public QuanKhoForm()
        {
            InitializeComponent();
            TaoBang();
            TextBox_();
            timer1.Start();
            LoadThongTinNhapHang();
        }

        void TextBox_()
        {
            textBox1.Text = MaPhieu().ToString();
            textBox6.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
        }

        DataTable dt = new DataTable();
        void TaoBang()
        {
            //dt.Columns.Add("MaPhieu");
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("MaNCC");
            dt.Columns.Add("TenNCC");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("SDT");
            dt.Columns.Add("NgayNhap");
            dt.Columns.Add("GiaNhap");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonVi");


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            TextBox_();
        }

        int MaPhieu()
        {
            string query = "select MAX(MaPhieu) from NhapSpBaoQuat";
            return int.Parse(DataProvider.Instance.DuLieu(query)) + 1;
        }

        int TongTien = 0;

        void NhapSP()
        {
            string MaPhieu = textBox1.Text;
            string MaSP = textBox2.Text;
            string TenSP = textBox3.Text;
            string MaNCC = textBox4.Text;
            string TenNCC = textBox5.Text;
            string NgayNhap = textBox6.Text;
            string GiaNhap = textBox7.Text;
            string SoLuong = textBox8.Text;
            string DonVi = textBox10.Text;

            DataRow dr = dt.NewRow();
            //dr["MaPhieu"] = MaPhieu;
            dr["MaSP"] = MaSP;
            dr["TenSP"] = TenSP;
            dr["MaNCC"] = MaNCC;
            dr["TenNCC"] = TenNCC;
            dr["NgayNhap"] = NgayNhap;
            dr["GiaNhap"] = GiaNhap;
            dr["SoLuong"] = SoLuong;
            dr["DonVi"] = DonVi;
            if (GiaNhap != "" && SoLuong != "")
            {
                dt.Rows.Add(dr);
                TongTien += int.Parse(GiaNhap) * int.Parse(SoLuong);
                textBox9.Text = TongTien.ToString();
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin sản phẩm ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhapSP();
            textBox1.Text = MaPhieu().ToString();
            dataGridView1.DataSource = dt;
        }

        int PhieuNhap()
        {
            string query = "select MAX(MaPhieu) from NhapSpBaoQuat";
            return int.Parse(DataProvider.Instance.DuLieu(query)) + 1;
        }
        DataTable datatable = new DataTable();

        void LoadSP()
        {
            string query = "select Ma from SanPham";
            datatable = DataProvider.Instance.ExecuteQuery(query);

        }
        
        int SoLuongSPtrongKho(string Ma)
        {
            string query = "Select SoLuong from SanPham where Ma = '" + Ma + "'";
            return int.Parse(DataProvider.Instance.DuLieu(query));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string MaPhieu = textBox1.Text;
            string NgayNhap = textBox6.Text;
            if (NhapHangDAO.Instance.NhapSpBaoQuat(int.Parse(MaPhieu), NgayNhap, TongTien))
            {

                MessageBox.Show("Thanh toán thành công");
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

            dt.Rows.Clear();
            dataGridView1.DataSource = dt;
            TongTien = 0;
            TextBox_();
        }

        public string textValue = "";

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox10.Text = "";
        }

        void LoadThongTinNhapHang()
        {
            string query = "select MaPhieu AS[Mã phiếu nhập],NgayNhap AS[Ngày nhập], ThanhTien as[Tổng tiền] from NhapSpBaoQuat";
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadThongTinNhapHang();
        }

        public void LoadSearch(string TenSP)
        {
            string query = "SELECT Ma AS[Mã phiếu nhập],MaSP AS[Mã SP],TenSP AS[Tên SP],MaNCC AS[Mã NCC],TenNCC AS[Tên NCC],NgayNhap AS[Ngày nhập],SoLuong AS[Số lượng], GiaNhap AS[Giá nhập],GhiChu AS[Đơn vị] FROM dbo.NhapSP WHERE TenSP LIKE N'%" + TenSP + "%'";
            dataGridView2.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void xoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int a = int.Parse(dataGridView1.Rows[row].Cells[8].Value.ToString());
            int b = int.Parse(dataGridView1.Rows[row].Cells[9].Value.ToString());
            TongTien -= a * b;
            textBox9.Text = TongTien.ToString();
            dt.Rows.RemoveAt(row);
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
        }
    }
}
