#region Namespace
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConfigManager.Interfaces;
#endregion

namespace WebAPI.Common
{
    #region BaseController
    /// <summary>
    /// BaseController
    /// </summary>
    public class BaseController : ControllerBase
    {
        #region variables

        #region _configurationManager
        /// <summary>
        /// _configurationManager
        /// </summary>
        public IConfigurationManager _configurationManager { get; set; }
        #endregion

        #endregion

        #region Constructor - BaseController
        /// <summary>
        /// BaseController
        /// </summary>
        /// <param name="config"></param>
        public BaseController(IConfigurationManager config)
        {
            this._configurationManager = config;
        }
        #endregion
    }
    #endregion
}
