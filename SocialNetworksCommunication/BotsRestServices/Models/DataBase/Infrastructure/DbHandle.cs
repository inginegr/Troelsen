using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects;

namespace BotsRestServices.Models.DataBase.Infrastructure
{
    public class DbHandle
    {
        /// <summary>
        /// Add user to DB
        /// </summary>
        /// <param name="userParam">User object</param>
        public void AddUser(User userParam)
        {
            try
            {
                using (UserContext context=new UserContext())
                {
                    context.UserTable.Add(userParam);
                    context.SaveChanges();
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes user from DB
        /// </summary>
        /// <param name="userParam">User object</param>
        public void DeleteUser(User userParam)
        {
            try
            {
                using(UserContext context=new UserContext())
                {
                    context.UserTable.Remove(userParam);
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Defines if user exists in the table
        /// </summary>
        /// <param name="userParam">User object</param>
        /// <returns>True if exists else false</returns>
        public bool FindUser(User userParam)
        {
            try
            {
                bool retAnsw = false;
                using(UserContext context=new UserContext())
                {
                    retAnsw = context.UserTable.Contains(userParam);
                }

                return retAnsw;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}