#region NameSpace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
#endregion

namespace WebAPI.Common
{
    #region ReturnData
    /// <summary>
    /// ReturnData
    /// </summary>
    public static class ReturnData
    {
        #region Public Methods

        #region SuccessResponse
        /// <summary>
        /// SuccessResponse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static APIReturnModel<T> SuccessResponse<T>(T obj) where T : class, new()
        {
            APIReturnModel<T> returnModel = new APIReturnModel<T>();

            returnModel.ErrorMessage = string.Empty;
            returnModel.IsSuccess = true;
            returnModel.Result = obj;
            returnModel.IsError = false;

            return returnModel;
        }
        #endregion

        #region ErrorResponse
        /// <summary>
        /// ErrorResponse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static APIReturnModel<T> ErrorResponse<T>(string errorMessage) where T : class, new()
        {
            APIReturnModel<T> returnModel = new APIReturnModel<T>();

            returnModel.ErrorMessage = errorMessage;
            returnModel.IsSuccess = false;
            returnModel.Result = null;
            returnModel.IsError = true;

            return returnModel;
        }
        #endregion

        #endregion
    }
    #endregion
}
