using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

public class EmailService
{
    public static void SendAccountCredentials(string toEmail, string username, string password)
    {
        //var email = new MimeMessage();
        //email.From.Add(MailboxAddress.Parse("your_email@outlook.com")); // Email người gửi
        //email.To.Add(MailboxAddress.Parse(toEmail));                    // Email người nhận
        //email.Subject = "Thông tin tài khoản mới";

        //email.Body = new TextPart("plain")
        //{
        //    Text = $"Xin chào,\n\nBạn đã được tạo một tài khoản mới.\n\nTên đăng nhập: {username}\nMật khẩu: {password}\n\nVui lòng đổi mật khẩu sau khi đăng nhập lần đầu!!!\n\nTrân trọng."
        //};

        //using (var smtp = new SmtpClient())
        //{
        //    smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);

        //    // Thay bằng email thật và mật khẩu thật (khuyến nghị: bật xác thực hai bước và tạo mật khẩu ứng dụng nếu được)
        //    smtp.Authenticate("vnptkplay@outlook.com.vn", "taikhoantest123");

        //    smtp.Send(email);
        //    smtp.Disconnect(true);
        //}
    }
}
