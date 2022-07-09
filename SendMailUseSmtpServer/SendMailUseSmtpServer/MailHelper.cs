using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SendMailUseSmtpServer
{
    public class MailHelper
    {
        public MailHelper()
        {
            isBodyHtml = true;
            DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        public MailAddress FromMailAddress { get; set; }
        public string Password { get; set; }
        public string  Host { get; set; }
        public string Port { get; set; }
        public bool EnalbleSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string  Subject { get; set; }
        public bool isBodyHtml { get; set; }
        public string Body { get; set; }
        public SmtpDeliveryMethod DeliveryMethod { get; set; }
        public string ToMailAddress { get; set; }
        public string CCMailAddress { get; set; }

        MailMessage message;
        SmtpClient smtp;
        
        public bool SendEmail()
        {
            try
            {
                message = new MailMessage();
                smtp = new SmtpClient();
                message.From = FromMailAddress;
                message.To.Add(ToMailAddress);
                message.CC.Add(CCMailAddress);
                message.Subject = Subject;
                message.IsBodyHtml = isBodyHtml;
                message.Body = Body;
                smtp.Port = Convert.ToInt32(Port);
                smtp.TargetName = "STARTTLS/smtp.office365.com";
                smtp.Host = Host;
                smtp.EnableSsl = EnalbleSsl;
                smtp.UseDefaultCredentials = UseDefaultCredentials;
                smtp.Credentials = new NetworkCredential(FromMailAddress.Address, Password);
                smtp.DeliveryMethod = DeliveryMethod;
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
    }
}
