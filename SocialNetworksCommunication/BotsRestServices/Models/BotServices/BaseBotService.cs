using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.UserServices;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using ServiceLibrary.Various;
using SharedObjectsLibrary;

namespace BotsRestServices.Models.BotServices
{
    public class BaseBotService : UserService
    {
        private string entryPointClass = "ManageBotLibraries.ManageBotsClass";
        private string entryPointMethod = "CallFunctions";
        
        /// <summary>
        /// Path to all dlls
        /// </summary>
        protected string PathToDLLs(Controller ctr)
        {
            return ctr.Server.MapPath(ConfigurationManager.AppSettings["PathToAllLibraries"]);
        }

        /// <summary>
        /// Path to library, that manages all them
        /// </summary>
        protected string PathToManageBotslLibrary(string basePath)
        {
            return basePath + ConfigurationManager.AppSettings["ManageBotsLibrary"];
        }

        /// <summary>
        /// Log errors to file
        /// </summary>
        /// <param name="data"> Data to log </param>
        /// <param name="ctr"> Parent controller </param>
        public void LogData( string data, Controller ctr)
        {
            DirectoryInfo myDir = new DirectoryInfo(ctr.Server.MapPath(ConfigurationManager.AppSettings["LogDirectory"]));

            FileService fs = new FileService();

            if (myDir.Exists == false)
            {
                Directory.CreateDirectory(ctr.Server.MapPath(ConfigurationManager.AppSettings["LogDirectory"]));
            }

            fs.LogData(ctr.Server.MapPath($"{ConfigurationManager.AppSettings["LogDirectory"]}/{ConfigurationManager.AppSettings["LogErrorsFile"]}"), data);
        }

        /// <summary>
        /// Read data from log file
        /// </summary>
        /// <param name="ctr">Controller</param>
        /// <returns>String with log file's data</returns>
        public string ReadLogData(Controller ctr)
        {
            FileService fs = new FileService();

            return fs.ReadFileToString(ctr.Server.MapPath($"{ConfigurationManager.AppSettings["LogDirectory"]}/{ConfigurationManager.AppSettings["LogErrorsFile"]}"));
        }

        /// <summary>
        /// Returns assembly
        /// </summary>
        /// <param name="pathToAssembly">Path to assembly</param>
        /// <returns>Assemble if success</returns>
        protected Assembly LoadAssembly(string pathToAssembly)
        {
            try
            {
                return Assembly.LoadFrom(pathToAssembly);
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

        /// <summary>
        /// Make request to viber bot library
        /// </summary>
        /// <param name="botParameters">Structure with parameters to bot library entry function</param>
        /// <param name="ctr">Controller</param>
        /// <returns>AnswerFromBot structure</returns>
        protected AnswerFromBot RequestToBot(BotParameters botParameters, Controller ctr)
        {
            AnswerFromBot ansMessage = new AnswerFromBot();
            try
            {
                botParameters.PathToLibraries = PathToDLLs(ctr);

                Assembly vBot = Assembly.LoadFrom(PathToManageBotslLibrary(botParameters.PathToLibraries));

                Type vBotType = vBot.GetType(entryPointClass);

                object vBotObject = Activator.CreateInstance(vBotType);

                return (AnswerFromBot)vBotType.InvokeMember(entryPointMethod, BindingFlags.InvokeMethod, null, vBotObject,
                    new object[] { botParameters }, null);
            }
            catch (Exception ex)
            {
                ansMessage.LogMessage = ex.Message;
                ansMessage.IsTrue = false;
                return ansMessage;
            }
        }
    }
}