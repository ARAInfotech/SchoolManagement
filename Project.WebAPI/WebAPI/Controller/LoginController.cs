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
using WebAPI.BLL.Interface.Login;
using WebAPI.Common;
using WebAPI.Interface;
using WebAPI.Model;
using WebApp.Domain;
#endregion

namespace WebAPI.Controller
{
    #region LoginController
    /// <summary>
    /// LoginController
    /// </summary>
    [Route("api/login/")]
    public class LoginController : ControllerBase, ILogin
    {
        #region Constructor - WeatherController
        /// <summary>
        /// WeatherController
        /// </summary>
        /// <param name="config"></param>
        public LoginController(IConfigurationManager config, ILoginBLL loginManager)
        {
            this._configurationManager = config;
            this._LoginManager = loginManager;
        }
        #endregion

        #region Variables

        #region _configurationManager
        /// <summary>
        /// _configurationManager
        /// </summary>
        public IConfigurationManager _configurationManager;
        #endregion

        #region _LoginManager
        /// <summary>
        /// _LoginManager
        /// </summary>
        public ILoginBLL _LoginManager;
        #endregion

        #endregion

        #region Public Methods

        #region Login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public APIReturnModel<UserModel> Login(LoginModel login)
        {
            APIReturnModel<UserModel> response = new APIReturnModel<UserModel>();

            if (login != null)
            {

                UserDomain dom = this._LoginManager.Login(login.Username, login.EncPassword);

                if (dom != null)
                {
                    UserModel objModel = this.MapUserDomainToModel(dom);

                    response = ReturnData.SuccessResponse<UserModel>(objModel);
                }
                else
                {
                    response = ReturnData.ErrorResponse<UserModel>("User doesnot exist");
                }
            }
            else
            {
                response = ReturnData.InvalidRequestResponse<UserModel>();
            }

            return response;
        }
        #endregion

        #region SignIn
        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("SignIn")]
        public APIReturnModel<bool> SignIn(UserModel newUser)
        {
            APIReturnModel<bool> response = new APIReturnModel<bool>();

            bool status = false;

            if (newUser != null)
            {
                UserDomain dom = this.MapUserModelToDomain(newUser);

                status = this._LoginManager.SignIn(dom);

                if (status)
                {
                    bool sendMailStatus = this.SendRegistrationSuccessEmail(newUser);

                    if (sendMailStatus)
                    {
                        response = ReturnData.SuccessResponse<bool>(status);
                    }
                    else
                    {
                        response = ReturnData.ErrorResponse<bool>("Email sending failed");
                    }
                }
                else
                {
                    response = ReturnData.ErrorResponse<bool>("User creation failed");
                }
            }
            else
            {
                response = ReturnData.InvalidRequestResponse<bool>();
            }

            return response;
        }
        #endregion

        #region ResetPassword
        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        [Authorize]
        public APIReturnModel<bool> ResetPassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ForgetPassword
        /// <summary>
        /// ForgetPassword
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost("ForgetPassword")]
        public APIReturnModel<bool> ForgetPassword(string username)
        {
            throw new NotImplementedException();
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

        #region MapUserModelToDomain
        /// <summary>
        /// MapUserModelToDomain
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        private UserDomain MapUserModelToDomain(UserModel model)
        {
            UserDomain dom = new UserDomain();

            dom.Email = model.Email;
            dom.UserID = model.EncUserID.DecryptToLong();
            dom.UserName = model.UserName;
            dom.CreatedBy = model.EncCreatedBy.DecryptToLong();
            dom.CreatedDate = model.CreatedDate;
            dom.FirstName = model.FirstName;
            dom.LastName = model.LastName;
            dom.MobileNumber = model.MobileNumber;
            dom.ModifiedBy = model.EncModifiedBy.DecryptToLong();
            dom.ModifiedDate = model.ModifiedDate;

            return dom;
        }
        #endregion

        #region SendRegistrationSuccessEmail
        /// <summary>
        /// SendRegistrationSuccessEmail
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        private bool SendRegistrationSuccessEmail(UserModel newUser)
        {
            return true;
        }

        #endregion

        #endregion
    }
    #endregion
}
