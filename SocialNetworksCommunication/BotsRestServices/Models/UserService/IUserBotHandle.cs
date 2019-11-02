using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication9.Models.UserService
{
    public interface IUserBotHandle
    {
        /// <summary>
        /// Id of choosed bot
        /// </summary>
        int ChoosedBotId { get; set; }

        /// <summary>
        /// Start choosed bot
        /// </summary>
        /// <param name="dataParam">Bot data</param>
        /// <returns>True if started</returns>
        bool StartBot(string dataParam);

        /// <summary>
        /// Stop choosed bot
        /// </summary>
        /// <param name="dataToStop">Data to stop bot</param>
        /// <returns>True if stopped</returns>
        bool StopBot(string dataToStop);

        /// <summary>
        /// Get list of registered bot, for user
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        IEnumerable<string> GetBotList(string userData);

        /// <summary>
        /// Choose selected bot
        /// </summary>
        /// <param name="dataToChoose">Data to choose bot</param>
        /// <returns>Id of selected bot</returns>
        int ChooseBot(string dataToChoose);
    }
}
