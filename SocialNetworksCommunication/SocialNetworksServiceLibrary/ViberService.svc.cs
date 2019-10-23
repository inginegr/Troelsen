using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Objects;
using ServiceLibrary.Various;

namespace SocialNetworksServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ViberService : IViberService
    {

        public string GetDataHook()
        {
            FileService fs = new FileService();

            return "dsfdsfdfsdfsdf";
            //fs.LogData("serviceLog.txt", callBackData.ToString());
        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }

        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }

        //    return composite;
        //}
    }
}