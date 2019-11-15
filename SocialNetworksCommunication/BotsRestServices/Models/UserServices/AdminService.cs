using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.RequestToServer;
using ServiceLibrary.Serialization;


namespace BotsRestServices.Models.UserServices
{
    /// <summary>
    /// Admin functions
    /// </summary>
    public class AdminService : UserService
    {
        
        /// <summary>
        /// Add user to db
        /// </summary>
        /// <param name="requestString">String from browser</param>
        /// <returns>Json string answer text</returns>
        public string AddClientToDb(string requestString)
        {
            TotalRequest request = new TotalRequest();
            TotalResponse resp = new TotalResponse();

            try
            {
                request = GetRequestObject(requestString);

                dbHandle.AddUser(request.DataRequest.User);

                resp = FormLogPas(request.User);

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
        public string GetClientsList(string s)
        {
            TotalRequest req = GetRequestObject(s);
            TotalResponse resp = FormLogPas(req.User);
            
            try
            {
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
        public string RemoveClientFromDb(string requestString)
        {
            TotalRequest request = GetRequestObject(requestString);
            TotalResponse response = FormLogPas(request.User);
            
            try
            {
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
        public string EditClient(string requestString)
        {
            TotalRequest request = GetRequestObject(requestString);
            TotalResponse response = FormLogPas(request.User);

            try
            {
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