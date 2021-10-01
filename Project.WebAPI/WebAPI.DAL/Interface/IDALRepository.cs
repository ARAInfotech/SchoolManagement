#region NameSpace
using Dapper;
using System.Collections.Generic;
#endregion

namespace WebAPI.DAL
{
    #region IDALRepository
    /// <summary>
    /// IDALRepository
    /// </summary>
    public interface IDALRepository
    {
        #region Public Interface

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Update(string storedProcedureName, DynamicParameters param = null);
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Delete(string storedProcedureName, DynamicParameters param = null);
        #endregion

        #region Select
        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        List<T> Select<T>(string storedProcedureName, DynamicParameters param = null) where T : class, new();
        #endregion

        #region SelectAll
        /// <summary>
        /// SelectAll
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        List<T> SelectAll<T>(string storedProcedureName) where T : class, new();
        #endregion

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Add(string storedProcedureName, DynamicParameters param = null);
        #endregion

        #endregion
    }
    #endregion
}
