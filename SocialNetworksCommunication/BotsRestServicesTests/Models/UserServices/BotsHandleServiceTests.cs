using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotsRestServices.Models.DataBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotsRestServices.Models.Objects.DbObjects;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Mvc;
using BotsRestServices.Controllers.Interface;
using BotsRestServices.Models.Objects.RequestToServer;
using SharedObjectsLibrary;

namespace BotsRestServices.Models.UserServices.Tests
{
    [TestClass()]
    public class BotsHandleServiceTests
    {
        [TestMethod()]
        public void IsUserHasBotTest_UserIsClient()
        {
            BotsHandleService botsHandle = new BotsHandleService();

            UserData user = new UserData() { Id=1, Login = "Navi", Password = "boti" };
            UserBot bot = new UserBot() { Id = 1, UserDataId=1 };

            bool ans = botsHandle.IsUserHasBot(bot, user);

            Assert.IsTrue(ans);
        }

        [TestMethod()]
        public void IsUserHasBotTest_UserIsAdmin()
        {
            BotsHandleService botsHandle = new BotsHandleService();

            UserData user = new UserData() { Id = 1, Login = ConfigurationManager.AppSettings["Login"], Password = ConfigurationManager.AppSettings["Password"] };
            UserBot bot = new UserBot() { Id = 2 };

            bool ans = botsHandle.IsUserHasBot(bot, user);

            Assert.IsTrue(ans);
        }

        [TestMethod()]
        public void IsUserHasBotTest_UserHasNot()
        {
            BotsHandleService botsHandle = new BotsHandleService();

            UserData user = new UserData() { Id = 3 };
            UserBot bot = new UserBot() { Id = 3 };

            bool ans = botsHandle.IsUserHasBot(bot, user);

            Assert.IsFalse(ans);
        }

        [TestMethod()]
        public void StartBotTest()
        {
            BotsHandleService botsHandle = new BotsHandleService();

            BotServiceController ctr = new BotServiceController();

            TotalRequest req = new TotalRequest();

            //req. = new UserBot { BasicBotName = BotNames.FaceBook, BotStatus = false };



            botsHandle.StartBots(ctr);

            Assert.Fail();
        }
    }
}