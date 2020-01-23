using BotsRestServices.Models.BotServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.RequestToServer;
using BotsRestServices.Models.Objects.DbObjects;
using SharedObjectsLibrary;
using System.Web.Mvc;



namespace BotsRestServices.Models.UserServices
{
    /// <summary>
    /// Make simple operations like remove, delete or edit bot objects 
    /// </summary>
    public class BotsHandleService : BaseBotService 
    {
        /// <summary>
        /// Returns Type of bot, using BasicBotName, that stored in db
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        private BotTypes GetBotType(UserBot bot)
        {
            BotNames bn = new BotNames();            
            if (bot.BasicBotName == bn.FaceBook)
            {
                return BotTypes.FbBot;
            }else if(bot.BasicBotName == bn.Telegram)
            {
                return BotTypes.TgBot;
            }else if(bot.BasicBotName == bn.Viber)
            {
                return BotTypes.ViberBot;
            }else 
            {
                return BotTypes.VkBot;
            }
        }

        /// <summary>
        /// Form response string 
        /// </summary>
        /// <param name="IsTrue">Status of answer</param>
        /// <param name="mesToSend">Answer text</param>
        /// <param name="totalResponse">TotalResponse class answer from server</param>
        /// <returns>json string</returns>
        private string FormAnswerString(bool IsTrue, string mesToSend, TotalResponse totalResponse)
        {
            try
            {
                totalResponse.IsTrue.IsTrue = IsTrue;
                totalResponse.IsTrue.Text = mesToSend;
                return js.SerializeObjectT(totalResponse);
            }catch(Exception ex)
            {
                totalResponse.IsTrue.IsTrue = false;
                totalResponse.IsTrue.Text = $"Error occured inside FormAnswerString method: --> {ex.Message}";
                return js.SerializeObjectT(totalResponse);
            }
        }

        /// <summary>
        /// Makes checking if user is owner of bot
        /// </summary>
        /// <param name="bot">Bot, that must be checked</param>
        /// <param name="user">User, that can be owner of bot</param>
        /// <returns></returns>
        public bool IsUserHasBot(UserBot bot, UserData user)
        {
            if (CheckIfAdmin(user))
            {
                return true;
            }
            else
            {
                UserData client = CheckIfClient(user);

                if (client != null)
                {
                    if (bot.UserDataId == client.Id)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Starts bot, that included id json body of request to server
        /// </summary>
        /// <param name="ctr">Controller class</param>
        /// <returns>TotalResponse in json string format</returns>
        public string StartBot(Controller ctr)
        {
            TotalResponse response = new TotalResponse();
            try
            {
                TotalRequest req = jsd.DeserializeToObjectT<TotalRequest>(ReadDataFromBrowser(ctr));

                if (!CheckIfRegistered(req.User).IsTrue.IsTrue)
                {
                    return js.SerializeObjectT(FormResponseStatus(response, false, "User is not registered"));
                }
                else
                {
                    UserBot bot = (UserBot)FindRow(req.Bot);

                    if (bot == null)
                    {
                        return FormAnswerString(false, $"Bot {req.BotsList.FirstOrDefault().FriendlyBotName} is not found in Data Base", response);
                    }
                    // If client has bot remove prev state from ApplicationContext, change row in db and set ApplicationContext and so on
                    else if (IsUserHasBot(bot, req.User))
                    {
                        
                        //Find objects of bot in db
                        List<BotObject> objList = ((List<BotObject>)GetAllRows(new BotObject())).Where(ob => ob.UserBotId == bot.Id).ToList();

                        bot.BotObject = objList;

                        ctr.HttpContext.Application.Remove(bot.BasicBotName + bot.UniqueBotNumber);
                        ctr.HttpContext.Application[bot.BasicBotName + bot.UniqueBotNumber] = bot;
                        
                        BotParameters botParams = new BotParameters()
                        {
                            BotId = bot.UniqueBotNumber,
                            ServiceCommands = TgServiceCommands.StartBot,
                            BotType = GetBotType(bot),
                            BotObjects = objList,
                            SecretKey = bot.SecretKey
                        };
                        AnswerFromBot ans = RequestToBot(botParams, ctr);
                        
                        if (ans.IsTrue)
                        {
                            List<UserBot> list = new List<UserBot>();
                            list.Add(bot);
                            EditRows(list);
                            response.Bot = bot;
                            return FormAnswerString(true, ans.LogMessage, response);
                        }
                        else
                        {
                            ctr.HttpContext.Application.Remove(bot.BasicBotName + bot.UniqueBotNumber);

                            return FormAnswerString(false, ans.LogMessage, response);
                        }
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}