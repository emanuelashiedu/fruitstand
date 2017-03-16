using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FruitStand.Helpers
{
    public class JsonUtil
    {
        public T Read<T>(string filePath)
        {
            T data;
            using (StreamReader r = new StreamReader(filePath))
            {
                data = JsonConvert.DeserializeObject<T>(r.ReadToEnd());
            }

            return data;
        }

        public T ReadFromString<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public void Write(string filePath, object data)
        {
            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}