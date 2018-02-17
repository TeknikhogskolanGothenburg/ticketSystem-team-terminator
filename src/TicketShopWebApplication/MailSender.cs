using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
namespace TicketShopWebApplication
{


        public class MailSender
        {

            public void SendEmail(string from, string to, string subject, string body)
            {
                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                {
                    return;
                }
                SmtpClient client = new SmtpClient();
                MailMessage message = new MailMessage();
                message.Body = body;
                message.Sender = new MailAddress(from);
                message.To.Add(to);
                message.Subject = subject;

                client.Send(message);
            }
        }
}
