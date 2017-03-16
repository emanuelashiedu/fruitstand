using FruitStand.Data.Abstract;
using FruitStand.Data.Models;
using FruitStand.Services.Abstract;
using System.Collections.Generic;

namespace FruitStand.Services.Concrete
{
    public class Service: IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public void Save(FruitStandModel obj)
        {
            _repository.Save(obj);
        }

        public FruitStandModel Get(int id)
        {
            return _repository.Get(id);

        }

        public List<FruitStandModel> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
