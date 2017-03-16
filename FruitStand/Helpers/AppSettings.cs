using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FruitStand.Helpers
{
    public class AppSettings
    {
        public static string Origin
        {
            get
            {
                return ConfigurationSettings.AppSettings.Get("Origin");
            }
        }

        public static string JsonFilePath
        {
            get
            {
                return ConfigurationSettings.AppSettings.Get("JsonFilePath");
            }
        }
    }
}