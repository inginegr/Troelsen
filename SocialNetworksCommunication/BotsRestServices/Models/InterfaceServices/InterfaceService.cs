using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ServiceLibrary.Security;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;
using BotsRestServices.Models.Objects.AnswersFromServer;
using System.Configuration;
using BotsRestServices.Models.UserServices;
using BotsRestServices.Models.DataBase.Infrastructure;


namespace BotsRestServices.Models.InterfaceServices
{
    /// <summary>
    /// Manage user actions
    /// </summary>
    public class InterfaceService
    {

        DbHandle dbHandle = new DbHandle();

        UserService us = new UserService();
        // Cryptography functions
        SLCryptography _crypto = new SLCryptography();

        JsonSerializer js = new JsonSerializer();

        JsonDeserializer jsd = new JsonDeserializer();

        string login = string.Empty;

        string password = string.Empty;

        // Key and iv size
        private int _keySize = 16;


        public void SendDataToStartPage(Controller ctr)
        {
            byte[] k = _crypto.GenerateRandom(_keySize);
            byte[] i = _crypto.GenerateRandom(_keySize);

            ctr.ViewData["key"] = StringService.ConvertBytesToString(k, "_");
            ctr.ViewData["iv"] = StringService.ConvertBytesToString(k, "_");
            ctr.ViewData["isauthorized"] = false;
        }

    }
}