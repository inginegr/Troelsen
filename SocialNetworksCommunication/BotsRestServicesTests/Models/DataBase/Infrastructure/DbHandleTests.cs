using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotsRestServices.Models.DataBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedObjectsLibrary;
using BotsRestServices.Models.DataBase;
using BotsRestServices.Models.Objects.DbObjects;

namespace BotsRestServices.Models.DataBase.Infrastructure.Tests
{
    [TestClass()]
    public class DbHandleTests
    {
        [TestMethod()]
        public void FindRowUserTest_Exists()
        {
            DbHandle handle = new DbHandle();

            UserData user = new UserData { Id = 1 };
            UserData fuser = (UserData)handle.FindRow(user);

            Assert.IsNotNull(fuser);
        }

        [TestMethod()]
        public void FindRowUserTest_NotExists()
        {
            DbHandle handle = new DbHandle();

            UserData user = new UserData { Id = 11111 };
            UserData fuser = (UserData)handle.FindRow(user);

            Assert.IsNull(fuser);
        }

        [TestMethod()]
        public void FindRowBotTest_Exists()
        {
            DbHandle handle = new DbHandle();

            UserBot user = new UserBot { Id = 1 };
            UserBot fuser = (UserBot)handle.FindRow(user);

            Assert.IsNotNull(fuser);
        }

        [TestMethod()]
        public void FindRowBotTest_NotExists()
        {
            DbHandle handle = new DbHandle();

            UserBot user = new UserBot { Id = 11111 };
            UserBot fuser = (UserBot)handle.FindRow(user);

            Assert.IsNull(fuser);
        }

        [TestMethod()]
        public void FindRowBotObjectTest_Exists()
        {
            DbHandle handle = new DbHandle();

            BotObject user = new BotObject { Id = 1 };
            BotObject fuser = (BotObject)handle.FindRow(user);

            Assert.IsNotNull(fuser);
        }

        [TestMethod()]
        public void FindRowBotObjectTest_NotExists()
        {
            DbHandle handle = new DbHandle();

            BotObject user = new BotObject { Id = 11111 };
            BotObject fuser = (BotObject)handle.FindRow(user);

            Assert.IsNull(fuser);
        }

        [TestMethod()]
        public void EditRowsTest_User()
        {
            UserData user = new UserData() { Id = 3, Login = "Go", Password = "Hard" };
            List<UserData> users = new List<UserData>();
            users.Add(user);

            DbHandle db = new DbHandle();

            db.EditRows(users);

            UserData editedUser = (UserData)db.FindRow(user);

            Assert.IsTrue(editedUser.Login == "Go" && editedUser.Password == "Hard");
        }

        [TestMethod()]
        public void EditRowsTest_Bot()
        {
            UserBot bot = new UserBot() { Id = 1, FriendlyBotName = "NewName", BotStatus = true };
            List<UserBot> bots = new List<UserBot>();
            bots.Add(bot);

            DbHandle db = new DbHandle();

            db.EditRows(bots);

            UserBot editedBot = (UserBot)db.FindRow(bot);

            Assert.IsTrue(editedBot.FriendlyBotName == "NewName" && editedBot.BotStatus == true);
        }

        [TestMethod()]
        public void EditRowsTest_BotObject()
        {
            BotObject obj = new BotObject() { Id = 1, PathToObject = "New path" };
            List<BotObject> objs = new List<BotObject>();
            objs.Add(obj);

            DbHandle db = new DbHandle();

            db.EditRows(objs);

            BotObject editedBot = (BotObject)db.FindRow(obj);

            Assert.IsTrue(editedBot.PathToObject == "New path");
        }

        [TestMethod()]
        public void FindRowsTest()
        {
            BotObject obj1 = new BotObject() { Id = 1, PathToObject = "dsfdsf" };
            BotObject obj2 = new BotObject() { Id = 2, PathToObject = "aaaa" };
            List<BotObject> objs = new List<BotObject>();
            objs.Add(obj1);
            objs.Add(obj2);

            DbHandle db = new DbHandle();

            object newObjs = db.FindRows(objs);
                        
            //Assert.IsTrue(newObjs.Exists(el=>el.PathToObject==obj1.PathToObject));
        }
    }
}