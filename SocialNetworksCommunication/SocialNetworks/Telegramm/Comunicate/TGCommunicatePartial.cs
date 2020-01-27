using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworks.Services;
using ServiceLibrary.Serialization;
using SocialNetworks.Telegramm.Objects;
using ServiceLibrary.Various;


namespace SocialNetworks.Telegramm
{
    /// <summary>
    /// Properties and constants
    /// </summary>
    public partial class TgCommunicate
    {
        /*----------------------------- Commands in request string--------------------------*/
        private string SendMessageCommand { get => "sendMessage"; }
        private string SetWebHookCommand { get => "setWebHook"; }
        private string GetMeCommand { get => "getMe"; }
        private string ForwardMessageCommand { get => "forwardMessage"; }
        private string SendPhotoCommand { get => "sendPhoto"; }
        private string SendAudioCommand { get => "sendAudio"; }
        private string SendDocumentCommand { get => "sendDocument"; }
        private string SendVideoCommand { get => "sendVideo"; }
        private string SendAnimationCommand { get => "sendAnimation"; }
        private string SendVoiceCommand { get => "sendVoice"; }



        /*------------------------------------------------------------------------------------*/
        
        //Deserializator of json string
        private JsonDeserializer jso = new JsonDeserializer();
               
        //Crypto service to operate by secret key
        KeysTGHandle keysHandle = null;

        //To send commands using interent
        InternetService inetService = new InternetService();

        // Secret key to communicate with telegram server
        private string Token { get => keysHandle.GetSecretKey(); }

        //Base string to communicate with bot
        private string BaseQeruestString = "https://api.telegram.org/bot";
    }
}
