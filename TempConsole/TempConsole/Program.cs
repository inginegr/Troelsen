using System;
using System.Reflection;
using System.Collections.Generic;
using SharedObjectsLibrary;
using SocialNetworks.Viber.Comunicate;
using SocialNetworks.Viber.Objects;

namespace onespace
{


    public class Example
    {
        public static void Main()
        {
            ViberComunicate viberComunicate = new ViberComunicate();

            viberComunicate.SetToken = "4a7c5ca68627d7fa-7c9131063c57af80-1c15e271750463a8";

            ViberSetWebHook setWebHook = new ViberSetWebHook()
            {
                url = "https://fbszk.icu/Viber/BotAnswer/1",
                event_types = new string[] { "delivered", "seen", "failed", "subscribed", "unsubscribed", "conversation_started" },
                send_name = true,
                send_photo = true
            };

            viberComunicate.SetWebHook(setWebHook);

            //Assembly asm = Assembly.LoadFrom("C:\\Users\\Dima\\Documents\\GitHub\\Troelsen\\TempConsole\\TempConsole\\libs\\ClassLibrary1.dll");

            //Type tp = asm.GetType("ClassLibrary1.Class1");

            //object obj = Activator.CreateInstance(tp);

            //tp.InvokeMember("cnsl", BindingFlags.InvokeMethod, null, obj, new object[] { new SharedObject { X = 3, St = "sss" } });

            Console.ReadLine();
        }
    }
}
