using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PolyGear_UTIL_SOF
{
    public class ImageUtil
    {
        /// <summary>
        /// Kiểm tra file được chọn có phải là ảnh không
        /// </summary>
        /// <param name="openFileDialog">Đối tượng đọc file được chọn</param>
        public static Boolean IsImage(OpenFileDialog openFileDialog)
        {
            string sourceFilePath = openFileDialog.FileName;
            string fileExtension = Path.GetExtension(sourceFilePath).ToLower();
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp" };
            return imageExtensions.Contains(fileExtension);
        }

        /// <summary>
        /// Sao chép ảnh được chọn vào thư mục Images
        /// </summary>
        /// <param name="openFileDialog">Đối tượng đọc file được chọn</param>
        /// <returns>Tên file theo mốc thời gian lưu</returns>
        public string save(OpenFileDialog openFileDialog)
        {
            string sourceFilePath = openFileDialog.FileName;

            // Kiểm tra file có phải là hình ảnh không trước khi lưu
            if (!IsImage(openFileDialog))
            {
                throw new Exception("File không phải là hình ảnh hợp lệ!");
            }

            string projectFolder = Path.Combine(Application.StartupPath, "Images");

            if (!Directory.Exists(projectFolder))
            {
                Directory.CreateDirectory(projectFolder);
            }

            // Lấy ngày tháng và thời gian hiện tại sử dụng cho tên ảnh
            string fileExtension = Path.GetExtension(sourceFilePath).ToLower();
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
            string destinationFilePath = Path.Combine(projectFolder, fileName);

            // Thực hiện sao chép file
            try
            {
                File.Copy(sourceFilePath, destinationFilePath, true);
                return fileName; // Trả về tên file đã lưu
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sao chép file: " + ex.Message);
            }
        }

        /// <summary>
        /// Đọc ảnh được chọn từ thư mục Images
        /// </summary>
        /// <param name="fileName">Tên file cần đọc</param>
        /// <returns>Bitmap file ảnh đã đọc được</returns>
        public Bitmap load(string fileName)
        {
            try
            {
                string projectFolder = Path.Combine(Application.StartupPath, "Images");
                return new Bitmap(Path.Combine(projectFolder, fileName));
            }
            catch
            {
                return null;
            }
        }
    }
}
