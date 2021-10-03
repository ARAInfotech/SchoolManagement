#region NameSpace
using System.Collections.Generic;
#endregion

namespace EmailScheduler.Model
{
    #region EmailModel
    /// <summary>
    /// EmailModel
    /// </summary>
    public class EmailModel
    {
        #region FromAddress
        /// <summary>
        /// FromAddress
        /// </summary>
        public string FromAddress { get; set; }
        #endregion

        #region ToAddress
        /// <summary>
        /// ToAddress
        /// </summary>
        public List<string> ToAddress { get; set; }
        #endregion

        #region CCAddress
        /// <summary>
        /// CCAddress
        /// </summary>
        public List<string> CCAddress { get; set; }
        #endregion

        #region BCCAddress
        /// <summary>
        /// BCCAddress
        /// </summary>
        public List<string> BCCAddress { get; set; }
        #endregion

        #region Subject
        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }
        #endregion

        #region EmailContent
        /// <summary>
        /// EmailContent
        /// </summary>
        public string EmailContent { get; set; }
        #endregion
    }
    #endregion
}
