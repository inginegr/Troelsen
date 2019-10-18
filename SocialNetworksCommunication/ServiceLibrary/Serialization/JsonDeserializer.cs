using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


namespace ServiceLibrary.Serialization
{
    public class JsonDeserializer
    {
        /// <summary>
        /// Deserialize object T
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <param name="jsonString">String in json format</param>
        /// <param name="pathParam">Path to deserialized object in the total string</param>
        /// <returns>Deserialized objects</returns>
        public IList<T> DeserializeToList<T>(string jsonString, string[] pathParam)
        {            
            try
            {


                JObject JoToParse = JObject.Parse(@jsonString);
                
                JToken jtk = JoToParse[pathParam[0]];

                for(int i=1; i<pathParam.Length;i++)
                {
                    jtk = jtk[pathParam[i]];
                }

                IList<JToken> results = jtk.Children().ToList();

                // serialize JSON results into .NET objects
                IList<T> searchResults = new List<T>();

                foreach (JToken result in results)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    T searchResult = result.ToObject<T>();
                    searchResults.Add(searchResult);
                }

                return searchResults;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public T DeserializeToObject<T>(string jsonString)
        //{
        //    try
        //    {


        //        JObject JoToParse = JObject.Parse(@jsonString);
                
        //        return JoToParse.Children().

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
