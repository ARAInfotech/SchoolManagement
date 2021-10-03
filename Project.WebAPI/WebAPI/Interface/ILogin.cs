#region NameSpace
using WebAPI.Model;
using WebApp.Domain;
#endregion


namespace WebAPI.Interface
{
    #region ILogin
    /// <summary>
    /// ILogin
    /// </summary>
    public interface ILogin
    {
        #region Login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public APIReturnModel<UserModel> Login(LoginModel login);
        #endregion

        #region SignIn
        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public APIReturnModel<bool> SignIn(UserModel newUser);
        #endregion

        #region ResetPassword
        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public APIReturnModel<bool> ResetPassword(string username, string newPassword);
        #endregion

        #region ForgetPassword
        /// <summary>
        /// ForgetPassword
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public APIReturnModel<bool> ForgetPassword(string username);
        #endregion
    }
    #endregion
}
