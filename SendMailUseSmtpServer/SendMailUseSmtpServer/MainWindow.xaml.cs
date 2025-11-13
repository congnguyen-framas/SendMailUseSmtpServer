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

                //ToMailAddress = "cong.nguyen@framas.com",
                //CCMailAddress = "ndcong08cddv02@gmail.com",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnalbleSsl = true,
                isBodyHtml = false,
                UseDefaultCredentials = false,
                Subject = "Test",
                Body = $"Truck pack{Environment.NewLine}EmployeeId: 7387{Environment.NewLine} Request out."
            };
            #endregion
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            mailHelper.ToMailAddress = txtToEmail.Text;
            mailHelper.CCMailAddress = txtCCEmail.Text;
            mailHelper.Subject = $"[{DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}] {txtSubject.Template}";
            mailHelper.Body = $"{txtBody.Text}";

            Task<string> task = new Task<string>(() => mailHelper.SendEmail());
            task.Start();
            labStatus.Content = task.Result;
        }
    }
}
