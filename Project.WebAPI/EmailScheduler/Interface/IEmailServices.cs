#region NameSpace
using EmailScheduler.Model;
using System.Collections.Generic;
#endregion

namespace EmailScheduler.Interface
{
    #region IEmailServices
    /// <summary>
    /// IEmailServices
    /// </summary>
    public interface IEmailServices
    {
        #region SendEmail
        /// <summary>
        /// SendEmail
        /// </summary>
        /// <param name="emailModel"></param>
        public void SendEmail(EmailModel emailModel);
        #endregion
    }
    #endregion
}
