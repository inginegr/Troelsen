using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.TGObjects;
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
        /// Handle bottime command
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



        private void GiveMessageCommand(TGUpdate tG)
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
    }
}
