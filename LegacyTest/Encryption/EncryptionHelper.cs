using System;
using System.Security.Cryptography;
using System.Text;

namespace LegacyTest.Encryption
{
    public class EncryptionHelper
    {
        public static string Encrypt(string input, string key)
        {
            var inputArray = Encoding.UTF8.GetBytes(input);
            var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tripleDes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string input, string key)
        {
            var inputArray = Convert.FromBase64String(input);
            var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tripleDes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}