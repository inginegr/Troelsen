﻿using System;
using System.Security.Cryptography;
using System.IO;

namespace Summary.Models
{
    public class LocalCryptography
    {
        // Local variables
        Random _random = new Random();
        string loginStandart = "Karamba";
        string passwordStandart = "123";


        // Check user authentification
        public bool CheckIfUserAuth(string encryptedString)
        {
            bool retAns = false;
            string[] ans = encryptedString.Split(' ');

            //byte[] dataToDecrypt = ConvertStringToByteArray(ans[0].Split(','));
            //byte[] key = ConvertStringToByteArray(ans[1].Split(','));
            //byte[] iv = ConvertStringToByteArray(ans[2].Split(','));

            //string[] decryptdetText = DecriptData(dataToDecrypt, key, iv).Split(' ');

            //string UserLogin = decryptdetText[0];
            //string UserPassword = decryptdetText[1];
            string UserLogin = ans[0];
            string UserPassword = ans[1];

            retAns = UserLogin == loginStandart && UserPassword == passwordStandart ? true : false;

            return retAns;
        }

        // Convert stringArray to byteArray
        public byte[] ConvertStringToByteArray(string[] stringToConvert)
        {
            byte[] retBt = new byte[stringToConvert.Length];

            for (int i = 0; i < retBt.Length; i++)
                retBt[i] = byte.Parse(stringToConvert[i]);

            return retBt;
        }

        // Generate random key
        public byte[] GenerateRandomKey(byte keySize)
        {
            if (keySize != 16 && keySize != 24 && keySize != 32)
                throw new ArgumentOutOfRangeException("Wrong size of argument");

            byte[] retKey = new byte[keySize];

            _random.NextBytes(retKey);

            return retKey;
        }
        
        // Encrypt data                                
        public byte[] EncriptData(string dataToString, byte[] key, byte[] iv)
        {
            if (dataToString == null || key == null || iv == null)
                throw new Exception("Argument empty error");

            byte[] retBt = null;

            using (Aes a = Aes.Create())
            {
                ICryptoTransform itr = a.CreateEncryptor(key, iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cstr = new CryptoStream(ms, itr, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swr = new StreamWriter(cstr))
                        {
                            swr.Write(dataToString);
                        }
                    }
                    retBt = ms.ToArray();
                }
            }
            return retBt;
        }

        // Decriptit data
        public string DecriptData(byte[] encriptedData, byte[] key, byte[] iv)
        {
            if (encriptedData == null || key == null || iv == null)
                throw new Exception("Argument empty error");

            string retSt = null;

            using (Aes a = Aes.Create())
            {
                ICryptoTransform itr = a.CreateDecryptor(key, iv);

                using (MemoryStream ms = new MemoryStream(encriptedData))
                {
                    using (CryptoStream crs = new CryptoStream(ms, itr, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(crs))
                        {
                            retSt = sr.ReadToEnd();
                        }
                    }
                }
            }
            return retSt;
        }

    }
}