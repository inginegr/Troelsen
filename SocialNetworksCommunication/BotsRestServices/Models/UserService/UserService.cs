using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.JsonObjects;

namespace BotsRestServices.Models.UserService
{
    public class UserService : IUserBehaviour, IUserBotHandle
    {
        /// <summary>
        /// Id of choosed bot
        /// </summary>
        public int ChoosedBotId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Is iser authorized in the system
        /// </summary>
        public bool IsAuthorized { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Is user registered in the system
        /// </summary>
        public bool IsRegistered { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Choose selected bot
        /// </summary>
        /// <param name="dataToChoose">Data to choose bot</param>
        /// <returns>Id of selected bot</returns>
        public int ChooseBot(string dataToChoose)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list of registered bot, for user
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public IEnumerable<string> GetBotList(string userData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Login to the system
        /// </summary>
        /// <param name="dataToLogin">User login and password</param>
        /// <returns>True if authorized, else false</returns>
        public bool LogIn(Authorize dataToLogin)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Start choosed bot
        /// </summary>
        /// <param name="dataParam">Bot data</param>
        /// <returns>True if started</returns>
        public bool StartBot(string dataParam)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop choosed bot
        /// </summary>
        /// <param name="dataToStop">Data to stop bot</param>
        /// <returns>True if stopped</returns>
        public bool StopBot(string dataToStop)
        {
            throw new NotImplementedException();
        }
    }
}