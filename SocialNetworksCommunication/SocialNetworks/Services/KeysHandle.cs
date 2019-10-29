using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Security;


namespace SocialNetworks.Services
{
    //Interface crypto operations
    public interface ICrypto
    {
        string GetSecretKey();
    }
    
    /// <summary>
    /// Basic handle secret keys
    /// </summary>
    public class KeysHandle
    {
        //Crypto handle 
        internal SLCryptography crypto = new SLCryptography();

        //Secret key for encription decription
        internal byte[] secretKey = null;

        // Token to communicate with social networks
        internal byte[] token = null;

        /// <summary>
        /// Decrypts data with local secret key
        /// </summary>
        /// <param name="dataToDecrypt">Data that decrypted</param>
        /// <returns>Decrypted data</returns>
        internal string DecryptData(byte[] dataToDecrypt)
        {
            return crypto.DecryptData(dataToDecrypt, secretKey);
        }

        public KeysHandle()
        {
            throw new Exception("Please set the token");
        }

        public KeysHandle(string stringParam)
        {
            secretKey = crypto.GenerateKey(16);
            token = crypto.EncryptData(stringParam, secretKey);
        }
    }

    /// <summary>
    /// Vk secret keys handle
    /// </summary>
    public class KeysVKHandle : KeysHandle, ICrypto
    {
        //Get token
        public string GetSecretKey()
        {
            return DecryptData(token);
        }
        
        
        public KeysVKHandle()
        {
            throw new Exception("Please set the token");
        }

        public KeysVKHandle(string tokenParam) : base(tokenParam) { }        
    }

    /// <summary>
    /// Telegramm secret keys handle
    /// </summary>
    public class KeysTGHandle : KeysHandle, ICrypto
    {
        //Get token
        public string GetSecretKey()
        {
            return DecryptData(token);
        }


        public KeysTGHandle()
        {
            throw new Exception("Please set the token");
        }

        public KeysTGHandle(string tokenParam) : base(tokenParam) { }
    }
}
