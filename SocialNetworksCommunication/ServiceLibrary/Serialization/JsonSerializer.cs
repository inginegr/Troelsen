using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using System.Reflection;

namespace ServiceLibrary.Serialization
{
    class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            var propInfo = member as PropertyInfo;
            if (propInfo != null)
            {
                if (propInfo.GetMethod.IsVirtual && !propInfo.GetMethod.IsFinal)
                {
                    prop.ShouldSerialize = obj => false;
                }
            }
            return prop;
        }
    }

    public class JsonSerializer
    {
        // Serialize object without settings
        public string SerializeObjectT<T>(T objectToSerialize)
        {
            try
            {
                return JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Serialize object with settings
        public string SerializeObjectTWithVirtualProperty<T>(T objectToSerialize)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ContractResolver = new CustomResolver();
                settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.Formatting = Formatting.Indented;

                return JsonConvert.SerializeObject(objectToSerialize, settings);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
