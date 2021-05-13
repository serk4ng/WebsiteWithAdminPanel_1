using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Helpers
{
    public class MailHelpers
    {
        public bool Send(string receivermail, string subject, string message, string cCMail, string username, string password, string host, int port, string mail)
        {
            try
            {
                var sendermail = new MailAddress(mail, "");
                var smtp = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(username, password),
                 
                 
                   
            };

                using (var mess = new MailMessage()
                {
                    From = sendermail,
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = message
                  
                   
                })
              
                {
                    mess.To.Add(receivermail);
                    if (cCMail != null)
                    {
                        mess.CC.Add(cCMail);
                    }
                 
                    smtp.Send(mess);
                }

                return true;
            }
            catch (Exception e)
            {
                string exp = e.Message;
                return false;
            }
        }
    }
}
