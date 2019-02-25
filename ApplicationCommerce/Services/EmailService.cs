using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
 using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;


namespace ApplicationCommerce.Services
{

    public class EmailService
    {
        public static bool SendEmail(string nome,string email, string assunto, string corpo)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Aplicação web", "applicationwebcoremvc"));
                message.To.Add(new MailboxAddress(nome, email));
                message.Subject =assunto;
                message.Body = new TextPart("html")
                {
                    Text = corpo
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com",587);
                    client.Authenticate("applicationwebcoremvc", "AplicationWebcore1.");
                    client.Send(message);
                    client.Disconnect(false);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

