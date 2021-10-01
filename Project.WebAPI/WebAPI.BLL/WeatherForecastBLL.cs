#region NameSpace
using Dapper;
using System.Collections.Generic;
using System.Linq;
using WebAPI.BLL.Interface;
using WebAPI.DAL;
using WebApp.Domain;
#endregion

namespace WebAPI.BLL
{
    #region WeatherForecastBLL
    /// <summary>
    /// WeatherForecastBLL
    /// </summary>
    public class WeatherForecastBLL : IWeatherForecast
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
        public WeatherForecastBLL(IDALRepository idALRepository)
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
        public UserDomain GetUserData(string username, string encryptedPassword)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Username", username);
            param.Add("@Password", encryptedPassword);

            UserDomain user = _iDALRepository.Select<UserDomain>("[dbo].[UserByCredentialsSelect]", param).FirstOrDefault();

            return user;
        }

        #endregion

        #endregion
    }
    #endregion
}
