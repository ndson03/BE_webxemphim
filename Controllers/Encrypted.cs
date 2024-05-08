using NetflixClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetflixClone.Controllers
{
    public class Encrypted : RSAEncryption
    {
        public byte[] encryptedEmail { get; set; }
        public byte[] encryptedPassword { get; set; }

        public Encrypted()
        {
            //InitializeRSA();
        }

        public Encrypted(byte[] encryptedEmail, byte[] encryptedPassword)
        {
            this.encryptedEmail = encryptedEmail;
            this.encryptedPassword = encryptedPassword;
        }

        public class EncryptedList
        {
            private List<Encrypted> list = null;

            public EncryptedList()
            {
                list = new List<Encrypted>();
            }

            public List<Encrypted> getList()
            {
                return list;
            }

            public void Add(Encrypted encrypted)
            {
                list.Add(encrypted);
            }
        }
    }
}