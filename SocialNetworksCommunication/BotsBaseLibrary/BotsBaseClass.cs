using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedObjectsLibrary;
using ServiceLibrary.Serialization;


namespace BotsBaseLibrary
{
    public class BotsBaseClass
    {
        protected JsonSerializer serializer = new JsonSerializer();
        protected JsonDeserializer deserializer = new JsonDeserializer();        

        protected virtual string TokenKey { get; set; }

        public BotsBaseClass()
        {

        }

        public BotsBaseClass(string token)
        {
            TokenKey = token;
        }
    }
}
