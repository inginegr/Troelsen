using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;


namespace ServiceLibrary.Various
{
    public class TimeService
    {
        //Timer object
        private Timer localTimer = new Timer();

        /// <summary>
        /// Start time measure
        /// </summary>
        public void StartMeasureTH()
        {
            try
            {
                localTimer.Start();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Stop time measurement
        /// </summary>
        private void stopMeasure()
        {
            try
            {
                localTimer.Stop();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Gets time in seconds
        /// </summary>
        /// <returns>Number of seconds</returns>
        public int GetTimeInSeconds()
        {
            try
            {
                stopMeasure();

                return (int)(localTimer.Interval / 1000);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets current time
        /// </summary>
        /// <returns></returns>
        public string GetCurrentTime()
        {
            try
            {
                return DateTime.Now.ToString("h:mm:ss tt");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
