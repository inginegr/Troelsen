using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotsLibrary.ViberBots
{
    /// <summary>
    /// Test viber bot
    /// </summary>
    public class ViberBot1 : IViberBot
    {
        /// <summary>
        /// Start function of viber bot. When message come from viber server, this fuction called first of all
        /// </summary>
        /// <param name="jsonString">Json string from server</param>
        public void ViberBotsStartPoint(string jsonString)
        {
            try
            {

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
