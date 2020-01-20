using System;
using System.IO;
using System.Security.Cryptography;

namespace ServiceLibrary.Security
{
    public class SLCryptography
    {

        ///<summary>
        ///Key parameter
        /// </summary>
        public int BlockSize = 128;

        ///<summary>
        ///Key parameter
        /// </summary>
        private byte[] localKey = new byte[16];

        ///<summary>
        ///IV parameter
        /// </summary>
        private byte[] localIV = new byte[16];


        /// <summary>
        /// Encrypts data
        /// </summary>
        /// <param name="dataParam">Data to encrypt</param>
        /// <returns>encrypted data</returns>
        public byte[] EncryptData(string dataParam)
        {
            GenerateKeyAndIV();

            return EncryptStringToBytes_Aes(dataParam, localKey, localIV);
        }

        /// <summary>
        /// Encrypts data with secret key
        /// </summary>
        /// <param name="dataParam">Data to encrypt</param>
        /// <param name="key">Secure key</param>
        /// <returns>encrypted data</returns>
        public byte[] EncryptData(string dataParam, byte[] key)
        {
            GenerateKeyAndIV();

            return EncryptStringToBytes_Aes(dataParam, key, localIV);
        }

        /// <summary>
        /// Encrypts data with secret key and public key
        /// </summary>
        /// <param name="dataParam">Data to encrypt</param>
        /// <param name="key">Secure key</param>
        /// <param name="IV">Secure public key</param>
        /// <returns>encrypted data</returns>
        public byte[] EncryptData(string dataParam, byte[] key, byte[] IV)
        {
            return EncryptStringToBytes_Aes(dataParam, key, IV);
        }


        /// <summary>
        /// Decrypt data
        /// </summary>
        /// <param name="encryptedData"> Encrypted data</param>
        /// <returns>Decrypted string</returns>
        public string DecryptData(byte[] encryptedData)
        {
            GenerateKeyAndIV();

            return DecryptStringFromBytes_Aes(encryptedData, localKey, localIV);
        }

        /// <summary>
        /// Decrypt data
        /// </summary>
        /// <param name="encryptedData"> Encrypted data</param>
        /// <param name="secretKey">Secret key to decrypt</param>
        /// <returns>Decrypted string</returns>
        public string DecryptData(byte[] encryptedData, byte[] secretKey)
        {
            GenerateKeyAndIV();

            return DecryptStringFromBytes_Aes(encryptedData, secretKey, localIV);
        }


        /// <summary>
        /// Generates key and iv local parameters
        /// </summary>
        private void GenerateKeyAndIV()
        {
            for (int i = 0; i < BlockSize/8; i++)
            {
                localKey[i] = (byte)(i % 8);
                localIV[i] = (byte)(i % 5);
            }
        }

        /// <summary>
        /// Generate new random key
        /// </summary>
        /// <param name="blockSize">BlockSize of encryption</param>
        /// <returns>Returns massive of bytes values</returns>
        public byte[] GenerateRandom(int blockSize)
        {
            byte[] returnKey = new byte[blockSize];

            if (blockSize % 8 != 0 || blockSize == 0)
            {
                throw new Exception("Wrong BlockSize property.");
            }

            try
            {
                Random rand = new Random();
                for (int i = 0; i < blockSize; i++)
                {
                    returnKey[i] = (byte)rand.Next(0, 255);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnKey;
        }


        /// <summary>
        /// Encrypta data to bytes massive
        /// </summary>
        /// <param name="plainText">Data to encrypt</param>
        /// <param name="Key">Key parameter</param>
        /// <param name="IV">IV massive</param>
        /// <returns>Encrypted data</returns>
        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                //aesAlg.KeySize = 128;
                aesAlg.BlockSize = BlockSize;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }


        /// <summary>
        /// Decrypts data from encrpted massive
        /// </summary>
        /// <param name="cipherText">Encrypted data</param>
        /// <param name="Key">Key parameter</param>
        /// <param name="IV">IV parameter</param>
        /// <returns>Decrypted data string</returns>
        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.BlockSize = BlockSize;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}
