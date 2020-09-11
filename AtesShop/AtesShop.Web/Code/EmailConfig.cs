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
        
        public string PopulateNewAccountMail(string firstName, string lastName, string username, string email, string callbackUrl)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home" , new {  }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            var mailTitle = Resources.Resources.CreateAccountMailTitle;
            var mailReceiver = string.Format(Resources.Resources.CreateAccountMailReceiver, firstName, lastName);
            var mailFirstPar = Resources.Resources.CreateAccountMailFirstP;
            var userEmailInfo = string.Format(Resources.Resources.CreateAccountUserEmailInfo, email);
            var userNameInfo = string.Format(Resources.Resources.CreateAccountUserNameInfo, username);
            var buttonInfo = Resources.Resources.CreateAccountButtonInfo;
            var buttonLink = callbackUrl;
            var mailFooter = Resources.Resources.CreateAccountMailFooter;
            var mailFooterLink = contactUrl;
            var mailFooterLinkText = Resources.Resources.CreateAccountMailFooterLinkText;

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\create_account_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";
            
            try
            {
                messageBody = string.Format(
                    body, 
                    mailTitle, // {0}
                    homeUrl, // {1}
                    logoUrl, // {2}
                    mailReceiver, // {3}
                    mailFirstPar, // {4}
                    userEmailInfo, // {5}
                    userNameInfo, // {6}
                    buttonLink, // {7}
                    buttonInfo, // {8}
                    mailFooter, // {9}
                    mailFooterLink, // {10}
                    mailFooterLinkText // {11}
                    );
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return messageBody;
        }
        
        public string PopulateNewOrderMail(string firstName, string lastName, string orderNumber, string orderDate, string email, string orderTotal)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var orderStatusUrl = urlHelper.Action("Index", "Manage", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            var mailTitle = Resources.Resources.NewOrderMailTitle;
            var mailReceiver = string.Format(Resources.Resources.NewOrderMailReceiver, firstName, lastName);
            var mailFirstPar = string.Format(Resources.Resources.NewOrderMailFirstP, orderNumber);
            var mailSecondPar = Resources.Resources.NewOrderMailSecondP;
            var buttonInfo = Resources.Resources.NewOrderMailButtonInfo;
            var buttonLink = orderStatusUrl;
            var mailFooter = Resources.Resources.NewOrderMailFooter;
            var mailFooterLink = contactUrl;
            var mailFooterLinkText = Resources.Resources.NewOrderMailFooterLinkText;

            var bankInformation = Resources.Resources.NewOrderMailBankInformation;
            var orderNumberInfo = "<strong>" + Resources.Resources.OrderId + ": </strong>" + orderNumber;
            var orderDateInfo = "<strong>" + Resources.Resources.OrderDate + ": </strong>" + orderDate;
            var bankAccountNameInfo = "<strong>" + Resources.Resources.BankAccountName + ": </strong>" + Resources.Resources.PABankAccountName;
            var bankNameInfo = "<strong>" + Resources.Resources.BankName + ": </strong>" + Resources.Resources.PABankName;
            var branchNameInfo = "<strong>" + Resources.Resources.BankBranchName + ": </strong>" + Resources.Resources.PABankBranchName;
            var bankAccountNumberInfo = "<strong>" + Resources.Resources.BankAccountNumber + ": </strong>" + Resources.Resources.PABankAccountNumber;
            var totalPriceInfo = "<strong>" + Resources.Resources.OrderTotal +": </strong>" + orderTotal;


            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\order_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";

            try
            {
                messageBody = string.Format(
                    body, 
                    mailTitle, // {0}
                    homeUrl, // {1}
                    logoUrl, // {2}
                    mailReceiver, // {3}
                    mailFirstPar, // {4}
                    mailSecondPar, // {5}
                    buttonLink, // {6}
                    buttonInfo, // {7}
                    mailFooter, // {8}
                    mailFooterLink, // {9}
                    mailFooterLinkText, // {10}
                    bankInformation, // {11}
                    orderNumberInfo, // {12}
                    orderDateInfo, // {13}
                    bankAccountNameInfo, // {14}
                    bankNameInfo, // {15}
                    branchNameInfo, // {16}
                    bankAccountNumberInfo, // {17}
                    totalPriceInfo // {18}
                    );
            }
            catch (Exception ex)
            {

                throw;
            }

            return messageBody;
        }

        public string PopulateResetPasswordMail(string firstName, string lastName, string callbackUrl)
        {
            string body = string.Empty;
            var logoUrl = urlHelper.Action("Image", "Generic", new { id = 22 }, protocol: HttpContext.Current.Request.Url.Scheme);
            var homeUrl = urlHelper.Action("Index", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);
            var contactUrl = urlHelper.Action("Contact", "Home", new { }, protocol: HttpContext.Current.Request.Url.Scheme);

            var mailTitle = Resources.Resources.ResetPasswordMailTitle;
            var mailReceiver = string.Format(Resources.Resources.ResetPasswordMailReceiver, firstName, lastName);
            var mailFirstPar = Resources.Resources.ResetPasswordMailFirstP;
            var buttonInfo = Resources.Resources.ResetPasswordMailButtonInfo;
            var buttonLink = callbackUrl;
            var mailFooter = Resources.Resources.ResetPasswordMailFooter;
            var mailFooterLink = contactUrl;
            var mailFooterLinkText = Resources.Resources.ResetPasswordMailFooterLinkText;

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("\\App_Data\\email\\new_password_mail.html")))
            {
                body = reader.ReadToEnd();
            }

            string messageBody = "";

            try
            {
                messageBody = string.Format(
                    body,
                    mailTitle, // {0}
                    homeUrl, // {1}
                    logoUrl, // {2}
                    mailReceiver, // {3}
                    mailFirstPar, // {4}
                    buttonLink, // {5}
                    buttonInfo, // {6}
                    mailFooter, // {7}
                    mailFooterLink, // {8}
                    mailFooterLinkText // {9}
                    );
            }
            catch (Exception ex)
            {

                throw;
            }

            return messageBody;
        }
        

    }
}