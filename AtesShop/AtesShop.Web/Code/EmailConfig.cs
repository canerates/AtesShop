using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using AtesShop.Services;

namespace AtesShop.Web.Code
{
    public class CustomEmailService
    {
        UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

        public async Task SendEmail(string toAddress, string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(toAddress));
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (var smtpClient = new SmtpClient())
                        {
                            await smtpClient.SendMailAsync(mail);
                        }
                    }
                    finally
                    {
                        mail.Dispose();
                    }

                }
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    var status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable)
                    {
                        //Log
                        //Response.Write("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);

                    }
                    else
                    {
                        //Log
                        //Response.Write("Failed to deliver message to {0}", t.FailedRecipient);
                    }
                }
            }
            catch (SmtpException Se)
            {
                //Response.Write(Se.ToString());
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }
        }
        
        public string PopulateNewAccountMail(string firsName, string lastName, string username, string email, string callbackUrl)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home" , new {  }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\create_account_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";
            
            try
            {
                messageBody = string.Format(body, homeUrl, logoUrl, firsName, lastName, email, username, callbackUrl, contactUrl);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return messageBody;
        }
        
        public string PopulateNewOrderMail(string firsName, string lastName, string orderId, string orderDate, string email, string orderTotal, string transferDeadline)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var orderStatusUrl = urlHelper.Action("Index", "Manage", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\order_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";

            try
            {
                messageBody = string.Format(body, homeUrl, logoUrl, firsName, lastName, orderId, orderStatusUrl, orderStatusUrl, contactUrl, orderId, orderDate, orderTotal, transferDeadline);
            }
            catch (Exception ex)
            {

                throw;
            }

            return messageBody;
        }

        public string PopulateResetPasswordMail(string firsName, string lastName, string callbackUrl)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\new_password_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";

            try
            {
                messageBody = string.Format(body, homeUrl, logoUrl, firsName, lastName, callbackUrl, contactUrl);
            }
            catch (Exception ex)
            {

                throw;
            }

            return messageBody;
        }

        public string PopulateNewOrderMailForAdmin(string firsName, string lastName, string username, string email, string orderId, string orderDate, string orderTotal)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var orderStatusUrl = urlHelper.Action("Index", "Manage", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\order_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";

            try
            {
                messageBody = string.Format(body, homeUrl, logoUrl, firsName, lastName, orderId, orderStatusUrl, orderStatusUrl, contactUrl, orderId, orderDate, orderTotal);
            }
            catch (Exception ex)
            {

                throw;
            }

            return messageBody;
        }



    }
}