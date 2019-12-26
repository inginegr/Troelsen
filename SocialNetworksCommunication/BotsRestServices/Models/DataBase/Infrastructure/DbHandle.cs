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
        /// <returns></returns>
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

        public T FindRow<T>(T rowToFind) where T: class
        {
            try
            {
                T rowToReturn = null;

                using(UserContext context=new UserContext())
                {
                    if (nameof(T) == nameof(UserData))
                    {
                        return (T)context.UserTable.Find((UserData)Activator.CreateInstance(rowToFind.GetType()));
                    }
                    else if (nameof(T) == nameof(UserBot))
                    {
                        context.BotsTable.Find((UserBot)Activator.CreateInstance(rowToFind.GetType()));
                    }
                    else if (nameof(T) == nameof(BotObject))
                    {
                        context.BotObjectsTable.Find((BotObject)Activator.CreateInstance(rowToFind.GetType()));
                    }
                }


                return rowToFind;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add rows to DB
        /// </summary>
        /// <param name="userList">Collection of rows</param>
        public void AddRows<T>(List<T> rowsToAdd)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    foreach(T t in rowsToAdd)
                    {
                        if(nameof(T) == nameof(UserData))
                        {
                            context.UserTable.Add((UserData)Activator.CreateInstance(t.GetType()));
                        }else if (nameof(T) == nameof(UserBot))
                        {
                            context.BotsTable.Add((UserBot)Activator.CreateInstance(t.GetType()));
                        }else if (nameof(T) == nameof(BotObject))
                        {
                            context.BotObjectsTable.Add((BotObject)Activator.CreateInstance(t.GetType()));
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
                        if (nameof(T) == nameof(UserData))
                        {
                            UserData userToDelete = context.UserTable.Find(t.GetType().GetProperty("Id").GetValue(t));
                            if (!checkIfNull(userToDelete))
                            {
                                context.UserTable.Remove(userToDelete);
                            }
                        }
                        else if (nameof(T) == nameof(UserBot))
                        {
                            UserBot botToDelete = context.BotsTable.Find(t.GetType().GetProperty("Id").GetValue(t));
                            if (!checkIfNull(botToDelete))
                            {
                                context.BotsTable.Remove(botToDelete);
                            }
                        }
                        else if (nameof(T) == nameof(BotObject))
                        {
                            BotObject objectToDelete = context.BotObjectsTable.Find(t.GetType().GetProperty("Id").GetValue(t));
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
        /// </summary>
        /// <returns>All users in table</returns>
        public List<T> GetRows<T>() where T: class
        {
            try
            {
                List<T> retAnsw = new List<T>();
                using (UserContext context = new UserContext())
                {
                    T singleElement = null;

                    if (nameof(T) == nameof(UserData))
                    {
                        retAnsw = (List<T>)context.UserTable.Take(context.UserTable.Count());                        
                    }
                    else if (nameof(T) == nameof(UserBot))
                    {
                        retAnsw = (List<T>)context.BotsTable.Take(context.BotsTable.Count());
                    }
                    else if (nameof(T) == nameof(BotObject))
                    {
                        retAnsw = (List<T>)context.BotObjectsTable.Take(context.BotObjectsTable.Count());
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
                    List<T> tempCollection = new List<T>();
                    if (nameof(T) == nameof(UserData))
                    {
                        tempCollection.AddRange((List<T>)context.UserTable.Where(a =>
                        rowsToEdit.Exists(ed =>
                        int.Parse(ed.GetType().GetProperty("Id").GetValue(ed).ToString()) == a.Id)));
                    }
                    else if (nameof(T) == nameof(UserBot))
                    {
                        tempCollection.AddRange((List<T>)context.UserTable.Where(a =>
                       rowsToEdit.Exists(ed =>
                       int.Parse(ed.GetType().GetProperty("Id").GetValue(ed).ToString()) == a.Id)));
                    }
                    else if (nameof(T) == nameof(BotObject))
                    {
                        tempCollection.AddRange((List<T>)context.UserTable.Where(a =>
                        rowsToEdit.Exists(ed =>
                        int.Parse(ed.GetType().GetProperty("Id").GetValue(ed).ToString()) == a.Id)));
                    }

                    tempCollection.ForEach(elToEdit =>
                    {
                        PropertyInfo[] newProps = rowsToEdit.Find(e => int.Parse(e.GetType().GetProperty("Id").GetValue(e).ToString()) ==
                          int.Parse(elToEdit.GetType().GetProperty("Id").GetValue(elToEdit).ToString())).GetType().GetProperties();
                        PropertyInfo[] oldProps = elToEdit.GetType().GetProperties();

                        for (int i = 0; i < oldProps.Length; i++)
                        {
                            foreach (PropertyInfo newProp in newProps)
                            {
                                if (oldProps[i].Name == newProp.Name)
                                {
                                    oldProps[i].SetValue(oldProps[i], newProp.GetValue(newProp));
                                }
                            }
                        }

                    });

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