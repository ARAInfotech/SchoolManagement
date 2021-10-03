#region Namespace
#endregion

namespace ConfigManager.Interfaces
{
    #region IConfigurationManager
    /// <summary>
    /// IConfigurationManager
    /// </summary>
    public interface IConfigurationManager
    {
        #region GetConfigValue
        /// <summary>
        /// GetConfigValue
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigValue(string key);
        #endregion

        #region GetConnectionString
        /// <summary>
        /// GetConnectionString
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString();
        #endregion

        #region GetJWTConfig
        /// <summary>
        /// GetJWTConfig
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetJWTConfig(string key);
        #endregion

        #region GetEmailConfig
        /// <summary>
        /// GetEmailConfig
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetEmailConfig(string key);
        #endregion
    }
    #endregion
}
