using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.DataBase.Initializers;
using System.Data.Entity.Core;
using System.Reflection;

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
                using (UserContext context = new UserContext())
                {
                    context.UserTable.Add(userParam);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add users to DB
        /// </summary>
        /// <param name="userList">Users to ad to db</param>
        public void AddUsers(List<UserData> userList)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    foreach(UserData ud in userList)
                    {
                        context.UserTable.Add(ud);
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
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
                using (UserContext context = new UserContext())
                {
                    UserData userToDelete = context.UserTable.Find(userParam.Id);
                    if (userToDelete != null)
                    {
                        context.UserTable.Remove(userToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"User with Id {userParam.Id} not found in context");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes users from DB
        /// </summary>
        /// <param name="usersParam">Users object</param>
        public void DeleteUsers(List<UserData> userParam)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    string retString = string.Empty;
                    foreach(UserData user in userParam)
                    {
                        UserData userToDelete = context.UserTable.Find(user.Id);
                        if (userToDelete != null)
                        {
                            context.UserTable.DeleteObject(userToDelete);
                            context.UserTable.Remove(userToDelete);
                        }else
                        {
                            throw new Exception($"User with Id {userToDelete.Id} not found in context");
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Defines if user exists in the table
        /// </summary>
        /// <param name="userParam">User object</param>
        /// <returns>UserData object if found, null else</returns>
        public UserData FindUser(User userParam)
        {
            try
            {
                UserData retAnsw = new UserData();
                using (UserContext context = new UserContext())
                {
                    retAnsw = context.UserTable.Where(a => ((a.Login == userParam.Login) && (a.Password == userParam.Password))).FirstOrDefault<UserData>();
                }

                return retAnsw;

            }
            catch (Exception ex)
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
                    foreach (UserData u in ans)
                    {
                        retAnsw.Add(u);
                    }

                    retAnsw.ForEach(
                        x =>
                        {
                            List<UserBot> bts = x.Bots;
                            bts.ForEach(
                                b =>
                                {
                                    List<BotObject> bo = b.BotObject;
                                }
                                );
                        }
                        );

                }

                return retAnsw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edits users in the table
        /// <paramref name="userData"/> users to edit 
        /// </summary>
        public void EditUsers(List<UserData> usersToEdit)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    int[] elems = usersToEdit.Select(x => x.Id).ToArray();

                    List<UserData> users = context.UserTable.Where(x => elems.Contains(x.Id)).ToList();

                    foreach (UserData u in usersToEdit)
                    {
                        UserData userToUpdate = context.UserTable.Where(x => x.Id == u.Id).FirstOrDefault();
                        userToUpdate.Id = u.Id;
                        userToUpdate.Login = u.Login;
                        userToUpdate.Password = u.Password;
                        userToUpdate.Bots.Clear();
                        foreach (UserBot ub in u.Bots)
                        {
                            userToUpdate.Bots.Add(ub);
                        }
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