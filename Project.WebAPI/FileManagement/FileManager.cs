#region NameSpace
using FileManagement.Interface;
using FileManagement.Model;
using System;
using System.Collections.Generic;
using System.IO;
#endregion


namespace FileManagement
{
    #region FileManager
    /// <summary>
    /// FileManager
    /// </summary>
    public class FileManager : IFileService
    {
        #region Public Methods

        #region AddFile
        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddFile(FileMngtModel model)
        {
            bool status = false;

            try
            {
                status = SaveStreamAsFile(model.FilePath, model.FileContent, model.FileName);
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region AddFile
        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public bool AddFile(List<FileMngtModel> lstModel)
        {
            bool status = false;

            try
            {
                foreach (FileMngtModel model in lstModel)
                {
                    status = SaveStreamAsFile(model.FilePath, model.FileContent, model.FileName);
                }
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region DeleteFile
        /// <summary>
        /// DeleteFile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteFile(FileMngtModel model)
        {
            bool status = false;

            try
            {
                status = RemoveFile(model.FilePath, model.FileName);
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region DeleteFile
        /// <summary>
        /// DeleteFile
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public bool DeleteFile(List<FileMngtModel> lstModel)
        {
            bool status = false;

            try
            {
                foreach (FileMngtModel model in lstModel)
                {
                    status = RemoveFile(model.FilePath, model.FileName);
                }
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region ReplaceFile
        /// <summary>
        /// ReplaceFile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ReplaceFile(FileMngtModel model)
        {
            bool status = false;

            try
            {
                status = RemoveFile(model.FilePath, model.ExisingFileName);

                if (status)
                {
                    status = SaveStreamAsFile(model.FilePath, model.FileContent, model.FileName);
                }
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region ReplaceFile
        /// <summary>
        /// ReplaceFile
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public bool ReplaceFile(List<FileMngtModel> lstModel)
        {
            bool status = false;

            try
            {
                foreach (FileMngtModel model in lstModel)
                {
                    status = RemoveFile(model.FilePath, model.ExisingFileName);

                    if (status)
                    {
                        status = SaveStreamAsFile(model.FilePath, model.FileContent, model.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }

            return status;
        }
        #endregion

        #region SelectFile
        /// <summary>
        /// SelectFile
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileMngtModel SelectFile(string folderPath, string fileName)
        {
            FileMngtModel model = new FileMngtModel();

            try
            {
                model.FileName = fileName;
                model.FilePath = folderPath;
                model.FileContent = ReadFileAsStream(folderPath, fileName);
            }
            catch(Exception e)
            {
                throw;
            }

            return model;
        }
        #endregion

        #region SelectFile
        /// <summary>
        /// SelectFile
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="lstFileNames"></param>
        /// <returns></returns>
        public List<FileMngtModel> SelectFile(string folderPath, List<string> lstFileNames)
        {
            List<FileMngtModel> lstModel = new List<FileMngtModel>();

            try
            {
                foreach (string fileName in lstFileNames)
                {
                    lstModel.Add(new FileMngtModel
                    {
                        FileName = fileName,
                        FilePath = folderPath,
                        FileContent = ReadFileAsStream(folderPath, fileName)
                    });
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return lstModel;
        }
        #endregion

        #endregion

        #region Private Methods

        #region SaveStreamAsFile
        /// <summary>
        /// SaveStreamAsFile
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="inputStream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool SaveStreamAsFile(string filePath, MemoryStream inputStream, string fileName)
        {
            bool status = false, isException = false;

            try
            {
                DirectoryInfo info = new DirectoryInfo(filePath);

                if (!info.Exists)
                {
                    info.Create();
                }

                string path = Path.Combine(filePath, fileName);
                using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
                {
                    inputStream.CopyTo(outputFileStream);
                }
            }
            catch (Exception e)
            {
                isException = true;

                throw;
            }

            finally
            {
                status = !isException;
            }

            return status;
        }
        #endregion

        #region RemoveFile
        /// <summary>
        /// RemoveFile
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool RemoveFile(string filePath, string fileName)
        {
            bool status = false, isException = false;

            try
            {
                string path = Path.Combine(filePath, fileName);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception e)
            {
                isException = true;

                throw;
            }

            finally
            {
                status = !isException;
            }

            return status;
        }
        #endregion

        #region ReadFileAsStream
        /// <summary>
        /// ReadFileAsStream
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private MemoryStream ReadFileAsStream(string filePath, string fileName)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    string path = Path.Combine(filePath, fileName);

                    using (FileStream file = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write))
                    {
                        ms.CopyTo(file);
                    }

                    return ms;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
