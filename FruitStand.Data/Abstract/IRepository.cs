using FruitStand.Data.Models;
using System.Collections.Generic;


namespace FruitStand.Data.Abstract
{
    public interface IRepository
    {
        void Save(FruitStandModel obj);
        FruitStandModel Get(int id);
        List<FruitStandModel> GetAll();
        void Delete(int id);
    }
}
