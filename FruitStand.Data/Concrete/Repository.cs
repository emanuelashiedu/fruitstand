using FruitStand.Data.Abstract;
using FruitStand.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FruitStand.Data.Concrete
{
 
    public class Repository: IRepository
    {
        //private Dictionary<int, FruitStandModel> FruitStandInfo = new Dictionary<int, FruitStandModel>();

        public void Save(FruitStandModel obj)
        {
            //FruitStandInfo.Add(obj.Id, obj);
            var oJsonUtil = new Helpers.JsonUtil();
            var fruits = GetAll();
            fruits.Add(obj);
            oJsonUtil.Write(Helpers.AppSettings.JsonFilePath, fruits);
        }

        public FruitStandModel Get(int id)
        {
            //if (FruitStandInfo.TryGetValue(id, out FruitStandModel fruit))
            //    return fruit;
            return null;

        }

        public List<FruitStandModel> GetAll()
        {
            //var fruits = FruitStandInfo.Values.ToList();
            //return fruits;
            var oJsonUtil = new Helpers.JsonUtil();
            var result = oJsonUtil.Read(Helpers.AppSettings.JsonFilePath);
            var json = JsonConvert.DeserializeObject<List<FruitStandModel>>(result.ToString());
            if (json != null)
                return json;
            else
            {
                var items = new List<FruitStandModel>();
                return items;
            }
        }

        public void Delete(int id)
        {
            //FruitStandInfo.Remove(id);
        }

    }
}
