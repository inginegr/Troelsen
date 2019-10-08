using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Security;
using ServiceLibrary;



namespace SCN_App
{
    class HandleClass
    {
        FileService fServ = new FileService();

        CommonService comServ = new CommonService();

        SLCryptography localCrypto = new SLCryptography();


        public void SaveKeySafely(string stringToSave)
        {
            try
            {                
                byte[] encryptedData = localCrypto.EncryptData(stringToSave);

                string s = comServ.MassivToString(encryptedData, " ");

                fServ.LogData("tkn.txt", s);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string LoadToken()
        {
            string returnString = null;
            try
            {
                string tkn = fServ.ReadFileToString("tkn.txt");

                byte[] bt = comServ.StringToMassive<byte>(tkn, " ", typeof(byte)).ToArray();

                returnString = localCrypto.DecryptData(bt);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnString;
        }
    }
}
