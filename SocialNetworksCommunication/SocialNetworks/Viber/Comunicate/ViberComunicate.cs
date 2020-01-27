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
using SocialNetworks.Viber.Objects.SendMessageTypes;

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
        private ResponseViberService SendRequest(string jsonBody, string requestString)
        {
            ResponseViberService ans = new ResponseViberService();
            try
            {
                if (viberHeaderValue == string.Empty)
                {
                    ans.IsTrue = false;
                    ans.LogData = "Please set X-Viber-Auth-Token property";
                }
                
                WebRequest request = WebRequest.Create(requestString);
                request.Method = "POST";
                request.Headers[viberHeaderKey] = viberHeaderValue;
                
                string ansString = _internet.SendPostInternetRequest(jsonBody, request);

                if (true)
                {
                    ans.IsTrue = true;
                    ans.LogData = ansString;
                }
                else
                {
                    ans.IsTrue = false;
                    ans.LogData = "Request didn't sent to viber server";
                }

                return ans;

            }catch(Exception ex)
            {
                ans.IsTrue = false;
                ans.LogData = ex.Message;
                return ans;
            }
        }

        /// <summary>
        /// Sets WebHook 
        /// </summary>
        /// <param name="webHookObject">Configure WebHook object</param>
        /// <returns>True if success, else false</returns>
        public ResponseViberService SetWebHook(ViberSetWebHook webHookObject)
        {
            ResponseViberService ansReturn = new ResponseViberService();
            try
            {
                string json = _serializer.SerializeObjectT(webHookObject);

                ResponseViberService resp = SendRequest(json, commonReqString + settingWebHook);

                ViberWebhookResponse responseServer = _deserializer.DeserializeToObjectT<ViberWebhookResponse>(resp.LogData);

                if (responseServer.Status == 0)
                {
                    ansReturn.IsTrue = true;
                    ansReturn.LogData = responseServer.ToString();
                }
                else
                {
                    ansReturn.IsTrue = false;
                    ansReturn.LogData = "Cannot set webhooks";
                }

                return ansReturn;
            }catch(Exception ex)
            {
                ansReturn.IsTrue = false;
                ansReturn.LogData = ex.Message;
                return ansReturn;
            }
        }

        
        private void StopListen()
        {

        }

        private void GetUpdate()
        {

        }

        
        /// <summary>
        /// Send message to bot
        /// </summary>
        /// <param name="textMessage">Text message class</param>
        /// <returns>True if success, else false</returns>
        public ResponseViberService SendTextMessageToBot(ViberTextMessage textMessage)
        {
            ResponseViberService ansReturn = new ResponseViberService();
            try
            {
                string messageToSend = _serializer.SerializeObjectT(textMessage);
                return SendRequest(messageToSend, commonReqString + resourceUrl);                
            }catch(Exception ex)
            {
                ansReturn.IsTrue = false;
                ansReturn.LogData = ex.Message;
                return ansReturn;
            }
        }

        public ViberComunicate() { }
        public ViberComunicate(string token)
        {
            viberHeaderValue = token;
        }
    }
}
