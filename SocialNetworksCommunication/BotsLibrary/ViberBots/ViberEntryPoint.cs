using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ViberBots
{
    public class ViberEntryPoint
    {
        /// <summary>
        /// Name space, that contain all viber bots
        /// </summary>
        private string NameSpace { get => nameof(ViberBots); }

        /// <summary>
        /// Basic bot name, that contained in all bots
        /// </summary>
        private string BaseBotName { get => "ViberBot"; }

        /// <summary>
        /// Call 
        /// </summary>
        /// <param name="botNumber">Number of bot, that created</param>
        /// <param name="jsonString">String, send by viber server</param>
        public void CallFunctions(int botNumber, string jsonString)
        {
            try
            {
                Type obj = Type.GetType($"{NameSpace}.{BaseBotName}{botNumber}");
                MethodInfo mi = obj.GetMethod("ViberStartPoint");
                mi.Invoke(null, new object[] { jsonString });
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}