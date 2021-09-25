#region NameSpace
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace Utilities
{
    #region Cryptography
    /// <summary>
    /// Cryptography
    /// </summary>
    public static class Cryptography
    {
        #region Public Methods

        #region EncryptPassword
        /// <summary>
        /// EncryptPassword
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(this string password)
        {
            SHA1CryptoServiceProvider hasher = new SHA1CryptoServiceProvider();

            string salt = Constant.PasswordSecretKey.ToString();

            byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat(password.Trim(), salt));
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);

            hasher.Clear();

            return Convert.ToBase64String(hashedBytes);
        }
        #endregion

        #region Encrypt
        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(this string plainText)
        {
            return EncryptString(plainText.Trim());
        }
        #endregion

        #region Encrypt - long
        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="longNumber"></param>
        /// <returns></returns>
        public static string Encrypt(this long longNumber)
        {
            return EncryptString(longNumber.ToString().Trim());
        }
        #endregion

        #region Encrypt - int
        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="intNumber"></param>
        /// <returns></returns>
        public static string Encrypt(this int intNumber)
        {
            return EncryptString(intNumber.ToString().Trim());
        }
        #endregion

        #region EncryptCommaSeparatedString
        /// <summary>
        /// EncryptCommaSeparatedString
        /// </summary>
        /// <param name="commaSeparatedString"></param>
        /// <returns></returns>
        public static string EncryptCommaSeparatedString(this string commaSeparatedString)
        {
            StringBuilder encCommaSeperatedString = new StringBuilder();

            List<string> lstString = commaSeparatedString.Split(',').ToList();

            foreach(string s in lstString)
            {
                encCommaSeperatedString.Append(EncryptString(s.Trim()) + ",");
            }

            return encCommaSeperatedString.ToString();
        }
        #endregion

        #region Decrypt
        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(this string cipherText)
        {
            return DecryptString(cipherText.Trim());
        }
        #endregion

        #region DecryptCommaSeparated
        /// <summary>
        /// DecryptCommaSeparated
        /// </summary>
        /// <param name="commaSeparatedString"></param>
        /// <returns></returns>
        public static string DecryptCommaSeparated(this string commaSeparatedString)
        {
            StringBuilder decryptedString = new StringBuilder();

            List<string> lstString = commaSeparatedString.Split(',').ToList();

            foreach (string s in lstString)
            {
                decryptedString.Append(DecryptString(s.Trim()) + ",");
            }

            return decryptedString.ToString();
        }
        #endregion

        #endregion

        #region Private Methods

        #region EncryptString
        /// <summary>
        /// EncryptString
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        private static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;
            string key = Constant.EncryptionSecretKey;

            using (Aes aes = Aes.Create())
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
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        #endregion

        #region DecryptString
        /// <summary>
        /// DecryptString
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        private static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            string key = Constant.EncryptionSecretKey;

            using (Aes aes = Aes.Create())
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
}
