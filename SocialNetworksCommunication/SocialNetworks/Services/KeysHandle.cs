using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security;


namespace SocialNetworks.Services
{
    public class KeysHandle
    {
        //Crypto handle 
        private SLCryptography crypto = new SLCryptography();

        //Secret key for encription decription
        private byte[] secretKey = null;

        // Token to communicate with social networks
        private byte[] token = null;

        //Get token
        public string GetToken
        {
            get => DecryptData(token);
        }

        /// <summary>
        /// Decrypts data with local secret key
        /// </summary>
        /// <param name="dataToDecrypt">Data that decrypted</param>
        /// <returns>Decrypted data</returns>
        private string DecryptData(byte[] dataToDecrypt)
        {
            return crypto.DecryptData(dataToDecrypt, secretKey);
        }


        public KeysHandle()
        {
            throw new Exception("Please set the token");
        }

        public KeysHandle(string tokenParam)
        {
            secretKey = crypto.GenerateKey(16);
            token = crypto.EncryptData(tokenParam, secretKey);
        }

    }
}
