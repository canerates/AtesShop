using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace AtesShop.Web.Code
{
    public class CustomEmailService
    {
        public async Task SendEmail(string toAddress, string fromAddress, string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress);
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
        
    }
}