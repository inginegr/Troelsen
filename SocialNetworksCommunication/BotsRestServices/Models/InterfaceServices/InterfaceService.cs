using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLibrary.Security;
using ServiceLibrary.Serialization;


namespace BotsRestServices.Models.InterfaceServices
{
    /// <summary>
    /// Manage user actions
    /// </summary>
    public class InterfaceService
    {
        // Cryptography functions
        SLCryptography _crypto = new SLCryptography();

        JsonSerializer js = new JsonSerializer();

        // Key and iv size
        private int _keySize=16;


        public void SendDataToStartPage(Controller ctr)
        {
            ctr.ViewData["key"] = js.SerializeObjectT<byte[]>(_crypto.GenerateRandom(_keySize));
            ctr.ViewData["iv"] = js.SerializeObjectT<byte[]>(_crypto.GenerateRandom(_keySize));
            ctr.ViewData["isauthorized"] = false;
        }

    }
}