using System;
using System.Net;
using System.IO;
using System.Collections;
using Org.Mentalis.Network.ProxySocket;
using System.Net.Sockets;
using System.Text;

namespace SocialNetworks.Services
{
    /// <summary>
    /// Class to communicate with internet
    /// </summary>
    public class InternetService
    {

        /// <summary>
        /// Send internet request using POST method
        /// </summary>
        /// <param name="request">Webrequest parameters</param>
        /// <param name="jsonRequest">body of request</param>
        /// <returns>Response from server</returns>
        public string SendPostInternetRequest(string jsonRequest, WebRequest request)
        {
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                return string.Empty;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Send request using internet connection
        /// </summary>
        /// <param name="requestString">String, that passed</param>
        /// <param name="proxyUrl">http://address:port_name</param>
        /// <returns>JSON answer from server</returns>
        public string SendGetInternetRequest(string requestString, string proxyUrl = null)
        {
            string returnString = String.Empty;
            
            try
            {
                WebRequest request = WebRequest.Create(requestString);
                if (proxyUrl != null)
                {
                    WebProxy wpr = new WebProxy(proxyUrl, true);
                    request.Proxy = wpr;
                }
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

        public string SendInternetRequestWithSOCKS(string requestString, int proxyPort, string proxyIP = null)
        {
            string returnString = String.Empty;

            try
            {
                // create a new ProxySocket
                ProxySocket s = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // set the proxy settings
                s.ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxyIP), proxyPort);
                s.ProxyType = ProxyTypes.Socks5;    // if you set this to ProxyTypes.None, 
                                                    // the ProxySocket will act as a normal Socket
                                                    // connect to the remote server
                                                    // (note that the proxy server will resolve the domain name for us)
                s.Connect("https://api.telegram.org", 443);
                
                // send an HTTP request
                s.Send(Encoding.ASCII.GetBytes($"GET / HTTP/1.0\r\nHost: {requestString}\r\n\r\n"));
                // read the HTTP reply
                int recv = 0;
                byte[] buffer = new byte[1024];
                recv = s.Receive(buffer);
                while (recv > 0)
                {
                    returnString+=Encoding.ASCII.GetString(buffer, 0, recv);
                    recv = s.Receive(buffer);
                }                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnString;
        }

    }
}
