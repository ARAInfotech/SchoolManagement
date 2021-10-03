#region NameSpace
using ConfigManager.Interfaces;
using EmailScheduler.Interface;
using EmailScheduler.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
#endregion

namespace EmailScheduler
{
    #region EmailService
    /// <summary>
    /// EmailService
    /// </summary>
    public class EmailService : IEmailServices
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public EmailService(IConfigurationManager config)
        {
            this._configurationManager = config;
        }
        #endregion

        #region Variables

        #region _configurationManager
        /// <summary>
        /// _configurationManager
        /// </summary>
        private IConfigurationManager _configurationManager { get; set; }
        #endregion

        #endregion

        #region Public Methods

        #region SendEmail
        /// <summary>
        /// SendEmail
        /// </summary>
        /// <param name="emailModel"></param>
        public void SendEmail(EmailModel emailModel)
        {
            try
            {
                string host = this._configurationManager.GetEmailConfig("Host");
                int port = Convert.ToInt32(this._configurationManager.GetEmailConfig("Port"));

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(this._configurationManager.GetEmailConfig("FromMailAddress"), this._configurationManager.GetEmailConfig("Password"));
                    smtp.Timeout = 100000;

                    using (MailMessage message = new MailMessage())
                    {
                        message.From = new MailAddress(emailModel.FromAddress);
                        foreach (string mailID in emailModel.ToAddress)
                        {
                            message.To.Add(mailID);
                        }

                        if (emailModel.CCAddress != null)
                        {
                            foreach (string mailID in emailModel.CCAddress)
                            {
                                message.CC.Add(mailID);
                            }
                        }

                        if (emailModel.BCCAddress != null)
                        {
                            foreach (string mailID in emailModel.BCCAddress)
                            {
                                message.Bcc.Add(mailID);
                            }
                        }

                        message.Subject = emailModel.Subject;
                        message.Body = emailModel.EmailContent;
                        message.IsBodyHtml = true;
                        smtp.Send(message);
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region Private Methods

        #region WriteExceptionToFile

        #endregion

        #endregion
    }
    #endregion
}
