using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;
using System.Data.SqlClient;
using System.Windows.Forms; // Vẫn cần để sử dụng SqlDataReader

namespace PolyGear_DAL_SOF
{
    public class vw_HoaDonChiTietDAL : SystemDAL.BaseDAL<vw_HoaDonChiTietDTO, string>
    {
        public override List<vw_HoaDonChiTietDTO> selectAll()
        {
            string sql = "SELECT * FROM vw_HoaDonChiTiet";
            return selectBySql(sql, new List<object>());
        }

        public override vw_HoaDonChiTietDTO selectById(string id)
        {
            throw new NotImplementedException("Không hỗ trợ selectById cho view.");
        }

        public override List<vw_HoaDonChiTietDTO> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<vw_HoaDonChiTietDTO> list = new List<vw_HoaDonChiTietDTO>();
            int stt = 1;

            SqlDataReader reader = null;
            try
            {
                // Gọi DBUtil.Query để lấy SqlDataReader
                // DBUtil.Query sẽ gọi DBUtil.GetCommand, và GetCommand sẽ tự thêm tham số
                reader = DBUtil.Query(sql, args, cmdType);

                while (reader.Read())
                {
                    vw_HoaDonChiTietDTO dto = new vw_HoaDonChiTietDTO
                    {
                        STT = stt++,
                        MaHoaDon = reader["MaHoaDon"].ToString(),
                        NgayLapHoaDon = Convert.ToDateTime(reader["NgayLapHoaDon"]),
                        TongTien = Convert.ToDecimal(reader["TongTien"]),
                        MaDonHang = reader["MaDonHang"].ToString(),
                        NgayDatHang = Convert.ToDateTime(reader["NgayDatHang"]),
                        KhachHang = reader["KhachHang"].ToString(),
                        SDTKhach = reader["SDTKhach"].ToString(),
                        NhanVienBan = reader["NhanVienBan"].ToString(),
                        MaChiTiet = reader["MaChiTiet"].ToString(),
                        TenSanPham = reader["TenSanPham"].ToString(),
                        LoaiSanPham = reader["LoaiSanPham"].ToString(),
                        MaLoaiSanPham = reader["MaLoaiSanPham"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        DonGia = Convert.ToDecimal(reader["DonGia"]),
                        ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                    };
                    list.Add(dto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Lỗi trong vw_HoaDonChiTietDAL.selectBySql: " + ex.Message);
                return null;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                  
                }
            }
            return list;
        }

        public override void insert(vw_HoaDonChiTietDTO entity)
        {
            throw new NotSupportedException("Không thể chèn dữ liệu vào view.");
        }

        public override void update(vw_HoaDonChiTietDTO entity)
        {
            throw new NotSupportedException("Không thể cập nhật dữ liệu trong view.");
        }

        public override void delete(string id)
        {
            throw new NotSupportedException("Không thể xóa dữ liệu từ view.");
        }
    }
}