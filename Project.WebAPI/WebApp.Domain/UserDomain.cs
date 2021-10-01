#region NameSpace
using System;
#endregion

namespace WebApp.Domain
{
    #region UserDomain
    /// <summary>
    /// UserDomain
    /// </summary>
    public class UserDomain
    {
        #region UserID
        /// <summary>
        /// UserID
        /// </summary>
        public long UserID { get; set; }
        #endregion

        #region UserName
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
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

        #region CreatedBy
        /// <summary>
        /// CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }
        #endregion

        #region CreatedDate
        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        #endregion

        #region ModifiedBy
        /// <summary>
        /// ModifiedBy
        /// </summary>
        public long ModifiedBy{ get; set; }
        #endregion

        #region ModifiedDate
        /// <summary>
        /// ModifiedDate
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        #endregion
    }
    #endregion
}
