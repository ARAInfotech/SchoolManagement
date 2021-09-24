using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


#region SqlCLR
/// <summary>
/// SqlCLR
/// </summary>
public static class SqlCLR
{
    #region Variables
    /// <summary>
    /// key
    /// </summary>
    private static readonly string key = "7007zu99r1v7696af11f9e7996af11fe";
    #endregion

    #region Public Methods

    #region Encrypt
    /// <summary>
    /// Encrypt
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [SqlFunction()]
    public static string Encrypt(string str)
    {
        byte[] iv = new byte[16];
        byte[] array;


        using (Rijndael aes = Rijndael.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(str);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }
    #endregion

    #region Decrypt
    /// <summary>
    /// Decrypt
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [SqlFunction()]
    public static string Decrypt(string str)
    {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(str);

        using (Rijndael aes = Rijndael.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
    #endregion

    #endregion
}
#endregion

