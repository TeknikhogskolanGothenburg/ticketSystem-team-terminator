using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{

    public static class MailHandler
    {
        
        public static void SendEmail(string host, int port, string pasword, string from, string to, string subject, string body)
        {
            // ta bort dessa om vi har andra, hårdkodade för nu.
            host = "smtp.gmail.com";
            port = 587;

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                return;
            }
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            message.Body = body;
            client.Host = host;
            message.From = new MailAddress(from);
            message.Sender = new MailAddress(from);
            message.To.Add(to);
            message.Subject = subject;
            client.EnableSsl = true;
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pasword);
            
            client.Send(message);
        }
    }
}
