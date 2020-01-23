using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.RequestToServer;
using ServiceLibrary.Serialization;
using System.Web.Mvc;


namespace BotsRestServices.Models.UserServices
{
    /// <summary>
    /// Admin functions
    /// </summary>
    public class AdminService : UserService
    {
        /// <summary>
        /// Forms basic response object with user login and password
        /// </summary>
        /// <param name="ctr">Controller class</param>
        /// <returns>Return basic response object with login and password data</returns>
        private TotalResponse FormResponse(Controller ctr)
        {
            try
            {
                string reqString = ReadDataFromBrowser(ctr);
                TotalRequest req = GetRequestObject(reqString);
                return FormLogPas(req.User);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Add user to db
        /// </summary>
        /// <param name="requestString">String from browser</param>
        /// <returns>Json string answer text</returns>
        public string AddClientToDb(Controller ctr)
        {
            TotalResponse resp = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                resp = FormLogPas(request.User);

                AddUser(request.User);

                resp = FormResponseStatus(resp, true, "The user is added");
            }
            catch(Exception ex)
            {
                resp = FormResponseStatus(resp, false, ex.Message);
            }

            return js.SerializeObjectT(resp);
        }

        /// <summary>
        /// Add rows to db
        /// </summary>
        /// <param name="requestString">String from browser</param>
        /// <returns>Json string answer text</returns>
        public string AddRowsToDb(Controller ctr)
        {
            TotalResponse resp = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                resp = FormLogPas(request.User);

                if (request.ClientsList.Count > 0)
                {
                    AddRows(request.ClientsList);
                }

                if (request.BotsList.Count > 0)
                {
                    AddRows(request.BotsList);
                }

                if (request.BotObjectsList.Count > 0)
                {
                    AddRows(request.BotObjectsList);
                }


                resp = FormResponseStatus(resp, true, "The user is added");
            }
            catch (Exception ex)
            {
                resp = FormResponseStatus(resp, false, ex.Message);
            }

            return js.SerializeObjectT(resp);
        }


        /// <summary>
        /// Gets list of users
        /// </summary>
        /// <param name="s">Request string</param>
        /// <returns>Total response object</returns>
        public string GetClientsList(Controller ctr)
        {
            TotalResponse resp = null; 
            
            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                resp = FormLogPas(request.User);

                List<UserData> list = (List<UserData>)GetAllRows(request.User);
                resp = FormResponseStatus(resp, true, "Here is the user list");
                resp.Users = list;
            } catch(Exception ex)
            {
                resp = FormResponseStatus(resp, false, ex.Message);
            }
            return js.SerializeObjectT(resp);
        }

        /// <summary>
        /// Gets list of bots
        /// </summary>
        /// <param name="s">Request string</param>
        /// <returns>Total response object</returns>
        public string GetBotsList(Controller ctr)
        {
            TotalResponse resp = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                resp = FormLogPas(request.User);

                List<UserBot> list = ((List<UserBot>)GetAllRows(new UserBot { Id = 0 })).
                    Where(item => item.UserDataId == request.User.Id).Cast<UserBot>().ToList();
                resp = FormResponseStatus(resp, true, "Here is the user list");
                resp.Bots = list;
            }
            catch (Exception ex)
            {
                resp = FormResponseStatus(resp, false, ex.Message);
            }
            return js.SerializeObjectT(resp);
        }

        /// <summary>
        /// Gets list of BotObjects
        /// </summary>
        /// <param name="s">Request string</param>
        /// <returns>Total response object</returns>
        public string GetBotObjectsList(Controller ctr)
        {
            TotalResponse resp = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                resp = FormLogPas(request.User);

                List<BotObject> list = ((List<BotObject>)GetAllRows(new BotObject { Id = 0 })).
                    Where(item => item.UserBotId == request.User.Id).Cast<BotObject>().ToList();
                resp = FormResponseStatus(resp, true, "Here is the user list");
                resp.BotObjects = list;
            }
            catch (Exception ex)
            {
                resp = FormResponseStatus(resp, false, ex.Message);
            }
            return js.SerializeObjectT(resp);
        }

        /// <summary>
        /// Removes user from db
        /// </summary>
        /// <param name="requestString">String from browser</param>
        /// <returns>TotalResponse object with answer</returns>
        public string RemoveClientFromDb(Controller ctr)
        {
            TotalResponse response = null;

            try
            {

                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                response = FormLogPas(request.User);

                //DeleteRows<UserData>(request.UserList);

                //response = FormResponseStatus(response, true, $"The user with login {request.UserList.FirstOrDefault().Login} is deleted");
            }
            catch(Exception ex)
            {
                response = FormResponseStatus(response, false, ex.Message);
            }
            return js.SerializeObjectT(response);
        }

        /// <summary>
        /// Removes users from db
        /// </summary>
        /// <param name="requestString">String from browser</param>
        /// <returns>TotalResponse object with answer</returns>
        public string RemoveRowsFromDb(Controller ctr)
        {
            TotalResponse response = null;

            try
            {

                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                response = FormLogPas(request.User);

                if (request.ClientsList.Count > 0)
                {
                    DeleteRows(request.ClientsList);
                }

                if (request.BotsList.Count > 0)
                {
                    DeleteRows(request.BotsList);
                }

                if (request.BotObjectsList.Count > 0)
                {
                    DeleteRows(request.BotObjectsList);
                }

                response = FormResponseStatus(response, true, $"The rows is deleted");
            }
            catch (Exception ex)
            {
                response = FormResponseStatus(response, false, ex.Message);
            }
            return js.SerializeObjectT(response);
        }

        /// <summary>
        /// Edits entries in table
        /// </summary>
        /// <param name="requestString">Request string with entry to update</param>
        /// <returns>Response with status and message</returns>
        public string EditEntries(Controller ctr)
        {
            TotalResponse response = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                response = FormLogPas(request.User);

                if (request.ClientsList.Count > 0)
                {
                    EditRows(request.ClientsList);
                }else if (request.BotsList.Count > 0)
                {
                    EditRows(request.BotsList);
                }else if (request.BotObjectsList.Count > 0)
                {
                    EditRows(request.BotObjectsList);
                }

                response = FormResponseStatus(response, true, $"The row is updated");
            }catch(Exception ex)
            {
                response = FormResponseStatus(response, false, ex.Message);
            }
            return js.SerializeObjectT(response);
        }

    }
}