using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RegisterLoginAPI.Business.Models
{
    public class RegisterLoginModel
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Observation { get; set; }

        public int LoginTypeId { get; set; }

        public string Password { get; set; }

        private string GetDecryptPassword(string pass, string key)
        {
            //https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
            pass = pass.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(pass);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    pass = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return pass;
        }

        public void SetPassword(string pass, string key)
        {
            Password = GetDecryptPassword(pass, key);
        }
    }
}