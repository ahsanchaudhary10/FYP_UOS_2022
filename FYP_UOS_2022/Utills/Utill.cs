using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FYP_UOS_2022.Utills
{
    public class Utill
    {
        public static void SendEmailForForgotPassword(string receiverEmail, int code)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(ConfigurationManager.AppSettings["Email"]);
                message.To.Add(new MailAddress(receiverEmail));
                message.Subject = "FYP Repositry Forgot Password Code";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "Your Code for Forget Password is " + code;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"]);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}