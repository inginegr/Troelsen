using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworks.Services;


namespace SocialNetworks
{
    /// <summary>
    /// Class to communicate with telegramm social network
    /// </summary>
    public class TGCommunicate
    {
        //Crypto service to operate by secret key
        KeysTGHandle keysHandle = null;

        //To send commands using interent
        InternetService inetService = new InternetService();

        // Secret key to communicate with telegram server
        private string Token { get => keysHandle.GetSecretKey(); }

        //Base string to communicate with bot
        private string BaseQeruestString = "https://api.telegram.org/bot";

        //Send internet request function
        private string SendRequest(string methodName, IDictionary<string, string> dictionary=null)
        {
            try
            {
                string requestParams = String.Empty;
                if (dictionary != null)
                {
                    requestParams += "?";
                    foreach (var s in dictionary)
                    {
                        requestParams += $"{s.Key}={s.Value}&";
                    }
                }

                string reqString = $"{BaseQeruestString}{Token}/{methodName}{requestParams}"; 
                return inetService.SendInternetRequest(reqString, "http://76.250.137.241:8080");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Return basic information about User object
        public string getMe()
        {
            try
            {                
                return SendRequest("getMe");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string getUpdates()
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("offset", "13");
                dictionary.Add("timeout", "60");
                return SendRequest("getUpdates", dictionary);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public TGCommunicate()
        {
            throw new Exception("Please choose a correct constructor");
        }

        public TGCommunicate(string tokenParam)
        {
            keysHandle = new KeysTGHandle(tokenParam);
        }
    }
}
