using System.Configuration;

namespace FruitStand.Data.Helpers
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
