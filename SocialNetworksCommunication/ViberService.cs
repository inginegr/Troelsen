using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Objects;
using ServiceLibrary.Various;


namespace SocialNetworksServiceLibrary.Viber
{
    public class ViberService : IViberService
    {
        public void GetData(ViberCallBackData callBackData)
        {
            FileService fs = new FileService();

            fs.LogData("serviceLog.txt", callBackData.ToString());            
        }
    }
}
