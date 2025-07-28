using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyGear_GUI_SOF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            // gọi form quản lý khách hàng
            CustomerManagementForm formQuanLyKhachHang = new CustomerManagementForm();
            formQuanLyKhachHang.ShowDialog();

        }

        private void btnQuanLyHangSX_Click(object sender, EventArgs e)
        {
            ManufacturerManagementForm formQuanLyHangSX = new ManufacturerManagementForm();
            formQuanLyHangSX.ShowDialog();
        }

        private void btnQuanLyLoaiSanPham_Click(object sender, EventArgs e)
        {
            ProductTypesManagement productTypesManagement = new ProductTypesManagement();
            productTypesManagement.ShowDialog();

        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            ProductsManagement productsManagement = new ProductsManagement();
            productsManagement.ShowDialog();
        }
    }
}
