#region NameSpace
using System.IO;
#endregion

namespace FileManagement.Model
{
    #region FileMngtModel
    /// <summary>
    /// FileMngtModel
    /// </summary>
    public class FileMngtModel
    {
        #region FilePath
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; }
        #endregion

        #region FileName
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }
        #endregion

        #region ExisingFileName
        /// <summary>
        /// ExisingFileName used for replace an existing file with new
        /// </summary>
        public string ExisingFileName { get; set; }
        #endregion

        #region FileType
        /// <summary>
        /// FileType
        /// </summary>
        public string FileType { get; set; }
        #endregion

        #region FileContent
        /// <summary>
        /// FileContent
        /// </summary>
        public MemoryStream FileContent { get; set; }
        #endregion
    }
    #endregion
}
