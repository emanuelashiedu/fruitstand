using FruitStand.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStand.Services.Abstract
{
    public interface IService
    {
        void Save(FruitStandModel obj);
        FruitStandModel Get(int id);
        List<FruitStandModel> GetAll();
        void Delete(int id);

    }
}
