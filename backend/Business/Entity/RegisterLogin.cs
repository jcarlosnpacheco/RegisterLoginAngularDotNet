using RegisterLoginAPI.Business.Commands;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RegisterLoginAPI.Business.Entity
{
    public class RegisterLogin
    {
        public int Id { get; protected set; }

        public string LoginName { get; protected set; }

        public string Password { get; protected set; }

        public string Observation { get; protected set; }

        public int LoginTypeId { get; protected set; }

        public RegisterLogin()
        { }

        public RegisterLogin(

            string loginName,
            string password,
            string observation,
            int loginTypeId)
        {
            LoginName = loginName;
            Password = password;
            Observation = observation;
            LoginTypeId = loginTypeId;
        }

        public void SetUpdateRegisterLogin(UpdateRegisterLoginCommand command)
        {
            Id = command.Id;
            LoginName = command.LoginName;
            Observation = command.Observation;
            LoginTypeId = command.LoginTypeId;

            SetEncryptPassword(command.Password, command.LoginName);
        }

        public void SetEncryptPassword(string pass, string key)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(pass);

            using (Aes encryptor = Aes.Create())
            {
                //https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    pass = Convert.ToBase64String(ms.ToArray());
                }
            }

            Password = pass;
        }
    }
}