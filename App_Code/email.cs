using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;

using SendGrid;
using SendGrid.Helpers.Mail;





namespace SmtpMail
{

    public class Program
    {
        static void Main()
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress("selyblek@outlook.com", "Admin"));

                // From
                mailMsg.From = new MailAddress("forma@sbapps.com.mx", "Fomulario de contacto");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "subject";
                string text = "text body";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_a1b153a5163368099a04911e02f80594@azure.com", "sendgrid01");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

