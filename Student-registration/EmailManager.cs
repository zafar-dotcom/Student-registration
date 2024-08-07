using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using MySqlX.XDevAPI;
using System.Net.Http;

namespace Student_registration
{
    public class EmailManager
    {
        public static void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = "mohammadzafarft12555@gmail.com";
            Password = "fintechtik@gmail.com";
            SMTPPort = "587";
            Host = "smtp.gmail.com";
        }
        public static void SendEmail(string From, string Subject, string Body, string To, string Password, string UserID, string SMTPPort, string Host)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress(From);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true; // Optional: set to true if sending HTML email

                SmtpClient smtp = new SmtpClient();
                smtp.Host = Host;
                smtp.Port = Convert.ToInt16(SMTPPort);
                smtp.Credentials = new System.Net.NetworkCredential(UserID, Password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                // Handle SMTP exception
                Console.WriteLine($"SMTP Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general exception
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        public async Task SendEmailAsync(string From, string Subject, string Body, string To, int SMTPPort, string Host)
        {
            var smtpClient = new SmtpClient(Host)
            {
                Port = SMTPPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("", ""),// No authentication
                EnableSsl = true
                

            };
            bool isBodyHtml = IsHtml(Body);
            var mailMessage = new MailMessage
            {
                From = new MailAddress(From),
                Subject = Subject,
                Body = Body,
                IsBodyHtml = isBodyHtml
            };

            mailMessage.To.Add(To);
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
                throw;
            }
        }
        public bool IsHtml(string input)
        {
            string htmlPattern = @"<[^>]+>";
            return Regex.IsMatch(input, htmlPattern);
        }
    }
}

