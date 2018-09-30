using System;
using System.Security.Cryptography;
using System.Text;

namespace Data.Transformation
{
    /// <summary>
    /// This class have methods to transform strings in various ways to enable the use for the DataLayer
    /// </summary>
    public static class StringTransformation
    {
        #region basic transformations
        internal static string Hide(string strToHide) => Convert.ToBase64String(Encoding.Unicode.GetBytes (strToHide));
        public static string Unhide(string strToUnhide) => Encoding.Unicode.GetString(Convert.FromBase64String(strToUnhide));

        /// <summary>
        /// Function creates an MD5 hash of the string in 'strToCrypto' and puts it into 'strResult'
        /// </summary>
        internal static string generateHash(string strToCrypto)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strToCrypto));
            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        public static bool checkHash(string strInput, string strHash)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(generateHash(strInput), strHash))
                return true;
            else
                return false;
        }
        #endregion
    }
}