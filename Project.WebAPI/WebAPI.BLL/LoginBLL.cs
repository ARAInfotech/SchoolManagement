#region NameSpace
using Dapper;
using System.Linq;
using WebAPI.BLL.Interface.Login;
using WebAPI.DAL;
using WebApp.Domain;
#endregion

namespace WebAPI.BLL
{
    #region WeatherForecastBLL
    /// <summary>
    /// WeatherForecastBLL
    /// </summary>
    public class LoginBLL : ILoginBLL
    {
        #region Variables
        /// <summary>
        /// _iDALRepository
        /// </summary>
        IDALRepository _iDALRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idALRepository"></param>
        /// <param name=""></param>
        public LoginBLL(IDALRepository idALRepository)
        {
            _iDALRepository = idALRepository;
        }
        #endregion

        #region Public Methods

        #region GetUserData
        /// <summary>
        /// GetUserData
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        /// <returns></returns>
        public UserDomain Login(string username, string encryptedPassword)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Username", username);
            param.Add("@Password", encryptedPassword);

            UserDomain user = _iDALRepository.Select<UserDomain>("[dbo].[UserByCredentialsSelect]", param).FirstOrDefault();

            return user;
        }
        #endregion

        #region ResetPassword
        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(string username, string newPassword)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region SignIn
        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public bool SignIn(UserDomain newUser)
        {
            DynamicParameters param = new DynamicParameters();

            return _iDALRepository.Add("[dbo].[UserByCredentialsSelect]", param);
        }
        #endregion

        #endregion
    }
    #endregion
}
