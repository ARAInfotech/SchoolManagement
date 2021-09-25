#region NameSpace
using ConfigManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Utilities;
using WebAPI.BLL.Interface;
using WebAPI.Common;
using WebAPI.Model;
using WebApp.Domain;
#endregion

namespace WebAPI.Controller
{
    #region WeatherController
    /// <summary>
    /// WeatherController
    /// </summary>
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherController : ControllerBase
    {
        #region Constructor - WeatherController
        /// <summary>
        /// WeatherController
        /// </summary>
        /// <param name="config"></param>
        public WeatherController(IConfigurationManager config, IWeatherForecast weatherForecast)
        {
            this._weatherForecast = weatherForecast;
            this._configurationManager = config;
        }
        #endregion

        #region Variables
        private static readonly string[] Summeries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorhing"
        };

        #region _weatherForecast
        /// <summary>
        /// _weatherForecast
        /// </summary>
        private readonly IWeatherForecast _weatherForecast;
        #endregion

        #region _configurationManager
        /// <summary>
        /// _configurationManager
        /// </summary>
        public IConfigurationManager _configurationManager;
        #endregion

        #endregion

        #region Public Methods

        #region Index
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public APIReturnModel<List<WeatherForecast>> Index()
        {
            //throw new Exception("Test Exception");

            var rng = new Random();

            string s = this._configurationManager.GetConfigValue("ApplicationName");

            List<WeatherForecast> objModel = Enumerable.Range(1, 5).Select(i => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(i),
                TempC = rng.Next(-20, 55),
                Summary = Summeries[rng.Next(Summeries.Length)]
            }).ToList();

            APIReturnModel<List<WeatherForecast>> response = ReturnData.SuccessResponse<List<WeatherForecast>>(objModel);

            return response;
        }
        #endregion

        #region Login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login(UserModel login)
        {
            IActionResult response = Unauthorized();

            UserModel user = this.AuthenticateUser(login);

            if (user != null)
            {
                user.Token = this.GenerateJWTWebToken(user);
                response = this.Ok(new { UserDetails = user });
            }

            return response;
        }
        #endregion

        #region GetAllUserDetails
        /// <summary>
        /// GetAllUserDetails
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllUserDetails")]
        //[Authorize]
        public APIReturnModel<UserModel> GetAllUserDetails(UserModel login)
        {
            APIReturnModel<UserModel> response = new APIReturnModel<UserModel>();

            UserDomain dom = this._weatherForecast.GetUserData(login.UserName, login.Password.EncryptPassword());

            if (dom != null)
            {
                UserModel objModel = this.MapUserDomainToModel(dom);

                response = ReturnData.SuccessResponse<UserModel>(objModel);
            }
            else
            {
                response = ReturnData.ErrorResponse<UserModel>("User doesnot exist");
            }

            return response;
        }
        #endregion

        #endregion

        #region Private Methods

        #region GenerateJWTWebToken
        /// <summary>
        /// GenerateJWTWebToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateJWTWebToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configurationManager.GetJWTConfig("Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("UserID", user.EncUserID)
            };

            var token = new JwtSecurityToken(this._configurationManager.GetJWTConfig("Issuer"), this._configurationManager.GetJWTConfig("Issuer"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region AuthenticateUser
        /// <summary>
        /// AuthenticateUser
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            if (login.UserName == "Ajith" && login.Password.EncryptPassword() == "sI9PsHRaYcYfs/4pGXZpXu3Vjgc=")
            {
                user = new UserModel
                {
                    UserName = login.UserName,
                    Email = "Ajith.test@test.test",
                    EncUserID = "1001".Encrypt(),
                    Password = login.Password.EncryptPassword()
                };
            }

            return user;
        }
        #endregion

        #region MapUserDomainToModel
        /// <summary>
        /// MapUserDomainToModel
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        private UserModel MapUserDomainToModel(UserDomain dom)
        {
            UserModel model = new UserModel();

            model.Email = dom.Email;
            model.EncUserID = dom.UserID.Encrypt();
            model.UserName = dom.UserName;
            model.EncCreatedBy = dom.CreatedBy.Encrypt();
            model.CreatedDate = dom.CreatedDate;
            model.FirstName = dom.FirstName;
            model.LastName = dom.LastName;
            model.MobileNumber = dom.MobileNumber;
            model.EncModifiedBy = dom.ModifiedBy.Encrypt();
            model.ModifiedDate = dom.ModifiedDate;
            model.Token = this.GenerateJWTWebToken(model);

            return model;
        }
        #endregion

        #endregion
    }
    #endregion
}
