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

                dbHandle.AddUser(request.DataRequest.User);


                resp = FormResponseStatus(resp, true, "The user is added");
            }
            catch(Exception ex)
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
                resp = FormResponse(ctr);
                List<UserData> list = dbHandle.GetUsers();
                resp = FormResponseStatus(resp, true, "Hire is the user list");
                resp.Users = list.ToArray();
            } catch(Exception ex)
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

                dbHandle.DeleteUser(request.DataRequest.User);

                response = FormResponseStatus(response, true, $"The user with login {request.User.Login} is deleted");
            }
            catch(Exception ex)
            {
                response = FormResponseStatus(response, false, ex.Message);
            }
            return js.SerializeObjectT(response);
        }

        /// <summary>
        /// Edits user in table
        /// </summary>
        /// <param name="requestString">Request string with user to update</param>
        /// <returns>Response with status and message</returns>
        public string EditClient(Controller ctr)
        {
            TotalResponse response = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                response = FormLogPas(request.User);

                List<UserData> usersToUpdate = new List<UserData>();
                usersToUpdate.Add(request.DataRequest.User);
                dbHandle.EditUser(usersToUpdate);

                response = FormResponseStatus(response, true, $"The user {request.DataRequest.User.Login} is updated");
            }catch(Exception ex)
            {
                response = FormResponseStatus(response, false, ex.Message);
            }
            return js.SerializeObjectT(response);
        }

    }
}