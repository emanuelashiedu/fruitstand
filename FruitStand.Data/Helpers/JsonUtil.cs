using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using FruitStand.Data.Models;
using System;
using System.Text;

namespace FruitStand.Data.Helpers
{
    public class JsonUtil
    {
        public object Read(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                //data = JsonConvert.DeserializeObject<T>(r.ReadToEnd());
                string json = r.ReadToEnd();
                return json;
            }

        }

       
        public List<FruitStandModel> ReadFruits(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<FruitStandModel>>(json);
                return data;
            }

        }

        public T ReadFromString<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public void Write(string filePath, object data)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }

}
