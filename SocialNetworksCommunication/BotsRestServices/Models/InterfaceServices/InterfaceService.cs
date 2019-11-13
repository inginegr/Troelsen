using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ServiceLibrary.Security;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;
using BotsRestServices.Models.Objects;
using BotsRestServices.Models.Objects.AnswersFromServer;
using System.Configuration;
using BotsRestServices.Models.UserServices;


namespace BotsRestServices.Models.InterfaceServices
{
    /// <summary>
    /// Manage user actions
    /// </summary>
    public class InterfaceService
    {
        UserService us = new UserService();
        // Cryptography functions
        SLCryptography _crypto = new SLCryptography();

        JsonSerializer js = new JsonSerializer();

        JsonDeserializer jsd = new JsonDeserializer();

        string login = string.Empty;

        string password = string.Empty;

        // Key and iv size
        private int _keySize=16;


        public void SendDataToStartPage(Controller ctr)
        {
            byte[] k= _crypto.GenerateRandom(_keySize);
            byte[] i = _crypto.GenerateRandom(_keySize);

            ctr.ViewData["key"] = StringService.ConvertBytesToString(k, "_");
            ctr.ViewData["iv"] = StringService.ConvertBytesToString(k, "_");
            ctr.ViewData["isauthorized"] = false;
        }

        /// <summary>
        /// Check if User object is empty
        /// </summary>
        /// <param name="userParam">User object</param>
        /// <returns>If user object empty or null reterns true else false</returns>
        private bool CheckIfEmpty(User userParam)
        {
            try
            {
                if((userParam.Login==string.Empty)|| (userParam.Password == string.Empty) || (userParam.Login == null) || (userParam.Password == null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string ReactToLogin(Controller ctr)
        {
            try
            {
                string jsonPostData;

                using (Stream sr = ctr.Request.InputStream)
                {
                    sr.Position = 0;
                    using (StreamReader rd = new StreamReader(sr))
                    {
                        jsonPostData = rd.ReadToEnd();
                    }
                }

                User userRequest = jsd.DeserializeToObjectT<User>(jsonPostData);

                if (CheckIfEmpty(userRequest))
                {
                    return $"Login or password are invalid";
                }

                if((userRequest.Login==ConfigurationManager.AppSettings["Login"])&& (userRequest.Password == ConfigurationManager.AppSettings["Password"]))
                {

                    TotalResponse tr = us.FormLogPas(userRequest);

                    return js.SerializeObjectT<IsAdmin>(new IsAdmin { IsUserAdmin = true.ToString() });
                }


                return jsonPostData;
            }
            catch (Exception ex)
            {
                ErrorResponse error = new ErrorResponse { ErrorMessage = ex.Message };

                string s = js.SerializeObjectT<ErrorResponse>(error);

                return $"The error is {s}";
            }
        }
    }
}