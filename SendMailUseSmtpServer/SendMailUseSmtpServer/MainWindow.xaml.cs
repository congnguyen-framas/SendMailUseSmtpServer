using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailUseSmtpServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MailHelper mailHelper;

        public MainWindow()
        {
            InitializeComponent();

            #region khởi tạo đối tượng sendEmail
            mailHelper = new MailHelper()
            {
                FromMailAddress = new MailAddress("fvn-itsupport@framas.com"),
                Host = "smtp.office365.com",
                Password = "fvnIT23!",
                Port = "587",

                ToMailAddress = "cong.nguyen@framas.com",
                CCMailAddress = "ndcong08cddv02@gmail.com",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnalbleSsl = true,
                isBodyHtml = false,
                UseDefaultCredentials = false,
                Subject = "Test",
                Body = null
            };
            #endregion

            #region kiem tra gui email bao cân lố
            //foreach (var item in productMixListBOM)
            //{
            //    if (item.MaterialCode.Contains("RCP") || item.MaterialCode.Contains("RMB") || item.MaterialCode.Contains("REX") || item.MaterialCode.Contains("RAD"))
            //    {
            //        if (Convert.ToDouble(item.ActualUsage) > (Convert.ToDouble(item.Total) + rangeColor))
            //        {
            //            mailHelper.Body = $"{mailHelper.Body}The material <{item.MaterialCode} - {item.MaterialName}> was used with the ratio <{item.ActualUsage}/{item.Total} > on <{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}> comparing to the planned ratio <{item.Quantity}>{Environment.NewLine}";
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(mailHelper.Body))
            //{
            //    mailHelper.Subject = "[Notification] - Recycled Management System";
            //    mailHelper.Body = $"The exceed allowed ratio was found in the item <{orderInfo.ItemCode} - {orderInfo.ItemName}>, color <{orderInfo.ColorCode} - {orderInfo.ColorName}>{Environment.NewLine}{mailHelper.Body}_________________{Environment.NewLine}NOTE: This email was sent from a notification-only email address, please do not reply to this email.";
            //    Debug.WriteLine(mailHelper.Body);

            //    Task<bool> task = new Task<bool>(() => mailHelper.SendEmail());
            //    task.Start();
            //    //task.ContinueWith(t => XtraMessageBox.Show(t.Result.ToString()));
            //}
            mailHelper.Subject = $"[{DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}]";
            mailHelper.Body = $"test mail server";

            Task<bool> task = new Task<bool>(() => mailHelper.SendEmail());
            task.Start();
            labStatus.Content = task.Result;
            #endregion
        }
    }
}
