using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworks.TelegrammObjectsdfdf
{
    public class TGUpdate
    {
        public string Update_id { get; set; }
        
        public TGMessage Message { get; set; }

        public override string ToString()
        {
            return $"update_id -> {Update_id}  \n\r Message -> {Message.ToString()}";
        }
    }

    public class TGMessage
    {
        public string Message_id { get; set; }

        public TGFrom From { get; set; }

        public TGChat Chat { get; set; }

        public string Date { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"message_id -> {Message_id}; date -> {Date};  text -> {Text} \n\r From -> {From.ToString()}  \n\r  Chat -> {Chat.ToString()}";
        }
    }

    public class TGFrom
    {
        public string Id { get; set; }
        public string Is_bot { get; set; }
        public string First_name { get; set; }
        public string Language_code { get; set; }

        public override string ToString()
        {
            return $"id -> {Id};  is_bot -> {Is_bot};  first_name -> {First_name};  language_code -> {Language_code} \n\r";
        }
    }

    public class TGChat
    {
        public string Id { get; set; }
        public string First_name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"id -> {Id};  first_name -> {First_name};  type -> {Type}; \n\r";
        }
    }

    public class TGAnswerToRequest
    {
        public TGAnswerContent Result { get; set; }

        public override string ToString()
        {
            return $"Result -> {Result.ToString()} \n\r";
        }
    }

    public class TGAnswerContent
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return $"Text -> {Text} \n\r";
        }
    }
}
