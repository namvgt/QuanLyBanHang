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
    public partial class BanHangForm : Form
    {
        public BanHangForm()
        {
            InitializeComponent();
            LoadSP();
            LoadTenSP();
            Bang();
            textBox8.Text = " Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            TienThua();

        }

        void TienThua()
        {
            int s;
            if (textBox10.Text == "")
            {
                textBox9.Text = "";
            }
            else
            {
                if (textBox7.Text == "")
                {
                    textBox9.Text = "";
                }
                else
                {
                    s = int.Parse(textBox10.Text) - int.Parse(textBox7.Text);
                    textBox9.Text = s.ToString();
                }
            }
        }
        BindingSource SanPham = new BindingSource();
        void LoadSP()
        {
            string query = "select Ma as[Mã SP],Ten,DonVi as[Đơn vị],Gia as[Giá],SoLuong as[SL trong kho] from SanPham";
            SanPham.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadTenSP()
        {
            dataGridView1.DataSource = SanPham;
            textBox1.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "Ten", true, DataSourceUpdateMode.Never));
        }
        DataTable dt = new DataTable();

        int TongTien = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            ThemSP();
            dataGridView2.DataSource = dt;
        }

        void Bang()
        {
            dt.Columns.Add("Ma");
            dt.Columns.Add("Ten");
            dt.Columns.Add("Gia");
            dt.Columns.Add("SoLuong");
        }

        int MaKH()
        {
            string query = "SELECT MAX(Ma) FROM dbo.KhachHang";
            return int.Parse(DataProvider.Instance.DuLieu(query));
        }

        int MaHD()
        {
            string query = "SELECT MAX(Ma) FROM dbo.HoaDon";
            return int.Parse(DataProvider.Instance.DuLieu(query));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Ten = textBox3.Text;
            string DiaChi = textBox4.Text;
            string Sdt = textBox5.Text;
            int ThanhTien = int.Parse(textBox7.Text);

            int ngay = DateTime.Now.Day;
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            int SLmatHang = dataGridView2.Rows.Count - 1;
            string ThoiGian = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;

            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (BanHangDAO.Instance.InsertKH(Ten, DiaChi, Sdt))
                {

                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                dt.Rows.Clear();
                dataGridView2.DataSource = dt;
                TongTien = 0;
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin khách hàng");
            }

        }

        public void LoadSearch(string TenSP)
        {
            string query = "SELECT * FROM dbo.SanPham WHERE Ten LIKE N'%" + TenSP + "%'";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TenSP = textBox6.Text;
            if (BanHangDAO.Instance.SearchSP(TenSP))
            {
                LoadSearch(TenSP);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SanPham;
            LoadSP();
        }

        private void xoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Ten1;
            int row = dataGridView2.CurrentCell.RowIndex;
            int a = int.Parse(dataGridView2.Rows[row].Cells[2].Value.ToString());
            int b = int.Parse(dataGridView2.Rows[row].Cells[3].Value.ToString());
            string Ten2 = dataGridView2.Rows[row].Cells[1].Value.ToString();
            int slSPtrongKho;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Ten1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                if (string.Compare(Ten1, Ten2) == 0)
                {
                    slSPtrongKho = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    if (BanHangDAO.Instance.UpdateSanPham2(slSPtrongKho, b, Ten1))
                    {
                        LoadSP();
                    }
                }
            }

            TongTien -= a * b;
            textBox7.Text = TongTien.ToString();
            dt.Rows.RemoveAt(row);
            dt.AcceptChanges();
            dataGridView2.DataSource = dt;

        }

        void ThemSP()
        {
            int a, b;
            string Ma = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string Ten = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string GhiChu = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string Gia = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string SoLuong = textBox2.Text;

            if (SoLuong != "")
            {
                int slTrongKho = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                int slBan = int.Parse(SoLuong);
                if (slTrongKho >= slBan)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ma"] = Ma;
                    dr["Ten"] = Ten;
                    dr["Gia"] = Gia;
                    dr["SoLuong"] = SoLuong;
                    dt.Rows.Add(dr);

                    a = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    b = int.Parse(SoLuong);
                    TongTien += a * b;

                    textBox2.Clear();
                    if (BanHangDAO.Instance.UpdateSanPham(slTrongKho, slBan, Ten))
                    {
                        LoadSP();
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng sản phẩm không đủ");
                }
            }
            else
            {
                MessageBox.Show("Nhập số lượng sản phẩm");
            }
            textBox7.Text = TongTien.ToString();
            //textBox10.Text = (dt.Rows.Count).ToString();

        }
        //------------------------------------------------KhachHang-------------------------------------------------------------------
        public void LoadSearchKH(string TenKH)
        {
            string query = "SELECT hd.NgayBan AS[Ngày Bán],kh.Ma AS[Mã KH],kh.Ten AS[Tên],kh.DiaChi AS[Địa Chỉ],kh.SDT as[SĐT],hd.Ma AS[Mã HĐ],hd.ThanhTien AS[Tổng tiền] FROM dbo.KhachHang kh, dbo.HoaDon hd WHERE kh.Ma = hd.MaKH AND kh.Ten LIKE N'%" + TenKH + "%'";
            dataGridView3.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string TenKH = textBox11.Text;
            if (BanHangDAO.Instance.SearchKH(TenKH))
            {
                LoadSearchKH(TenKH);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng");
            }
        }
    }
}
