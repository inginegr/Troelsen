using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworks.Services;
using ServiceLibrary.Serialization;
using SocialNetworks.Telegramm.Objects;
using ServiceLibrary.Various;
using SocialNetworks.Telegramm;
using System.Threading;
using SocialNetworks.Telegramm.Objects;

namespace SocialNetworks.Telegramm
{
    /// <summary>
    /// Class to communicate with telegramm social network
    /// </summary>
    public partial class TgCommunicate
    {
        /// <summary>
        ///  Form string with params
        /// </summary>
        /// <param name="dictionary">Dictionary with params</param>
        /// <returns>String with params</returns>
        private string FormParamsString(IDictionary<string, string> dictionary = null)
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
                    requestParams = requestParams.TrimEnd('&');
                }

                return requestParams;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Send internet request function
        /// <summary>
        /// Send request to bot
        /// </summary>
        /// <param name="methodName">Name of method</param>
        /// <param name="dictionary">Parametres of method</param>
        /// <returns>Json string, answer from bot</returns>
        private string SendRequest(string methodName, IDictionary<string, string> dictionary=null)
        {
            try
            {
                string requestParams = FormParamsString(dictionary);
                string reqString = $"{BaseQeruestString}{Token}/{methodName}{requestParams}";
                return inetService.SendGetInternetRequest(reqString);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Return basic information about User object
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

        /// <summary>
        /// Ads params to dictionary
        /// </summary>
        /// <param name="key">Key value</param>
        /// <param name="value"> Value value</param>
        /// <returns>Pair key value in dictionary</returns>
        private Dictionary<string, string> AddParams(string key, string value)
        {
            try
            {
                if ((key == String.Empty) || (value == String.Empty))
                {
                    throw new Exception("Key or value can not be empty");
                }

                Dictionary<string, string> returnDictionary = new Dictionary<string, string>();

                returnDictionary.Add(key, value);

                return returnDictionary;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set dictionary of parametres to set in request string
        /// </summary>
        /// <param name="args">Dictionary of key and value pair</param>
        /// <returns>Dictionary of key and value pairs</returns>
        private Dictionary<string, string> SetParams(params Dictionary<string, string>[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Dictionary can not be empty");
                }
                Dictionary<string, string> returnDictionary = new Dictionary<string, string>();

                foreach(Dictionary<string,string> s in args)
                {
                    if ((s.Count > 1) || (s.Count > 1))
                    {
                        throw new Exception("Can be only single key or value");
                    }

                    returnDictionary.Add(s.Keys.First(), s.Values.First());
                }

                return returnDictionary;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
                            


        public TgCommunicate()
        {
            throw new Exception("Please choose a correct constructor");
        }

        public TgCommunicate(string tokenParam)
        {
            keysHandle = new KeysTGHandle(tokenParam);
        }
    }
}
