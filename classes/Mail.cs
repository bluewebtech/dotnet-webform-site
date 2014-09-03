using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace dotnet_webform_site.classes
{

    public class Mail
    {

        protected static Boolean html = true;

        protected static Boolean credentials = false;

        /**
         * Send the mail message.
         * 
         * @param Hashtable data
         * 
         * return Boolean
         */
        public static Boolean send(System.Collections.Hashtable data)
        {
            try {
                string to = (string) data["to"];
                string subject = (string) data["subject"];
                string body = (string) data["body"];
                Hashtable values = (Hashtable)data["data"];
                Boolean template = (Boolean) data["template"];

                var mail = new MailMessage();
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.IsBodyHtml = Mail.html;

                if(!template) {
                    mail.Body = body;
                } else {
                    mail.Body = View.make(body, values);
                }

                var mailclient = new SmtpClient();
                mailclient.UseDefaultCredentials = Mail.credentials;
                mailclient.EnableSsl = false;
                mailclient.Send(mail);

                return true;
            } catch (Exception ex) {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
                System.Web.HttpContext.Current.Response.Write(ex.StackTrace);

                return false;
            }
        }

    }

}