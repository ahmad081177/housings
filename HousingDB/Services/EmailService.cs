
using System.Net;
using System.Net.Mail;

namespace HousingDB.Services
{
    //See https://docs.google.com/document/d/1-naW1AW-xv_bhJFC1KHo_QbQrtiu_YCzgkOY2fn_GEM/edit#heading=h.51lh3iio1qpt
    public class EmailService
    {
        private IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            configuration = configuration;
        }
        public async Task SendEmail(string to, string subject, string body, bool isBodyHTML = true)
        {
            IConfigurationSection config = configuration.GetSection("Email");
            if(config!=null)
            {
                //read from the config from.mail, from.display, password
                string from = config["from:mail"];
                string display = config["from:display"];
                string emailPassword = config["password"];

                if (string.IsNullOrEmpty(emailPassword) || string.IsNullOrEmpty(from))
                    throw new Exception("Missing Email section in the appsettings");

                var fromEmail = new MailAddress(from, display);
                var toEmail = new MailAddress(to);
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 5000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, emailPassword)
                };
                using var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHTML,
                };
                try
                {
                    await smtp.SendMailAsync(message);
                }
                catch
                {

                }
            }
        }
    }
}