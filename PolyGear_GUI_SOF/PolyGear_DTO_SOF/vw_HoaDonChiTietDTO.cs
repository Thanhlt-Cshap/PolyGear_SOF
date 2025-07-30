using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class vw_HoaDonChiTietDTO
    {
        public int STT { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public decimal TongTien { get; set; }
        public string MaDonHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public string KhachHang { get; set; }
        public string SDTKhach { get; set; }
        public string EmployeeID { get; set; }
        public string NhanVienBan { get; set; }
        public string MaChiTiet { get; set; }

        public string HangSanXuat { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public string MaLoaiSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
