using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
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
            rsa = RSA.Create();
            //Uncomment export() khi chạy lần đầu, từ lần 2 thì comment lại vì có key rồi
            //export();
            // Đọc khóa từ file XML
            string xmlString = File.ReadAllText(@"D:\LEARNING\ThucTapChuyenNganh\ttcn_webxemphim\Keys\publicKey.xml");

            // Import khóa từ chuỗi XML vào đối tượng RSACryptoServiceProvider
            rsa.FromXmlString(xmlString);
            xmlString = File.ReadAllText(@"D:\LEARNING\ThucTapChuyenNganh\ttcn_webxemphim\Keys\privateKey.xml");
            rsa.FromXmlString(xmlString);
        }

        //Xuất key trong lần đầu chạy project
        public static void export()
        {
            // Tạo thư mục ở ổ tương ứng để xuất file
            string publicKeyXml = rsa.ToXmlString(false);
            File.WriteAllText(@"C:\Keys\publicKey.xml", publicKeyXml);

            string privateKeyXml = rsa.ToXmlString(true);
            File.WriteAllText(@"C:\Keys\privateKey.xml", privateKeyXml);
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