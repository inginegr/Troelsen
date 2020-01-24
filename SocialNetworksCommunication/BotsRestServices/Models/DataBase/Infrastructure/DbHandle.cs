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
        /// Do checking of object is equal to null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToCheck"></param>
        /// <returns>If not null return true, else false</returns>
        private bool checkIfNull<T>(T objectToCheck)
        {
            if (objectToCheck != null)
            {
                return true;
            }
            else
            {
                throw new Exception($"User with Id {nameof(objectToCheck)} not found in context");
            }
        }

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
        /// Find row in database
        /// </summary>
        /// <typeparam name="T">object to find</typeparam>
        /// <param name="rowToFind">object to find</param>
        /// <returns>Found object if exist, else null</returns>
        public object FindRow<T>(T rowToFind) where T : class
        {
            try
            {
                object rowToReturn = null;

                using (UserContext context = new UserContext())
                {
                    if (rowToFind.GetType().Name == nameof(UserData))
                    {
                        rowToReturn = context.UserTable.Find(int.Parse(rowToFind.GetType().GetProperty("Id").GetValue(rowToFind).ToString()));
                    }
                    else if (rowToFind.GetType().Name == nameof(UserBot))
                    {
                        rowToReturn = context.BotsTable.Find(int.Parse(rowToFind.GetType().GetProperty("Id").GetValue(rowToFind).ToString()));
                    }
                    else if (rowToFind.GetType().Name == nameof(BotObject))
                    {
                        rowToReturn = context.BotObjectsTable.Find(int.Parse(rowToFind.GetType().GetProperty("Id").GetValue(rowToFind).ToString()));
                    }
                }

                return rowToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Find rows in database
        /// </summary>
        /// <typeparam name="T">object to find</typeparam>
        /// <param name="rowsToFind">objects to find</param>
        /// <returns>Found T if exist, else null</returns>
        public object FindRows<T>(List<T> rowsToFind) where T : class
        {
            try
            {
                object retObj = new object();          
                using (UserContext context = new UserContext())
                {
                    if (rowsToFind is List<UserData>)
                    {
                        retObj=(List<T>)context.UserTable.Where(ut => (rowsToFind as List<UserData>).Exists(rtf => rtf.Id == ut.Id));
                    }
                    else if (rowsToFind is List<UserBot>)
                    {
                        retObj=(List<T>)context.BotsTable.Where(ut => (rowsToFind as List<UserBot>).Exists(rtf => rtf.Id == ut.Id));
                    }
                    else if (rowsToFind is List<BotObject>)
                    {
                        retObj= context.BotObjectsTable.Where(ut => ((List<BotObject>)rowsToFind).Exists(rtf => rtf.Id == ut.Id));
                    }
                }

                return retObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add rows to DB
        /// </summary>
        /// <param name="userList">Collection of rows</param>
        public void AddRows<T>(List<T> rowsToAdd) where T: class
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    foreach(T t in rowsToAdd)
                    {
                        if(t.GetType().Name == nameof(UserData))
                        {
                            context.UserTable.Add(t as UserData);
                        }else if (t.GetType().Name == nameof(UserBot))
                        {
                            context.BotsTable.Add(t as UserBot);
                        }else if (t.GetType().Name == nameof(BotObject))
                        {
                            context.BotObjectsTable.Add(t as BotObject);
                        }
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
        /// Deletes users from DB
        /// </summary>
        /// <param name="usersParam">Users object</param>
        public void DeleteRows<T>(List<T> rowsToDelete) where T: class
        {            
            try
            {
                using (UserContext context = new UserContext())
                {
                    foreach (T t in rowsToDelete)
                    {
                        if (t.GetType().Name == nameof(UserData))
                        {
                            UserData userToDelete = context.UserTable.ToList().
                                Where(user => user.Id == (t as UserData).Id).FirstOrDefault();
                            if (checkIfNull(userToDelete))
                            {
                                List<UserBot> botsToDelete = context.BotsTable.
                                    Where(bot => bot.UserDataId == userToDelete.Id).ToList();
                                botsToDelete.ForEach(bot =>
                                {
                                    List<BotObject> listToDelete = context.BotObjectsTable.
                                    Where(obj => obj.UserBotId == bot.Id).ToList();
                                    context.BotObjectsTable.RemoveRange(listToDelete);
                                });
                                context.BotsTable.RemoveRange(botsToDelete);
                                context.UserTable.Remove(userToDelete);
                            }
                        }
                        else if (t.GetType().Name == nameof(UserBot))
                        {
                            UserBot botToDelete = context.BotsTable.ToList().
                                Where(bot => bot.Id == (t as UserBot).Id).FirstOrDefault();
                            if (checkIfNull(botToDelete))
                            {
                                List<BotObject> objectsToDelete = context.BotObjectsTable.ToList().
                                    Where(obj => obj.UserBotId == botToDelete.Id).ToList();
                                context.BotObjectsTable.RemoveRange(objectsToDelete);
                                context.BotsTable.Remove(botToDelete);
                            }
                        }
                        else if (t.GetType().Name == nameof(BotObject))
                        {
                            BotObject objectToDelete = context.BotObjectsTable.ToList().
                                Where(botObj => botObj.Id == (t as BotObject).Id).FirstOrDefault();
                            if (checkIfNull(objectToDelete))
                            {
                                context.BotObjectsTable.Remove(objectToDelete);
                            }
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
        /// Gets all users from table
        /// <param name="rowType"/> Type of table to get
        /// </summary>
        /// <returns>All users in table</returns>
        public object GetAllRows<T>(T rowType) where T: class
        {
            try
            {
                object retAnsw=null;
                using (UserContext context = new UserContext())
                {
                    
                    if (rowType.GetType().Name == nameof(UserData))
                    {
                        retAnsw = context.UserTable.ToList();
                    }
                    else if (rowType.GetType().Name == nameof(UserBot))
                    {
                        retAnsw = context.BotsTable.ToList();
                    }
                    else if (rowType.GetType().Name == nameof(BotObject))
                    {
                        retAnsw = context.BotObjectsTable.ToList();
                    }

                    if (retAnsw == null)
                    {
                        throw new Exception($"Cannot find element of type: {nameof(T)}");
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
        /// Edits rows in the table
        /// <paramref name="newUsersList"/> rows to edit from client side 
        /// </summary>
        public void EditRows<T>(List<T> rowsToEdit)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    foreach(T t in rowsToEdit)
                    {
                        if (t.GetType().Name == nameof(UserData))
                        {
                            UserData newClient = t as UserData;
                            UserData clientToEdit = context.UserTable.ToList().Where(user =>
                            user.Id == newClient.Id).FirstOrDefault();
                            clientToEdit.Login = newClient.Login;
                            clientToEdit.Password = newClient.Password;
                        }
                        else if (t.GetType().Name == nameof(UserBot))
                        {
                            UserBot newBot = t as UserBot;
                            UserBot botToEdit = context.BotsTable.ToList().Where(bot =>
                              bot.Id == newBot.Id).FirstOrDefault();
                            botToEdit.FriendlyBotName = newBot.FriendlyBotName;
                            botToEdit.BotStatus = newBot.BotStatus;
                            botToEdit.UserDataId = newBot.UserDataId;
                        }
                        else if (t.GetType().Name == nameof(BotObject))
                        {
                            BotObject newObj = t as BotObject;
                            BotObject objectToEdit = context.BotObjectsTable.ToList().Where(obj =>
                              obj.Id == newObj.Id).FirstOrDefault();
                            objectToEdit.PathToObject = newObj.PathToObject;
                            objectToEdit.UserBotId = newObj.UserBotId;
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}