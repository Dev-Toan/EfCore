using EFCore.models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Them(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text)
                || string.IsNullOrWhiteSpace(txtTenSP.Text)
                || string.IsNullOrWhiteSpace(txtDonGia.Text)
                || string.IsNullOrWhiteSpace(txtSoLuong.Text)
                || string.IsNullOrWhiteSpace(txtMaLoai.Text) ) {
                MessageBox.Show("vui long nhap du thong tin","thong bao",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            using (var context = new QlbanHangContext())
            {
                var sp = new SanPham
                {
                    MaSp = txtMaSP.Text,
                    TenSp = txtTenSP.Text,
                    DonGia = int.Parse(txtDonGia.Text),
                    SoLuong = int.Parse(txtSoLuong.Text),
                    MaLoai = txtMaLoai.Text,
                };

                context.SanPhams.Add(sp);
                context.SaveChanges();
            }
             LoadData();
             ClearInput();
        }


        private void ClearInput()
        {
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtMaLoai.Text = string.Empty;
        }

        private void Button_Sua(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("hay nhap ma san pham can sua","thong bao",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            
            if (!int.TryParse(txtSoLuong.Text, out _) || !int.TryParse(txtDonGia.Text, out _))
            {
                MessageBox.Show("so luong va don gia phai la so nguyen", "thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.Parse(txtSoLuong.Text) <= 0 || int.Parse(txtDonGia.Text) <= 0)
            {
                MessageBox.Show("so luong va don gia phai lon hon 0", "thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            using (var context = new QlbanHangContext())
            {
                var sp = context.SanPhams.Find(txtMaSP.Text);
                if (sp != null)
                {
                    sp.TenSp = txtTenSP.Text;
                    sp.DonGia = int.Parse(txtDonGia.Text);
                    sp.SoLuong = int.Parse(txtSoLuong.Text);
                    sp.MaLoai = txtMaLoai.Text;

                    context.SaveChanges();
                    LoadData();
                }
            }
            ClearInput();
        }

        private void Button_Xoa(object sender, RoutedEventArgs e)
        {
            using (var context = new QlbanHangContext())
            {
                var sp = context.SanPhams.Find(txtMaSP.Text);
                if (sp != null)
                {
                    context.SanPhams.Remove(sp);
                    context.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần xóa.");
                }
            }
            ClearInput();
        }

        private void Button_Tim(object sender, RoutedEventArgs e)
        {
            List<ThongTinSp> data;

            using (var context = new QlbanHangContext()) {
                    data = context.SanPhams
                    .Include(sp => sp.MaLoaiNavigation)
                    //.Where(sp => sp.MaSp == txtMaSP.Text)      tim kiem theo masp
                    .Select(sp => new ThongTinSp
                    {
                        MaSp = sp.MaSp.ToString(),
                        TenSp = sp.TenSp,
                        TenLoai = sp.MaLoaiNavigation.TenLoai,
                        SoLuong = sp.SoLuong,
                        ThanhTien = sp.SoLuong * sp.DonGia
                    }).ToList();
            }

            var window2 = new Window2(data);
            window2.Show();
        }


        public class ThongTinSp()
        {
            public string MaSp { get; set; } = null!;

            public string? TenSp { get; set; }
            public string? TenLoai {  get; set; }

            public int? DonGia { get; set; }

            public int? SoLuong { get; set; }

            public double? ThanhTien { get; set; }


            public virtual LoaiSanPham? MaLoaiNavigation { get; set; }

            
        }

        private void LoadData()
        {
            using (var context = new QlbanHangContext())
            {
                var data = context.SanPhams
                    .Include(sp => sp.MaLoaiNavigation)
                    .OrderBy(sp => sp.DonGia)
                    .Select(sp => new
                    {
                        sp.MaSp,
                        sp.TenSp,
                        sp.MaLoaiNavigation.TenLoai,
                        sp.DonGia,
                        sp.SoLuong,
                        ThanhTien = sp.DonGia * sp.SoLuong
                    })
                    .ToList();

                dgQuanLySP.ItemsSource = data;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void dgQuanLySP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgQuanLySP.SelectedItem is ThongTinSp select)
            {
                txtMaSP.Text = select.MaSp;
                txtTenSP.Text = select.TenSp;
                txtDonGia.Text = select.DonGia.ToString();
                txtSoLuong.Text = select.SoLuong.ToString();
                txtMaLoai.Text = select.MaLoaiNavigation.MaLoai;
            }
        }
    }
}