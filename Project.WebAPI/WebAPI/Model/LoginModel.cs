#region Namespace
using System;
#endregion

namespace WebAPI.Model
{
    #region LoginModel
    /// <summary>
    /// LoginModel
    /// </summary>
    public class LoginModel
    {
        #region Username
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        #endregion

        #region EncPassword
        /// <summary>
        /// EncryptedPassword
        /// </summary>
        public string EncPassword { get; set; }
        #endregion
    }
    #endregion
}
