#region NameSpace
using WebApp.Domain;
#endregion

namespace WebAPI.BLL.Interface.Login
{
    #region ILoginBLL
    /// <summary>
    /// ILoginBLL
    /// </summary>
    public interface ILoginBLL
    {
        #region Login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        /// <returns></returns>
        public UserDomain Login(string username, string encryptedPassword);
        #endregion

        #region SignIn
        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public bool SignIn(UserDomain newUser);
        #endregion

        #region ResetPassword
        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(string username, string newPassword);
        #endregion
    }
    #endregion
}
