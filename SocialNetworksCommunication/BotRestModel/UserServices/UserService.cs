using System;
using System.IO;
using System.Web.Mvc;
using ServiceLibrary.Security;
using ServiceLibrary.Serialization;
using System.Configuration;


using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.DataBase.Infrastructure;
using BotsRestServices.Models.Objects.RequestToServer;


namespace BotsRestServices.Models.UserServices
{
    public class UserService
    {
        // DataBase service
        protected DbHandle dbHandle = new DbHandle();

        // Cryptography functions
        SLCryptography _crypto = new SLCryptography();

        protected JsonSerializer js = new JsonSerializer();

        protected JsonDeserializer jsd = new JsonDeserializer();
        
        /// <summary>
        /// Deserializes to object with request parameters
        /// </summary>
        /// <param name="s">Request string</param>
        /// <returns>TotalRequest object</returns>
        protected TotalRequest GetRequestObject(string s)
        {
            try
            {
                return jsd.DeserializeToObjectT<TotalRequest>(s);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Login to the system
        /// </summary>
        /// <param name="authorize">User login and password</param>
        /// <returns>True if authorized, else false</returns>
        public bool LogIn(User authorize)
        {
            try
            {
                UserData user = (UserData)dbHandle.FindRow((UserData)authorize);
                if (user != null)
                    if ((user.Login == authorize.Login) && (user.Password == authorize.Password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                else
                    return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds login and password to response
        /// </summary>
        /// <param name="userParam">Login and password </param>
        /// <returns>TotalResponse filled by login and password</returns>
        protected TotalResponse FormLogPas(UserData userParam)
        {            
            try
            {
                TotalResponse response = CheckIfRegistered(userParam);
                response.UserAuth.Login = userParam.Login;
                response.UserAuth.Password = userParam.Password;
                return response;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forms status and message 
        /// </summary>
        /// <param name="response">Message object</param>
        /// <param name="isTrue">Status answer</param>
        /// <param name="answer">Answer text</param>
        /// <returns>Object, filled with status and answer text</returns>
        protected TotalResponse FormResponseStatus(TotalResponse response, bool isTrue, string answer)
        {
            try
            {
                response.IsTrue = new IsTrueAnswer { IsTrue = isTrue, Text = answer };
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                if ((userParam.Login == string.Empty) || (userParam.Password == string.Empty) || (userParam.Login == null) || (userParam.Password == null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks if user is admin
        /// </summary>
        /// <param name="userParam">User object</param>
        /// <returns>true if admin else false</returns>
        private bool CheckIfAdmin(User userParam)
        {
            try
            {
                if ((userParam.Login == ConfigurationManager.AppSettings["Login"]) && (userParam.Password == ConfigurationManager.AppSettings["Password"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks if user is client
        /// </summary>
        /// <param name="userParam">User object</param>
        /// <returns>UserData if found, else null</returns>
        private UserData CheckIfClient(User userParam)
        {
            try
            {
                return (UserData)dbHandle.FindRow(userParam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check if user is registered
        /// </summary>
        /// <param name="userRequest">User object</param>
        /// <returns>Json string with answer to client</returns>
        private TotalResponse CheckIfRegistered(User userRequest)
        {
            try
            {
                TotalResponse tr = new TotalResponse();
                if (CheckIfEmpty(userRequest))
                {
                    tr.IsTrue.IsTrue = false;
                    tr.IsTrue.Text = "User is not registered";
                    tr.Client.IsUserClient = false;
                    tr.Admin.IsUserAdmin = false;
                    tr.IsTrue.Text= $"Login or password are invalid";

                    return tr;
                }

                if (CheckIfAdmin(userRequest))
                {
                    tr.Admin.IsUserAdmin = true;
                    tr.IsTrue.IsTrue = true;
                    tr.IsTrue.Text = "User is admin";
                    return tr;
                }

                UserData user = CheckIfClient(userRequest);

                if (user!=null)
                {
                    tr.Client.IsUserClient = true;
                    tr.UserAuth = user;
                    tr.IsTrue.IsTrue = true;
                    tr.IsTrue.Text = "User is client";
                    return tr;
                }
                else
                {                    
                    tr.IsTrue.IsTrue = false;
                    tr.IsTrue.Text = "User is not registered";
                    tr.Client.IsUserClient = false;
                    tr.Admin.IsUserAdmin = false;
                    throw new Exception(js.SerializeObjectT(tr));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// React to user login and password input
        /// </summary>
        /// <param name="ctr">Controller</param>
        /// <returns>Answer to user</returns>
        public string ReactToLogin(Controller ctr)
        {
            try
            {
                string req = ReadDataFromBrowser(ctr);
                TotalRequest userRequest = GetRequestObject(req);
                return js.SerializeObjectT(FormLogPas(userRequest.User));
            }
            catch (Exception ex)
            {
                IsTrueAnswer error = new IsTrueAnswer { Text = ex.Message };

                string s = js.SerializeObjectT<IsTrueAnswer>(error);

                return $"The error is {s}";
            }
        }

        /// <summary>
        /// Reads browser request body
        /// </summary>
        /// <param name="ctr">Controller class</param>
        /// <returns>body data string</returns>
        public string ReadDataFromBrowser(Controller ctr)
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

                return jsonPostData;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}