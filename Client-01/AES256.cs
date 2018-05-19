using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client_01
{
    class AES256
    {

        //=============================================================================

        public string Encrypt(string iCompleteEncodedKey,string iPlainStr, string dateTime)
        {
            string time = dateTime.Substring(0, 16);

            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.None;           
            aesEncryption.IV = Encoding.ASCII.GetBytes(time);
            aesEncryption.Key = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(iCompleteEncodedKey)));
            byte[] plainText = UTF8Encoding.UTF8.GetBytes(iPlainStr);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string iCompleteEncodedKey,string iEncryptedText,string dateTime)
        {
            string time = dateTime.Substring(0, 16);

            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.None;
            aesEncryption.IV = Encoding.ASCII.GetBytes(time);
            aesEncryption.Key = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(iCompleteEncodedKey)));
            ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64CharArray(iEncryptedText.ToCharArray(), 0, iEncryptedText.Length);
            return UTF8Encoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
        }

      
        //=============================================================================


    }
}
