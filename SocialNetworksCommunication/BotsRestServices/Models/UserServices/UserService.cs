using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.DataBase.Infrastructure;
using BotsRestServices.Models.DataBase.Infrastructure;
using BotsRestServices.Models.Objects;
using BotsRestServices.Models.Objects.AnswersFromServer;


namespace BotsRestServices.Models.UserServices
{
    public class UserService
    {

        private DbHandle db = new DbHandle();

        /// <summary>
        /// Login to the system
        /// </summary>
        /// <param name="authorize">User login and password</param>
        /// <returns>True if authorized, else false</returns>
        public bool LogIn(User authorize)
        {
            try
            {
                return db.FindUser(authorize);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds login and password to response
        /// </summary>
        /// <param name="userParam">Login and password </param>
        /// <returns>TotalResponse filled by login and password</returns>
        public TotalResponse FormLogPas(User userParam)
        {
            try
            {
                return new TotalResponse { LogPas = userParam };                                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}