#region NameSpace
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Text;
#endregion

namespace WebAPI.Helpers
{
    #region HttpResponseExceptionFilter
    /// <summary>
    /// HttpResponseExceptionFilter
    /// </summary>
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        #region Variables

        #endregion

        #region Public Methods

        #region OnException
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            WriteExceptionToFile(context.Exception);
        }
        #endregion

        #endregion

        #region Private Methods

        #region WriteExceptionToFile
        /// <summary>
        /// WriteExceptionToFile
        /// </summary>
        /// <param name="ex"></param>
        private void WriteExceptionToFile(Exception ex)
        {
            StringBuilder filePath = new StringBuilder(Directory.GetCurrentDirectory() + "\\ErrorLog");

            if (!Directory.Exists(filePath.ToString()))
            {
                Directory.CreateDirectory(filePath.ToString());
            }

            filePath.Append("\\ErrorLog_" + DateTime.Today.ToString("dd_MM_yyyy") + ".txt");

            if(ex != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath.ToString(), true))
                {
                    writer.WriteLine("----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                    writer.WriteLine("----------------------------------------------------------------------------");
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
