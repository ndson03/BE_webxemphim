using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace NetflixClone.Controllers
{
    public class RSAEncryption
    {
        private static RSA rsa;

        public static void InitializeRSA()
        {
            rsa = RSA.Create();
        }

        public static string Encrypt(string plainText)
        {
            byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = rsa.Encrypt(bytesToEncrypt, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}