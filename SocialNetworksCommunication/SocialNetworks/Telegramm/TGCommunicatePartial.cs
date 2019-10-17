using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworks.Services;
using ServiceLibrary.Serialization;
using SocialNetworks.TGObjects;
using ServiceLibrary.Various;

namespace SocialNetworks.Telegramm
{
    /// <summary>
    /// Properties and constants
    /// </summary>
    public partial class TGCommunicate
    {
        //Time handling
        private TimeHandling timeHandling = new TimeHandling();

        //Deserializator of json string
        private JsonDeserializer jso = new JsonDeserializer();

        // Timeout between requests
        private int timeOut = 120;

        // Current offset
        private int currentOffset = 0;

        //Limit of updates
        private int lim = 100;

        private int updatesLimit
        {
            get => lim;
            set
            {
                if (value > 100)
                {
                    lim = 100;
                }
                else if (value < 0)
                {
                    lim = 0;
                }
                else
                {
                    lim = value;
                }
            }
        }

        //Crypto service to operate by secret key
        KeysTGHandle keysHandle = null;

        //To send commands using interent
        InternetService inetService = new InternetService();

        // Secret key to communicate with telegram server
        private string Token { get => keysHandle.GetSecretKey(); }

        //Base string to communicate with bot
        private string BaseQeruestString = "https://api.telegram.org/bot";

        //Lock Between getting of updates
        private object lockIsNextGetUpdatesEnabled = new object();

        //Lock to take queueUnhandledMessages
        private object lockToOperateunhandledMessages = new object();

        // Lock IsGetUpdatesStarted getting and setting
        private object lockIsGetUpdatesStarted = new object();

        //Is enabled to call next iterration inside of getUpdates function
        private bool IsNextGetUpdatesEnabled = false;

        private bool HandleIsNextUpdateEnabled
        {
            get
            {
                lock (lockIsNextGetUpdatesEnabled)
                {
                    return IsNextGetUpdatesEnabled;
                }
            }

            set
            {
                lock (lockIsNextGetUpdatesEnabled)
                {
                    IsNextGetUpdatesEnabled = value;
                }
            }
        }
        
        // The queue of unhandled messages from bot
        private Queue<TGUpdate> queueUnhandledMessages = new Queue<TGUpdate>();

        public Queue<TGUpdate> HandleQueueMessages
        {
            get
            {
                lock (lockToOperateunhandledMessages)
                {
                    return queueUnhandledMessages;
                }
            }

            set
            {
                lock (lockToOperateunhandledMessages)
                {
                    queueUnhandledMessages = value;
                }
            }
        }

        // Current state of getting updates
        private bool IsGetUpdatesStarted = false;

        private bool HandleIsGetUpdatesStarted
        {
            get
            {
                lock (lockIsGetUpdatesStarted)
                {
                    return IsGetUpdatesStarted;
                }
            }

            set
            {
                lock (lockIsGetUpdatesStarted)
                {
                    IsGetUpdatesStarted = value;
                }
            }
        }

    }
}
