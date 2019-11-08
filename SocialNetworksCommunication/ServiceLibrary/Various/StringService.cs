using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Various
{
    public static class StringService
    {
        /// <summary>
        /// Removes symbols from string
        /// </summary>
        /// <param name="symbolToDelete">Symbols that removed</param>
        /// <param name="primaryString">Primary string to parse</param>
        /// <returns>String without signed symbols</returns>
        public static string RemoveSymbols(char[] symbolToDelete, string primaryString)
        {
            try
            {
                string returnString = null;
                foreach(char c in primaryString)
                {
                    if (!symbolToDelete.Contains(c))
                        returnString += c;
                }

                return returnString;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Cenverts byte array to string
        /// </summary>
        /// <param name="byteArray">Array to convert</param>
        /// <param name="spaceParam">Symbol between shars</param>
        /// <returns>Converted string</returns>
        public static string ConvertBytesToString(byte[] byteArray, string spaceParam="")
        {
            try
            {
                string retString = string.Empty;

                foreach(byte b in byteArray)
                {
                    retString += $"{b.ToString()}{spaceParam}";
                }

                return retString;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
