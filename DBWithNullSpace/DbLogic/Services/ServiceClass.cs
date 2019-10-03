using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DbLogic.Services
{
    public class ServiceClass
    {
        public void LogMessage(string messageParam, TextBox textboxParam)
        {
            if (textboxParam == null)
                textboxParam.Text = messageParam;
        }
    }
}
