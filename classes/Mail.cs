using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace dotnet_webform_site.classes
{

    public class Mail
    {

        protected static Boolean html = true;

        protected static Boolean credentials = false;

        public static Boolean send(Hashtable data)
        {
            try {
                string to = (string)data["to"];
                string subject = (string)data["subject"];
                string body = (string)data["body"];
                Boolean template = (Boolean)data["template"];

                var mail = new MailMessage();
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.IsBodyHtml = Mail.html;

                if(!template) {
                    mail.Body = body;
                } else {
                    mail.Body = View.make(body);
                }

                var mailclient = new SmtpClient();
                mailclient.UseDefaultCredentials = Mail.credentials;
                mailclient.EnableSsl = false;
                mailclient.Send(mail);

                return true;
            } catch (Exception ex) {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.Write(ex.StackTrace);

                return false;
            }
        }

    }

}