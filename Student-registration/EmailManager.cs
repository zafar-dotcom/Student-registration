using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using MySqlX.XDevAPI;
using System.Net.Http;

namespace Student_registration
{
    public class EmailManager
    {

        public static void SendEmail(string From, string Subject, string Body, string To, string Password, string UserID, string SMTPPort, string Host)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(From);
                mail.Sender = new MailAddress(From);
                mail.To.Add(To);
                mail.IsBodyHtml = true;
                mail.Subject = Subject;
                mail.Body = Body;

                SmtpClient smtp = new SmtpClient(Host, int.Parse(SMTPPort));
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(From, Password);
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                // Handle SMTP exception
                Console.WriteLine($"SMTP Exception: {ex.Message}");
                throw; // Re-throw to see the full error and stack trace
            }
            catch (Exception ex)
            {
                // Handle general exception
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
        public async Task SendEmailAsync(string From, string Subject, string Body, string To, int SMTPPort, string Host)
        {
            var smtpClient = new SmtpClient(Host)
            {
                Port = SMTPPort,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("", ""),// No authentication
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,


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

