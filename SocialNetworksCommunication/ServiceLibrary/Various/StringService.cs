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
    }
}
