using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Dist23Bridge.Helpers
{
    public static class MailHelper
    {
        const String HOST = "email-smtp.us-west-2.amazonaws.com";
        static string fromAddress = "noreply@eastershoreaa.org";

        // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
        // STARTTLS to encrypt the connection.
        const int PORT = 587;

        const String SMTP_USERNAME = "AKIAJNZBFYLLZHC3NPIQ";  // Replace with your SMTP username. 
        const String SMTP_PASSWORD = "AqZ2UqLaCgyLYWM+bLngTJlrluc8NH3J5+mwShqwYTKP";  // Replace with your SMTP password.

        private static SmtpClient client = new SmtpClient(HOST, PORT);
        public static bool SendEmailContact(string textBody, string nameFrom, string emailFrom, string destination,string Type = "")
        {
            client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
            client.EnableSsl = true;
            string body = nameFrom + " at " + emailFrom + " wrote <br/>";
            body += textBody;
            string emailTo = "stumay111@gmail";
            MailMessage mail = new MailMessage(fromAddress, emailTo);
            mail.Subject = "Email from website from " + nameFrom;
            mail.IsBodyHtml = true;
            mail.Body = body;
            try
            {
                client.Send(mail);
                SendConfirm(emailFrom);
                return true;
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                return false;
            }
        }
        public static bool SendEmailVolunteer(string textBody, string nameFrom, string emailFrom, string destination, string Type = "")
        {
            client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
            client.EnableSsl = true;
            string body = nameFrom + " at " + emailFrom + " wrote <br/>";
            body += textBody;
            string emailTo = "stumay111@gmail";
            MailMessage mail = new MailMessage(fromAddress, emailTo);
            mail.Subject = "Email from website from " + nameFrom;
            mail.IsBodyHtml = true;
            mail.Body = body;
            try
            {
                client.Send(mail);
                SendConfirm(emailFrom);
                return true;
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                return false;
            }
        }


        private static void SendConfirm(string to)
        {
            MailAddress toAddr = new MailAddress(to);
            MailMessage mail = new MailMessage(new MailAddress(fromAddress), toAddr);
            mail.Subject = "Thanks for contacting the District 23 Bridge Program";
            mail.Body = BuildBody("confirm");
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        private static string BuildBody(string type)
        {
            string emailStr = "";
            switch (type)
            {
                case "confirm":
                     emailStr += "<p>Thanks for contacting the District 23 Bridge Program.</p>";
                     emailStr += "<p>Someone will get back to you as soon as possible</p><br/>";
                     emailStr += "<p>Thanks,<br>";
                     emailStr += "District 23 Bridge Coordinator";
                     return emailStr;
                case "volunteer":
                    emailStr += "<p>Thanks for volunteering for service.</p>";
                    emailStr += "<p>Someone will get back to you as soon as possible</p><br/>";
                    emailStr += "<p>Thanks,<br>";
                    emailStr += "District 23 Bridge Coordinator";
                    return emailStr;
            }
            return "";
        }
    }
}

//ses-smtp-user.20151206-074104
//SMTP Username:
//AKIAJNZBFYLLZHC3NPIQ
//SMTP Password:
//AqZ2UqLaCgyLYWM+bLngTJlrluc8NH3J5+mwShqwYTKP