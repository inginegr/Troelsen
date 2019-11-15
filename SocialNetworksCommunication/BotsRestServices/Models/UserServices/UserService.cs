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
                return dbHandle.FindUser((UserData)authorize);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds login and password to response
        /// </summary>
        /// <param name="userParam">Login and password </param>
        /// <returns>TotalResponse filled by login and password</returns>
        protected TotalResponse FormLogPas(User userParam)
        {            
            try
            {
                TotalResponse response = new TotalResponse();
                response.Users[0] = (UserData)userParam;
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
                response.IsTrue = new IsTrueAnswer { IsTrue = isTrue.ToString(), Text = answer };
                return response;
            }catch(Exception ex)
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
        /// <returns>true if client else false</returns>
        private bool CheckIfClient(User userParam)
        {
            try
            {
                if (dbHandle.FindUser(userParam))
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
        /// Check if user is registered
        /// </summary>
        /// <param name="userRequest">User object</param>
        /// <returns>Json string with answer to client</returns>
        private string CheckIfRegistered(User userRequest)
        {
            try
            {
                if (CheckIfEmpty(userRequest))
                {
                    return $"Login or password are invalid";
                }

                TotalResponse tr = FormLogPas(userRequest);

                if (CheckIfAdmin(userRequest))
                {
                    tr.Admin.IsUserAdmin = true.ToString();
                    tr.IsTrue.IsTrue = true.ToString();
                    tr.IsTrue.Text = "User is admin";
                }
                else if (CheckIfClient(userRequest))
                {
                    tr.Client.IsUserClient = true.ToString();
                    tr.IsTrue.IsTrue = true.ToString();
                    tr.IsTrue.Text = "User is client";
                }
                else
                {
                    tr.IsTrue.IsTrue = false.ToString();
                    tr.IsTrue.Text = "User is not registered";
                    tr.Client.IsUserClient = false.ToString();
                    tr.Admin.IsUserAdmin = false.ToString();
                }
                return js.SerializeObjectT(tr);
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
                string jsonPostData;

                using (Stream sr = ctr.Request.InputStream)
                {
                    sr.Position = 0;
                    using (StreamReader rd = new StreamReader(sr))
                    {
                        jsonPostData = rd.ReadToEnd();
                    }
                }

                TotalRequest userRequest = jsd.DeserializeToObjectT<TotalRequest>(jsonPostData);

                return CheckIfRegistered(userRequest.User);
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