using System;
using System.Net;
using System.IO;
using System.Collections;

namespace SocialNetworks.Services
{
    /// <summary>
    /// Class to communicate with internet
    /// </summary>
    public class InternetService
    {
        /// <summary>
        /// Send request using internet connection
        /// </summary>
        /// <param name="requestString">String, that passed</param>
        /// <param name="proxyUrl">http://address:port_name</param>
        /// <returns>JSON answer from server</returns>
        public string SendInternetRequest(string requestString, string proxyUrl = null)
        {
            string returnString = String.Empty;

            try
            {
                WebRequest request = WebRequest.Create(requestString);
                WebProxy wpr = new WebProxy(new Uri(proxyUrl));
                request.Proxy = proxyUrl != null ? wpr : null;
                request.Method = "GET";
                request.Timeout = 90000;

                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);

                    // Read the content.
                    returnString = @reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnString;
        }
    }
}
