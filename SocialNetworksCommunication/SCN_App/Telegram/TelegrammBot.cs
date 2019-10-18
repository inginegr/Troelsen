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
    public partial class TelegrammBot
    {
        private FileService fServ = new FileService();
        private CommonService comServ = new CommonService();
        private SLCryptography localCrypto = new SLCryptography();

        // Enabled commands of bot
        private string[] commandsBot = new string[] { "bottime", "givemessage" };

        //Service class
        private HandleClass hc { get; set; }

        //Telegram comunicate
        private TGCommunicate telegramComunicate = null;

        /*---------------------------Flags----------------------------*/
        //Is next listening of unhandled messages enabled
        //private bool IsNextListeningEnabled = false;

        //Is next iteration inside unhandled queue messages enabled
        private bool IsNextQueueIterationEnabled = false;

        /*---------------------------Locks----------------------------*/
        private object IsNextQueueIterationEnabledLock = new object();

        /*---------------------------Properties----------------------------*/
        private bool IsNextQueueIterationEnabledHandle
        {
            get
            {
                lock (IsNextQueueIterationEnabledLock)
                {
                    return IsNextQueueIterationEnabled;
                }
            }

            set
            {
                lock (IsNextQueueIterationEnabledLock)
                {
                    IsNextQueueIterationEnabled = value;
                }
            }
        }

        /// <summary>
        /// Operate messages event handler
        /// </summary>
        private void ReadMessagesHandler()
        {
            try
            {
                IsNextQueueIterationEnabledHandle = true;
                do
                {
                    TGUpdate messageObject = telegramComunicate.HandleQueueMessages.Dequeue();

                    string st = HandleUserMessage(messageObject, commandsBot);

                    ExecuteUserCommand(st, messageObject);

                } while (IsNextQueueIterationEnabledHandle);
            }
            catch (Exception ex)
            {
                if (ex.HResult != -2146233079)
                {
                    throw new Exception(ex.Message);
                }

            }
        }


        /// <summary>
        /// Executes command of user
        /// </summary>
        /// <param name="userCommand">Comman of user</param>
        /// <param name="tG">TGUpdate object</param>
        private void ExecuteUserCommand(string userCommand, TGUpdate tG)
        {
            switch (userCommand)
            {
                case "bottime":
                    {
                        BotTimeCommand(tG);

                        break;
                    }

                default:
                    {
                        SendMessageToUser(commandsBot, tG.Message.Chat.Id.ToString());
                        break;
                    }
            }
        }

        

        /// <summary>
        /// Sends some message to user or chat
        /// </summary>
        /// <param name="messageToSend">Message to send</param>
        /// <param name="userId">Id of user or chat</param>
        private void SendMessageToUser(string[] messageToSend, string userId)
        {
            try
            {
                Dictionary<string, string> sendParams = new Dictionary<string, string>();

                string mes = String.Empty;

                foreach (string s in messageToSend)
                {
                    mes += $"{s} \n\r";
                }

                sendParams.Add("chat_id", userId);
                sendParams.Add("text", mes);

                telegramComunicate.SendMessage(sendParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Check if current command contained in commandlist of bot
        /// </summary>
        /// <param name="tG">Object recieved from bot</param>
        /// <param name="commands">Massive of handled commands</param>
        /// <returns>Return command name if command list of bot contain this command else return string.Empty</returns>
        private string HandleUserMessage(TGUpdate tG, string[] commands)
        {
            try
            {
                string userCommand = tG.Message.Text.ToLower();

                foreach (string s in commands)
                {
                    if (string.CompareOrdinal(userCommand, s) == 0)
                        return s;
                }

                return String.Empty;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void StartListenBot()
        {
            try
            {
                telegramComunicate.RegisterOnQueueEvent(ReadMessagesHandler);
                telegramComunicate.StartGettingMessages();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void StopListenBot()
        {
            try
            {
                telegramComunicate.StopGettingMessages();
                telegramComunicate.UnRegisterOnQueueEvent(ReadMessagesHandler);
                IsNextQueueIterationEnabled = false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Load saved token
        /// </summary>
        /// <returns></returns>
        public string LoadToken()
        {
            string returnString = null;
            try
            {
                string tkn = fServ.ReadFileToString("tkn.txt");

                byte[] bt = comServ.StringToMassive<byte>(tkn, " ", typeof(byte)).ToArray();

                returnString = localCrypto.DecryptData(bt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnString;
        }


        public TelegrammBot()
        {
            telegramComunicate = new TGCommunicate(LoadToken());
        }
    }
}
