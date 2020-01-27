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
            }
            catch (Exception ex)
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
        public string StartBots(Controller ctr)
        {
            TotalResponse response = new TotalResponse();
            try
            {
                TotalRequest req = jsd.DeserializeToObjectT<TotalRequest>(ReadDataFromBrowser(ctr));
                string retString = string.Empty;

                if (!CheckIfRegistered(req.User).IsTrue.IsTrue)
                {
                    return js.SerializeObjectT(FormResponseStatus(response, false, "User is not registered"));
                }
                else
                {
                    List<UserBot> botsToStart = FindRows(req.BotsList);

                    if (botsToStart == null)
                    {
                        return FormAnswerString(false, $"Bots are not found inside data base", response);
                    }
                    // If bot list is not empty
                    else
                    {
                        AnswerFromBot botAnswer = new AnswerFromBot();                        
                        // 
                        foreach (UserBot botToStart in botsToStart)
                        {
                            //If User is owner of this bot
                            if (IsUserHasBot(botToStart, req.User))
                            {
                                //Find objects of bot in db
                                List<BotObject> objList = ((List<BotObject>)GetAllRows(new BotObject())).Where(ob => ob.UserBotId == botToStart.Id).ToList();

                                botToStart.BotObjects = objList;

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
                                    JsonFromServer = js.SerializeObjectT(req.ServiceBot)
                                };

                                botAnswer = RequestToBot(botParams, ctr);

                                if (botAnswer.IsTrue)
                                {
                                    botToStart.BotStatus = true;
                                }
                                else
                                {
                                    ctr.HttpContext.Application.Remove(botToStart.BasicBotName + botToStart.UniqueBotNumber);
                                    botToStart.BotStatus = false;
                                }

                                response.Bots.Add(botToStart);
                                retString += $"You have been succesfully started the bot: {botToStart.FriendlyBotName} \n";
                            }
                            else
                            {
                                retString += $"You have no permission to this bot \n";
                            }
                        }
                    }
                }

                response.IsTrue.IsTrue = true;
                response.IsTrue.Text = retString;

                return js.SerializeObjectT(response);
            }
            catch (Exception ex)
            {
                response.IsTrue.IsTrue = false;
                response.IsTrue.Text = $"The exception occured while starting the bot: --> {ex.Message}";
                return js.SerializeObjectT(response);
            }
        }


        /// <summary>
        /// Starts bot, that included id json body of request to server
        /// </summary>
        /// <param name="ctr">Controller class</param>
        /// <returns>TotalResponse in json string format</returns>
        public string StopBots(Controller ctr)
        {
            TotalResponse response = new TotalResponse();
            try
            {
                TotalRequest req = jsd.DeserializeToObjectT<TotalRequest>(ReadDataFromBrowser(ctr));
                string retString = string.Empty;

                if (!CheckIfRegistered(req.User).IsTrue.IsTrue)
                {
                    return js.SerializeObjectT(FormResponseStatus(response, false, "User is not registered"));
                }
                else
                {
                    List<UserBot> botsToStop = FindRows(req.BotsList);

                    if (botsToStop == null)
                    {
                        return FormAnswerString(false, $"Bots are not found inside data base", response);
                    }
                    // If bot list is not empty
                    else
                    {
                        AnswerFromBot botAnswer = new AnswerFromBot();
                        // 
                        foreach (UserBot botToStop in botsToStop)
                        {
                            //If User is owner of this bot
                            if (IsUserHasBot(botToStop, req.User))
                            {
                                //Find objects of bot in db
                                List<BotObject> objList = ((List<BotObject>)GetAllRows(new BotObject())).Where(ob => ob.UserBotId == botToStop.Id).ToList();

                                botToStop.BotObjects = objList;

                                ctr.HttpContext.Application.Remove(botToStop.BasicBotName + botToStop.UniqueBotNumber);
                                
                                BotParameters botParams = new BotParameters()
                                {
                                    BotId = botToStop.UniqueBotNumber,
                                    ServiceCommands = TgServiceCommands.StopBot,
                                    BotType = GetBotType(botToStop),
                                    BotObjects = objList,
                                    SecretKey = botToStop.SecretKey,
                                    JsonFromServer = js.SerializeObjectT(req.ServiceBot)
                                };

                                botAnswer = RequestToBot(botParams, ctr);

                                if (botAnswer.IsTrue)
                                {
                                    botToStop.BotStatus = true;
                                }
                                else
                                {
                                    ctr.HttpContext.Application[botToStop.BasicBotName + botToStop.UniqueBotNumber] = botToStop;
                                    botToStop.BotStatus = false;
                                }

                                response.Bots.Add(botToStop);
                                retString += $"You have been succesfully stoped the bot: {botToStop.FriendlyBotName} \n";
                            }
                            else
                            {
                                retString += $"You have no permission to this bot \n";
                            }
                        }
                    }
                }

                response.IsTrue.IsTrue = true;
                response.IsTrue.Text = retString;

                return js.SerializeObjectT(response);
            }
            catch (Exception ex)
            {
                response.IsTrue.IsTrue = false;
                response.IsTrue.Text = $"The exception occured while starting the bot: --> {ex.Message}";
                return js.SerializeObjectT(response);
            }
        }

    }
}