using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;
using Volvo_API.Repository.Context;

namespace Volvo_API.Repository
{
    public class TruckRepository : IRepository<Truck>
    {
        private readonly DatabaseContext context;

        public TruckRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Delete(long id)
        {
            var resp = context.Trucks.Where(e => e.Id == id).FirstOrDefault();
            if (resp != null)
            {
                context.Remove(resp);
                context.SaveChanges();
            }
        }

        public IEnumerable<Truck> Get()
        {
            var query = from truck in context.Trucks
                        join truckModel in context.TruckModels on truck.TruckModelId equals truckModel.Id
                        select new Truck
                        {
                            Id = truck.Id,
                            FabricationYear = truck.FabricationYear,
                            TruckModelId = truck.TruckModelId,
                            ModelYear = truck.ModelYear,
                            SerialNumber = truck.SerialNumber,
                            TruckModel = truckModel
                        };
            return query;
        }

        public Truck Get(long id)
        {
            return Get().Where(t => t.Id == id).FirstOrDefault();
        }

        public Truck Post(Truck value)
        {
            var resp = context.Trucks.Add(value);
            context.SaveChanges();

            if (resp != null)
                return resp.Entity;
            return null;
        }

        public Truck Put(long id, Truck value)
        {
            value.TruckModel = null;
            var resp = context.Trucks.Update(value);
            context.SaveChanges();
            return resp.Entity;
        }
    }
}
