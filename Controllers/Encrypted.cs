using NetflixClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetflixClone.Controllers
{
    public class Encrypted : RSAEncryption
    {
        private String encryptedEmail { get; set; }
        private String encryptedPassword { get; set; }

        public String getEncryptedEmail()
        {
            return encryptedEmail;
        }
        public String getEncryptedPassword()
        {
            return encryptedPassword;
        }
        public Encrypted()
        {
            InitializeRSA();
        }

        public Encrypted(string encryptedEmail, string encryptedPassword)
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