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
using System.Data.Entity;
using System.Collections;

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
                            //context.UserTable.Remove(userToDelete);
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
        /// <paramref name="newUsersList"/> new users from client side 
        /// </summary>
        public void EditUsers(List<UserData> newUsersList)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    //int[] elems = usersToEdit.Select(x => x.Id).ToArray();

                    List<UserData> dbUsers = context.UserTable.Include(c=>c.Bots.Select(o=>o.BotObject)).ToList();

                    EditClients(dbUsers, newUsersList);
                    dbUsers.ForEach(oldUser =>
                    {
                        UserData newUser = newUsersList.Find(x => x.Id == oldUser.Id);
                        EditClients(oldUser.Bots, newUser.Bots);
                        oldUser.Bots.ForEach(oldBot =>
                        {
                            UserBot newBot = newUser.Bots.Find(x => x.Id == oldBot.Id);
                            EditClients(oldBot.BotObject, newBot.BotObject);
                        });
                    });

                    context.SaveChanges();
                }

                //return retAnsw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Copy data from one collection to other
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldEnums">Receiver of new data</param>
        /// <param name="newEnums">Source of new data</param>
        private void EditClients<T>(List<T> oldEnums, List<T> newEnums)
        {
            List<T> remainedItems = new List<T>();
            try
            {
                int newCount = newEnums.Count;
                int oldCount = oldEnums.Count;

                int totalCount = 0;
                if (oldCount < newCount)
                {
                    totalCount = oldCount;
                    remainedItems = newEnums;
                }
                else
                {
                    totalCount = newCount;
                    remainedItems = oldEnums;
                }
                for (int i = 0; i < totalCount; i++)
                {

                    // If element exists in new collection
                    T newElementInCollection = newEnums
                        .Find(a => int.Parse(a.GetType().GetProperty("Id").GetValue(a).ToString()) ==
                        int.Parse(oldEnums[i].GetType().GetProperty("Id").GetValue(a).ToString()));

                    // Assign all new properties to old element
                    if (newElementInCollection != null)
                    {
                        PropertyInfo[] oldProps = oldEnums[i].GetType().GetProperties();
                        PropertyInfo[] newProps = newElementInCollection.GetType().GetProperties();

                        for(int a = 0; a < oldProps.Length; a++)
                        {
                            if (oldProps[a].PropertyType.Name != "List`1")
                            {
                                foreach(PropertyInfo newProp in newProps)
                                {
                                    if (newProp.Name == oldProps[a].Name)
                                    {
                                        oldProps[a].SetValue(oldEnums[i], newProp.GetValue(newElementInCollection));
                                    }
                                }
                            }
                        }
                        int index = 0;
                        if (oldCount < newCount)
                        {
                            index=newEnums.FindIndex(x=>)
                        }
                        else
                        {
                        }

                        remainedItems.re
                    }
                }
                if (oldCount < newCount)
                {
                    oldEnums.AddRange(remainedItems);
                }
                else
                {
                    oldEnums.RemoveAll(oldEl=>remainedItems.Contains(oldEl));
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}