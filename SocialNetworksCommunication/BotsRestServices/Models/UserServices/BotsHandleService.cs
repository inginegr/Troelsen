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
            switch (bot.BasicBotName)
            {
                case BotNames.FaceBook:
                    return BotTypes.FbBot;
                case BotNames.Telegram:
                    return BotTypes.TgBot;
                case BotNames.Viber:
                    return BotTypes.ViberBot;
                case BotNames.VK:
                    return BotTypes.VkBot;

                default:
                    return BotTypes.NotDefined;
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
                    List<UserBot> botsToStart = (List<UserBot>)FindRow(req.BotsList);

                    if (botsToStart == null)
                    {
                        return FormAnswerString(false, $"Bots are not found inside data base", response);
                    }
                    // If bot list is not empty
                    else
                    {
                        // 
                        foreach(UserBot botToStart in botsToStart)
                        {
                            //If User is owner of this bot
                            if(IsUserHasBot(botToStart, req.User))
                            {
                                //Find objects of bot in db
                                List<BotObject> objList = ((List<BotObject>)GetAllRows(new BotObject())).Where(ob => ob.UserBotId == botToStart.Id).ToList();

                                botToStart.BotObject = objList;

                                ctr.HttpContext.Application.Remove(botToStart.BasicBotName + botToStart.UniqueBotNumber);
                                ctr.HttpContext.Application[botToStart.BasicBotName + botToStart.UniqueBotNumber] = botToStart;

                                //Tuning botservice configs
                                req.ServiceBot.url = ctr.Request.Url.Host;

                                BotParameters botParams = new BotParameters()
                                {
                                    BotId = botToStart.UniqueBotNumber,
                                    ServiceCommands = TgServiceCommands.StartBot,
                                    BotType = GetBotType(botToStart),
                                    BotObjects = objList,
                                    SecretKey = botToStart.SecretKey,
                                    JsonFromServer=js.SerializeObjectT(req.ServiceBot)
                                };
                                AnswerFromBot ans = RequestToBot(botParams, ctr);
                        
                                if (ans.IsTrue)
                                {
                                    List<UserBot> list = new List<UserBot>();
                                    list.Add(botToStart);
                                    EditRows(list);
                                    response.Bot = botToStart;
                                    return FormAnswerString(true, ans.LogMessage, response);
                                }
                                else
                                {
                                    ctr.HttpContext.Application.Remove(botToStart.BasicBotName + botToStart.UniqueBotNumber);

                                    return FormAnswerString(false, ans.LogMessage, response);
                                }
                            }
                            else
                            {
                                return FormAnswerString(false, "User is not owner of this bot", response);
                            }
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