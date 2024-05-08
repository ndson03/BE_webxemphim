using System;
using System.Security.Cryptography;
using System.Text;

namespace NetflixClone.Controllers
{
    public class RSAEncryption
    {
        private static RSA rsa;
        public static bool isInit = false;

        public static bool getIsInit()
        {
            return isInit;
        }

        public static void InitializeRSA()
        {
            isInit = true;
            rsa = RSA.Create();//sẽ check ở đây, có thể do rsa.create nhiều lần dẫn đền khác key
        }

        public static byte[] Encrypt(string plainText)
        {
            byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = rsa.Encrypt(bytesToEncrypt, RSAEncryptionPadding.Pkcs1);
            string a = Decrypt(encryptedBytes);
            Console.WriteLine(a);
            return encryptedBytes;
        }

        public static string Decrypt(byte[] cipherText)
        {
            //byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            //byte[] encryptedBytes = cipherText;
            Console.WriteLine(cipherText);
            byte[] decryptedBytes = rsa.Decrypt(cipherText, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}