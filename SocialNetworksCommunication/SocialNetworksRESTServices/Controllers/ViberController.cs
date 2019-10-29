using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Objects;
using ServiceLibrary.Various;
using ServiceLibrary.Serialization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace SocialNetworksRESTServices.Controllers
{
    public class ViberController : ApiController
    {
        JsonDeserializer jsd = new JsonDeserializer();
        FileService fs = new FileService();

        // GET api/values
        public string Get()
        {
            fs.LogData(@"C:\Users\Dima\Desktop\log.txt", "GET");
            return "500";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "500";
        }

        // POST api/values
        public void ProcessPost(object ob)
        {
            try
            {
                ViberEventType vet = jsd.DeserializeToObjectT<ViberEventType>(ob.ToString());

                switch (vet.Event.ToString())
                {
                    case "webhook":
                        {
                            break;
                        }
                    case "message":
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }


            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
