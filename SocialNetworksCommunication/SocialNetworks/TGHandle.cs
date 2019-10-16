using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworks.Services;
using ServiceLibrary.Serialization;
using SocialNetworks.TGObjects;


namespace SocialNetworks
{
    /// <summary>
    /// Class to communicate with telegramm social network
    /// </summary>
    public class TGCommunicate
    {
        //Deserializator of json string
        private JsonDeserializer jso = new JsonDeserializer();

        // Timeout between requests
        private int timeOut = 120;

        // Current offset
        private int currentOffset = 0;

        //Limit of updates
        private int lim = 100;

        private int updadesLimit
        {
            get => lim;
            set
            {
                if (value > 100)
                {
                    lim = 100;
                }else if (value < 0)
                {
                    lim = 0;
                }
                else
                {
                    lim = value;
                }

            }
        }

        //Crypto service to operate by secret key
        KeysTGHandle keysHandle = null;

        //To send commands using interent
        InternetService inetService = new InternetService();

        // Secret key to communicate with telegram server
        private string Token { get => keysHandle.GetSecretKey(); }

        //Base string to communicate with bot
        private string BaseQeruestString = "https://api.telegram.org/bot";

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

                string reqString = $"{BaseQeruestString}{Token}/{methodName}{requestParams}"; 
                return inetService.SendInternetRequest(reqString);
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


        /// <summary>
        /// Get updates from bot
        /// </summary>
        /// <param name="dictionaryParams">Set of the parametres value</param>
        /// <returns>Answer from bot (Update object)</returns>
        private string getUpdatesFromBot(IDictionary<string, string> dictionaryParams)
        {
            try
            {
                Dictionary<string, string> parametresDictionary = (Dictionary<string, string>)dictionaryParams;

                return SendRequest("getUpdates", parametresDictionary);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public string getUpdates()
        {
            try
            {
                // Set of params
                Dictionary<string, string> setOfParams = null;
                do
                {
                    // If first request to bot
                    if (currentOffset != 0)
                    {
                        setOfParams = SetParams(AddParams("offset", currentOffset.ToString()), AddParams("timeout", timeOut.ToString()), AddParams("limit", updadesLimit.ToString()));
                    }
                    else
                    {
                        setOfParams = SetParams(AddParams("timeout",timeOut.ToString()), AddParams("limit", updadesLimit.ToString()));
                    }

                    string jsonFromServer = SendRequest("getUpdates", setOfParams);

                    List<TGUpdate> updateObjects = (List<TGUpdate>)jso.DeserializeToT<TGUpdate>(jsonFromServer, new string[] { "result" });

                } while (true);

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
