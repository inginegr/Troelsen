using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Org.Mentalis.Network.ProxySocket;
using System.Net.Sockets;
using System.Text;

namespace ServiceLibrary.Various
{
    /// <summary>
    /// Class to communicate with internet
    /// </summary>
    public class InternetService
    {
        /// <summary>
        /// Set headers of web request
        /// </summary>
        /// <param name="request">web request, where neccassary add headers</param>
        /// <param name="headers">headers to set in webrequest</param>
        /// <returns>Web reqyest class with headers</returns>
        private WebRequest SetHeaders(WebRequest request, IDictionary<string, string> headers)
        {
            try
            {
                if (headers != null && request != null) 
                {
                    foreach(var s in headers)
                    {
                        if (s.Key.ToLower() == "content-type".ToLower())
                        {
                            request.ContentType = s.Value;
                        }
                        else
                        {
                            request.Headers[s.Key] = s.Value;
                        }
                    }
                }

                return request;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
                string retString = string.Empty;

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    retString = streamReader.ReadToEnd();
                }

                return retString;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Send internet request using POST method
        /// </summary>
        /// <param name="jsonRequest">JSon body of request</param>
        /// <param name="requestString">url string to request</param>
        /// <param name="headers">Collection of headers to set in internet request</param>
        /// <returns>Response string from server</returns>
        public string SendPostInternetRequest(string jsonRequest, string requestString, IDictionary<string, string> headers=null)
        {
            try
            {
                string retString = string.Empty;

                WebRequest internetRequest = WebRequest.Create(requestString);

                internetRequest = SetHeaders(internetRequest, headers);
                internetRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(internetRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                }

                var httpResponse = (HttpWebResponse)internetRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    retString = streamReader.ReadToEnd();
                }

                return retString;
            }
            catch (Exception ex)
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
