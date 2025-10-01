using System.Net;
using System.Net.Mail;

namespace MVC.Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var clint = new SmtpClient("smtp.gmail.com", 587);
            clint.EnableSsl = true;
            clint.Credentials=new NetworkCredential("youssefahmed5641@gmail.com", "swzcuychwrmdpoui");
            clint.Send("youssefahmed5641@gmail.com", email.To, email.Subject, email.Body);

        }
    }
}
