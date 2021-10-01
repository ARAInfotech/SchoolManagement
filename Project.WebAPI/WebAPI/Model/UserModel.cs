#region Namespace
using System;
#endregion

namespace WebAPI.Model
{
    #region UserModel
    /// <summary>
    /// UserModel
    /// </summary>
    public class UserModel
    {
        #region EncUserID
        /// <summary>
        /// EncryptedUserID
        /// </summary>
        public string EncUserID { get; set; }
        #endregion

        #region UserName
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
        #endregion

        #region Password
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region Email
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        #endregion

        #region FirstName
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        #endregion

        #region LastName
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        #endregion

        #region MobileNumber
        /// <summary>
        /// MobileNumber
        /// </summary>
        public string MobileNumber { get; set; }
        #endregion

        #region EncCreatedBy
        /// <summary>
        /// EncryptedCreatedBy
        /// </summary>
        public string EncCreatedBy { get; set; }
        #endregion

        #region CreatedDate
        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        #endregion

        #region EncModifiedBy
        /// <summary>
        /// EncryptedModifiedBy
        /// </summary>
        public string EncModifiedBy { get; set; }
        #endregion

        #region ModifiedDate
        /// <summary>
        /// ModifiedDate
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        #endregion

        #region Token
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        #endregion
    }
    #endregion
}
