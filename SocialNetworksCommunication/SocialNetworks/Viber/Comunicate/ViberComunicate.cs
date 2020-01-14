using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Services;
using SocialNetworks.Viber.Objects;
using ServiceLibrary.Serialization;
using System.Net;
using System.IO;
using System.Collections;
using Org.Mentalis.Network.ProxySocket;
using System.Net.Sockets;


namespace SocialNetworks.Viber.Comunicate
{
    public partial class ViberComunicate
    {
        /// <summary>
        /// Send internet request
        /// </summary>
        /// <param name="jsonBody">Body request</param>
        /// <param name="requestString">Request url string</param>
        /// <returns>Answer from server</returns>
        private string SendRequest(string jsonBody, string requestString)
        {
            try
            {
                if (viberHeaderValue == string.Empty)
                    throw new Exception("Please set X-Viber-Auth-Token property");

                WebRequest request = WebRequest.Create(requestString);
                request.Method = "POST";
                request.Headers[viberHeaderKey] = viberHeaderValue;


                _internet.SendPostInternetRequest(jsonBody, request);
                return string.Empty;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets WebHook 
        /// </summary>
        /// <param name="webHookObject">Configure WebHook object</param>
        /// <returns>True if success, else false</returns>
        private bool SetWebHook(ViberSetWebHook webHookObject)
        {
            //-----------------------------------------------To Finish return type  in future 
            try
            {
                bool returnAns = false;

                string json = _serializer.SerializeObjectT<ViberSetWebHook>(webHookObject);

                string serverAns = SendRequest(json, commonReqString + settingWebHook);

                return returnAns;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Start listen viber bot
        /// </summary>
        /// <param name="eventTypes">Event types, that send webhooks</param>
        /// <param name="urlParam">Server, that will receive webhooks</param>
        /// <param name="isSendName">Is send name option enabled</param>
        /// <param name="isSendPhoto">Is send photo option enabled</param>
        /// <returns>True if started listening succesfull, else false</returns>
        public bool StartListen(string[] eventTypes, string urlParam, bool isSendName=true, bool isSendPhoto=true)
        {
            //-----------------------------------------------To Finish return type  in future 
            try
            {
                bool retAns = false;
                ViberSetWebHook setWebHook = new ViberSetWebHook();
                setWebHook.Event_types = new string[eventTypes.Length];

                for(int i = 0; i < eventTypes.Length; i++)
                {
                    setWebHook.Event_types[i] = eventTypes[i];
                }

                setWebHook.Send_name = isSendName;
                setWebHook.Send_photo = isSendPhoto;
                setWebHook.Url = urlParam;

                retAns = SetWebHook(setWebHook);

                return retAns;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void StopListen()
        {

        }

        public void GetUpdate()
        {

        }

        /// <summary>
        /// Check if jsonString is hello message grom viber server
        /// </summary>
        /// <param name="jsonString">Json string from server</param>
        /// <returns>True if request from server is hello message, false else</returns>
        public bool CheckIfHelloMessage(string jsonString)
        {
            try
            {
                if (jsonString == null || jsonString == "")
                {
                    return false;
                }
                else
                {
                    ViberHelloMessage helloMessage = _deserializer.DeserializeToObjectT<ViberHelloMessage>(jsonString);

                    if (helloMessage.Event == null || helloMessage.Event == "")
                    {
                        return false;
                    }else if(helloMessage.Event== "webhook")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Send message to bot
        /// </summary>
        /// <param name="jsonBody">Content to send</param>
        /// <returns>True if success, else false</returns>
        private bool SendMessageToBot(string jsonBody)
        {
            //--------------------------------- Make in future return result
            try
            {
                bool retAns = false;
                string botResponse = SendRequest(jsonBody, commonReqString + resourceUrl);

                return retAns;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
