using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Helper
{
    public static class EncryptHelper
    {

        private static string _keyWorkd = "Exam";

        #region ========Encrypt========

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <returns>System.String.</returns>
        /// <remarks>
        ///  07/09/2013, Alan Create
        /// </remarks>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, _keyWorkd);
        }
        /// <summary>
        /// Encrypt Data
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="sKey">The s key.</param>
        /// <returns>System.String.</returns>
        /// <remarks>
        ///  07/09/2013, Alan Create
        /// </remarks>
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========Decrypt========


        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <returns>System.String.</returns>
        /// <remarks>
        ///  07/09/2013, Alan Create
        /// </remarks>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, _keyWorkd);
        }
        /// <summary>
        /// Decrypt Data
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="sKey">The s key.</param>
        /// <returns>System.String.</returns>
        /// <remarks>
        ///  07/09/2013, Alan Create
        /// </remarks>
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        public static bool IsEncrypted(string str)
        {
            if (str == null)
            {
                return false;
            }
            else
            {
                return str.Length >= 32;
            }

        }

        #endregion
    }
}
