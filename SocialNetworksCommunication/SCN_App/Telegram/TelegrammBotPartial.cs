using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.TelegrammObjects;
using SocialNetworks.Telegramm;
using ServiceLibrary.Various;
using Security;



namespace SCN_App.Telegram
{
    /// <summary>
    /// Command handlers
    /// </summary>
    public partial class TelegrammBot
    {
        /// <summary>
        /// Send the time of bot
        /// </summary>
        /// <param name="tG">TGUpdate object</param>
        private void BotTimeCommand(TGUpdate tG)
        {
            try
            {
                DateTime date = DateTime.Now;

                string response = $"{date.Year} - {date.Month} - {date.Day} / {date.Hour} : {date.Minute} : {date.Second}";

                SendMessageToUser(new string[] { response }, tG.Message.Chat.Id.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Send the ricieved message back to user
        /// </summary>
        /// <param name="tG">TGUpdate object</param>
        private void GiveMessageCommand(TGUpdate tG)
        {
            try
            {
                
                SendMessageToUser(new string[] { tG.ToString() }, tG.Message.Chat.Id.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
