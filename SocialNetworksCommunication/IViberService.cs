
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SocialNetworks.Viber.Objects;


namespace SocialNetworksServiceLibrary.Viber
{
    [ServiceContract]
    public interface IViberService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = @"/Update")]
        void GetData(ViberCallBackData callBackData);
    }
}