using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLibrary
{
    public class CommonService
    {
        /// <summary>
        /// Convert massive to string
        /// </summary>
        /// <typeparam name="T"> type of massive</typeparam>
        /// <param name="massiveToString">Massive to convert to the string</param>
        /// <returns> String of massive</returns>
        public string MassivToString<T>(T[] massiveToString)
        {
            string retString = String.Empty;

            for (int i = 0; i < massiveToString?.Length; i++)
            {
                retString += massiveToString[i].ToString();
            }

            return retString;
        }

        /// <summary>
        /// Convert massive to string with some string separator
        /// </summary>
        /// <typeparam name="T"> type of massive</typeparam>
        /// <param name="massiveToString">Massive to convert to the string</param>
        /// <param name="separatorParam">symbol, thart inserted between signs</param>
        /// <returns> String of massive</returns>
        public string MassivToString<T>(T[] massiveToString, string separatorParam)
        {
            string retString = String.Empty;

            for (int i = 0; i < massiveToString?.Length; i++)
            {
                retString += massiveToString[i].ToString() + separatorParam;
            }

            return retString;
        }

        /// <summary>
        /// Convert string massive to massive of some type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringToConvert">String, that must to be converted</param>
        /// <param name="separatorString">Separator, that between string's elements </param>
        /// <param name="typeToConvert">Source type </param>
        /// <returns>List of converted elements</returns>
        public IEnumerable<T> StringToMassive<T>(string stringToConvert, string separatorString, Type t)
        {
            List<T> returmList = new List<T>();

            try
            {
                string[] massiveStringToHandle = stringToConvert.Split(separatorString.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                for (int i=0; i < massiveStringToHandle.Length; i++)
                {
                    returmList.Add((T)Convert.ChangeType(massiveStringToHandle[i], t));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returmList;
        }
    }
}
