#region NameSpace
using WebApp.Domain;
#endregion

namespace WebAPI.BLL.Interface
{
    #region IWeatherForecast
    /// <summary>
    /// IWeatherForecast
    /// </summary>
    public interface IWeatherForecast
    {
        #region GetUserData
        /// <summary>
        /// GetUserData
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        /// <returns></returns>
        public UserDomain GetUserData(string username, string encryptedPassword);
        #endregion
    }
    #endregion
}
