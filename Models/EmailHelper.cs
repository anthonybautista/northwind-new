// from https://www.yogihosting.com/aspnet-core-identity-password-reset/

using System.Net.Mail;
 
namespace Northwind.Models
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("northwind-recovery@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));
 
            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;
 
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("northwind-recovery@gmail.com", "B@nanas1");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
 
            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (SmtpException)
            {
                // log exception
                
            }
            return false;
        }
    }
}