using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;

namespace ServiceLibrary.Serialization
{
    public class JsonSerializer
    {

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
    }
}
