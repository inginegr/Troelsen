﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.UserServices;
using System.Reflection;
using System.Configuration;

namespace BotsRestServices.Models.BotServices
{
    public class BaseBotService : UserService
    {
        /// <summary>
        /// Path to library, that rules all bots
        /// </summary>
        protected string pathToBotsLibrary { get => ConfigurationManager.AppSettings["PathBotsLibrary"]; }

        /// <summary>
        /// Returns assembly
        /// </summary>
        /// <param name="pathToAssembly">Path to assembly</param>
        /// <returns>Assemble if success</returns>
        protected Assembly LoadAssembly(string pathToAssembly)
        {
            try
            {
                return Assembly.Load(pathToAssembly);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Some type in assembly
        /// </summary>
        /// <param name="asm">Assembly</param>
        /// <param name="typeName">Path to type name</param>
        /// <returns>Some type</returns>
        protected Type GetSomeTypeInAssembly(Assembly asm, string typeName)
        {
            try
            {
                return asm.GetType(typeName);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get object of some type
        /// </summary>
        /// <param name="type">Type of object</param>
        /// <returns>object</returns>
        protected object GetObject(Type type)
        {
            try
            {
                return Activator.CreateInstance(type);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}