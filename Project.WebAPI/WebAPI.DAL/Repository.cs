#region NameSpace
using ConfigManager.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Utilities;
using WebAPI.DAL;
#endregion

namespace WebAPI.DAL
{
    #region Repository
    /// <summary>
    /// Repository
    /// </summary>
    public class Repository : IDALRepository
    {
        #region Variables

        #region _configurationManager
        /// <summary>
        /// _configurationManager
        /// </summary>
        public IConfigurationManager ConfigurationManager { get; set; }
        #endregion

        #endregion

        #region Constructor
        public Repository(IConfigurationManager config)
        {
            ConfigurationManager = config;
        }
        #endregion

        #region Public Methods

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool Add(string storedProcedureName, DynamicParameters param = null) 
        {
            bool status = false;

            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    status = conn.Execute(storedProcedureName, param: param, commandType: CommandType.StoredProcedure, commandTimeout: Constant.CommandTimeout) > 0 ? true : false;
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool Delete(string storedProcedureName, DynamicParameters param = null)
        {
            bool status = false;

            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    status = conn.Execute(storedProcedureName, param: param, commandType: CommandType.StoredProcedure, commandTimeout: Constant.CommandTimeout) > 0 ? true : false;
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool Update(string storedProcedureName, DynamicParameters param = null)
        {
            bool status = false;

            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    status = conn.Execute(storedProcedureName, param: param, commandType: CommandType.StoredProcedure, commandTimeout: Constant.CommandTimeout) > 0 ? true : false;
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }
        #endregion

        #region Select
        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T> Select<T>(string storedProcedureName, DynamicParameters param = null) where T : class, new()
        {
            List<T> obj = null;

            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    obj = conn.Query<T>(storedProcedureName, param: param, commandType: CommandType.StoredProcedure, commandTimeout: Constant.CommandTimeout).ToList();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return obj;
        }
        #endregion

        #region SelectAll
        /// <summary>
        /// SelectAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public List<T> SelectAll<T>(string storedProcedureName) where T : class, new()
        {
            List<T> obj = null;

            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    obj = conn.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure, commandTimeout: Constant.CommandTimeout).ToList();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return obj;
        }
        #endregion

        #endregion

        #region Private Methods

        #region OpenConnection
        /// <summary>
        /// OpenConnection
        /// </summary>
        /// <returns></returns>
        private SqlConnection OpenConnection()
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            return conn;
        }
        #endregion

        #endregion
    }
    #endregion
}
