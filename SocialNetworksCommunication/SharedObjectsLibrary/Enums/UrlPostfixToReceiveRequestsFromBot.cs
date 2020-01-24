using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjectsLibrary
{
    public class UrlPostfixToReceiveRequestsFromBot
    {
        private const string common = "/botanswer/";
        public const string TgPostfix = "/telegram" + common;
        public const string ViberPostfix = "/viber" + common;
        public const string VkPostfix = "/vk" + common;
        public string FbPostfix = "/facebook" + common;
    }
}
