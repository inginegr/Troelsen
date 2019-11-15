using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.DataBase.Initializers;
using System.Data.Entity.Core;

namespace BotsRestServices.Models.DataBase.Infrastructure
{
    public class DbHandle
    {
        


        /// <summary>
        /// Add user to DB
        /// </summary>
        /// <param name="userParam">User object</param>
        public void AddUser(UserData userParam)
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
        public void DeleteUser(UserData userParam)
        {
            try
            {
                using(UserContext context=new UserContext())
                {
                    context.UserTable.Remove(userParam);
                    context.SaveChanges();
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
                UserData retAnsw = null;
                using(UserContext context=new UserContext())
                {
                    retAnsw = context.UserTable.Where(a => ((a.Login == userParam.Login) && (a.Password == userParam.Password))).FirstOrDefault<UserData>();
                }

                if (retAnsw == null)
                    return false;
                else
                    return true;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Gets all users from table
        /// </summary>
        /// <returns>All users in table</returns>
        public List<UserData> GetUsers()
        {
            try
            {
                List<UserData> retAnsw = new List<UserData>();
                using (UserContext context = new UserContext())
                {
                    var ans = context.UserTable;
                    foreach(UserData u in ans)
                    {
                        retAnsw.Add(u);
                    }
                }

                return retAnsw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edits user in the table
        /// </summary>
        /// <returns>All users in table</returns>
        public void EditUser(List<UserData> userData)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    List<UserData> users = new List<UserData>();
                    foreach(UserData u in userData)
                    {
                        UserData user = context.UserTable.SingleOrDefault(a => ((a.Login == u.Login) && (a.Password == u.Password) && (a.Id == u.Id)));
                        user = u;
                        users.Add(user);
                    }

                    context.SaveChanges();
                }

                //return retAnsw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}