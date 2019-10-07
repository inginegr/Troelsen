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
    }
}
