using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{

    public class MailHandler
    {
        public string host;
        public int port;
        public string pasword;
        public string from;
        public string to;
        public string subject;
        public string body;
        private SmtpClient client;
        private MailMessage message;

        public  MailHandler()
        {
            // ta bort dessa om vi har andra, hårdkodade för nu.

            client = new SmtpClient();

            message = new MailMessage();


        }
        public void SEND()
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                throw new Exception();
            }
            message.Body = body;
            client.Host = host;
            message.From = new MailAddress(from);
            message.Sender = new MailAddress(from);
            message.To.Add(to);
            message.Subject = subject;
            message.IsBodyHtml = true;
            client.EnableSsl = true;
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(from, pasword);

            client.Send(message);
        }
    }
}
