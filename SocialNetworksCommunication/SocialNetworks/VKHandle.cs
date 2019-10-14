using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Net;

using Security;
using SocialNetworks.Services;
using System.IO;
using SocialNetworks.VKObjects;
using System.Web.Script.Serialization;


namespace SocialNetworks
{
    /// <summary>
    /// Class to komunicate with VK social networc
    /// </summary>
    public class VKComunicate
    {

        //Secret keys handle
        private KeysVKHandle keysHandle = null;

        //API version
        private string apiVer = "5.52";

        //Qequest string to vk
        private string requestString = "https://api.vk.com/method/";

        /// <summary>
        /// Sends request to server
        /// </summary>
        /// <param name="methodName">Name of method</param>
        /// <returns>Returns answer string like json object</returns>
        private string SendRequest(string methodName)
        {
            string returnString = String.Empty;

            try
            {
                string req = requestString + $"{methodName}?v={apiVer}&access_token={keysHandle.GetSecretKey()}";

                WebRequest request = WebRequest.Create(req);

                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    returnString = @reader.ReadToEnd();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnString;
        }

        /// <summary>
        /// Deserialize json to T object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="stringToDeserialize">Deserialized string</param>
        /// <returns>T object</returns>
        private T DeserializeObject<T>(string stringToDeserialize)
        {            
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                T returnObject = js.Deserialize<T>(stringToDeserialize);

                return returnObject;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets FriendList object
        /// </summary>
        /// <returns>FriendList Object</returns>
        public IEnumerable<string> GetFriends()
        {
            FriendList returnFriends = new FriendList();

            try
            {
                string stringFromServer = SendRequest("friends.get");

                Friends ans = DeserializeObject<Friends>(stringFromServer);

                List<string> frendsToReturn = new List<string>();

                foreach(string s in ans.Response.Items)
                {
                    frendsToReturn.Add(s);
                }

                return frendsToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<string> GetUsersOnline()
        {
            MessageBox.Show("GetUsersOnline");
            return new List<string>();
        }






        public VKComunicate()
        {
            throw new Exception("Please choose correct constructor");
        }

        public VKComunicate(string tokenParam)
        {
            keysHandle = new KeysVKHandle(tokenParam);
                
        }
    }
}
