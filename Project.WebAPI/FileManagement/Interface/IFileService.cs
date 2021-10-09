#region NameSpace
using FileManagement.Model;
using System.Collections.Generic;
#endregion

namespace FileManagement.Interface
{
    #region IFileService
    /// <summary>
    /// IFileService
    /// </summary>
    public interface IFileService
    {
        #region AddFile
        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddFile(FileMngtModel model);
        #endregion

        #region AddFile
        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public bool AddFile(List<FileMngtModel> lstModel);
        #endregion

        #region SelectFile
        /// <summary>
        /// Select one file from folder path
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileMngtModel SelectFile(string folderPath, string fileName);
        #endregion

        #region SelectFile
        /// <summary>
        /// Select multiple files from same folder
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public List<FileMngtModel> SelectFile(string folderPath, List<string> lstFileNames);
        #endregion

        #region ReplaceFile
        /// <summary>
        /// Replace one file from folder path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ReplaceFile(FileMngtModel model);
        #endregion

        #region ReplaceFile
        /// <summary>
        /// Replace multiple files
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public bool ReplaceFile(List<FileMngtModel> lstModel);
        #endregion

        #region DeleteFile
        /// <summary>
        /// Delete one file from folder path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteFile(FileMngtModel model);
        #endregion

        #region DeleteFile
        /// <summary>
        /// Delete multiple files
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public bool DeleteFile(List<FileMngtModel> lstModel);
        #endregion
    }
    #endregion
}
