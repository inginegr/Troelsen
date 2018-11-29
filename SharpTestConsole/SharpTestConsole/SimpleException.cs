using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.EntityClient;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;


namespace MagicEightBallServiceLib
{
    [ServiceContract]
    public interface IEightBall
    {
        [OperationContract]
        string ObtainAnswerToQwestion(string userQuestion);
    }

    public class MagicEightBallService : IEightBall
    {
        public MagicEightBallService()
        {
            Console.WriteLine("The 8-ball awaits your question...");
        }
        public string ObtainAnswerToQwestion(string userQuestion)
        {
            string[] answers = { "Future Uncertain", "Yes", "No", "Hazy", "Ask again later", "Definitely" };
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}