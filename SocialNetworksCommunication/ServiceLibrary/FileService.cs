using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServiceLibrary
{
    public class FileService
    {
        /// <summary>
        /// Logs the data to some file
        /// </summary>
        /// <param name="pathToLog">Path to log file</param>
        /// <param name="dataToLog">Data to log</param>
        public void LogData(string pathToLog, string dataToLog)
        {
            try
            {
                using (StreamWriter fs = File.AppendText(pathToLog))
                {
                    fs.WriteLine(dataToLog);
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Return all text in the file lika string property
        /// </summary>
        /// <param name="pathToFile">Path to the file</param>
        /// <returns>Return all text in the file lika string property</returns>
        public string ReadFileToString(string pathToFile)
        {
            string returnString = string.Empty;
            try
            {
                returnString = File.ReadAllText(pathToFile);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnString;
        }



    }
}
