using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;
using Volvo_API.Repository;
using Volvo_API.Repository.Context;

namespace Volvo_API.Services
{
    public class TruckModelService : IService<TruckModel>
    {
        private readonly IRepository<TruckModel> repository;
        public TruckModelService(IRepository<TruckModel> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TruckModel> Get()
        {
            return repository.Get();
        }

        public TruckModel Get(long id)
        {
            var resp = repository.Get(id);
            if (resp == null)
                throw new InvalidOperationException("Not Found");
            return resp;
        }

        public TruckModel Post(TruckModel value)
        {
            //Method intentionally left empty
            throw new NotImplementedException();
        }

        public TruckModel Put(long id, TruckModel value)
        {
            //Method intentionally left empty
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            //Method intentionally left empty
            throw new NotImplementedException();
        }
    }
}
