using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;
using Volvo_API.Repository;
using Volvo_API.Repository.Context;

namespace Volvo_API.Services
{
    public class TruckService : IService<Truck>
    {
        private readonly IRepository<Truck> repository;
        private readonly IService<TruckModel> truckModelService;
        public TruckService(IService<TruckModel> truckModelService, IRepository<Truck> repository)
        {
            this.truckModelService = truckModelService;
            this.repository = repository;
        }

        public IEnumerable<Truck> Get()
        {
            return repository.Get();
        }

        public Truck Get(long id)
        {
            var resp = repository.Get(id);
            if (resp == null)
                throw new InvalidOperationException("Not Found");
            return resp;
        }

        public Truck Post(Truck value)
        {
            value.FabricationYear = DateTime.Now.Year;
            if (value.ModelYear != DateTime.Now.Year && value.ModelYear != DateTime.Now.Year + 1)
                throw new InvalidOperationException("Invalid Model Year");

            object tModel = truckModelService.Get(value.TruckModelId);
            if (tModel == null || tModel.Equals("Not Found"))
                throw new InvalidOperationException("Invalid Model Id");

            var model = (TruckModel)tModel;
            string[] validModels = { "FM", "FH" };

            if (!validModels.Contains(model.Model))
                throw new InvalidOperationException("Invalid Model Type");

            return repository.Post(value);
        }

        public Truck Put(long id, Truck value)
        {
            if (id != value.Id)
                throw new InvalidOperationException("Query Id is different from Entity Id");

            return repository.Put(id, value);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
