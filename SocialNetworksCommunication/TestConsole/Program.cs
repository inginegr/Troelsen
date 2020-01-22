using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Telegramm.Objects;
using SocialNetworks.Telegramm;
using ServiceLibrary.Serialization;


namespace TestConsole
{
    class Program
    {
        static TgCommunicate tg = new TgCommunicate();
        static JsonSerializer serializer = new JsonSerializer();
        static JsonDeserializer deserializer = new JsonDeserializer();

        static void Main(string[] args)
        {

            TgReplyKeyboardMarkup tgMessage = new TgReplyKeyboardMarkup() { parse_mode = "MarkdownV2", chat_id = "Dsf" };

            tgMessage.text = $"Hello *sa*\n What do you want?";

            tgMessage.reply_markup.keyboard = new KeyboardButton[2][];
            tgMessage.reply_markup.keyboard[0] = new KeyboardButton[1] { new KeyboardButton { text = "dsfsdf" } };
            tgMessage.reply_markup.keyboard[1] = new KeyboardButton[1] { new KeyboardButton { text = "dfsdf" } };



            string req = serializer.SerializeObjectT(tgMessage);

            Console.WriteLine(req);

            Console.ReadLine();

        }
    }
}
