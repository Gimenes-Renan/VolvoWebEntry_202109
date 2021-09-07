using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;
using Volvo_API.Repository.Context;

namespace Volvo_API.Repository
{
    public class TruckModelRepository : IRepository<TruckModel>
    {
        private readonly DatabaseContext context;

        public TruckModelRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Delete(long id)
        {
            //var resp = context.TruckModels.Where(e => e.Id == id).FirstOrDefault();
            //if (resp != null)
            //{
            //    context.Remove(resp);
            //    context.SaveChanges();
            //}

            //Method intentionally left empty
            throw new NotImplementedException();
        }

        public IEnumerable<TruckModel> Get()
        {
            return context.TruckModels;
        }

        public TruckModel Get(long id)
        {
            return Get().Where(t => t.Id == id).FirstOrDefault();
        }

        public TruckModel Post(TruckModel value)
        {
            //var resp = context.TruckModels.Add(value);
            //context.SaveChanges();

            //if (resp != null)
            //    return resp.Entity;
            //return null;

            //Method intentionally left empty
            throw new NotImplementedException();
        }

        public TruckModel Put(long id, TruckModel value)
        {
            //var resp = context.TruckModels.Update(value);
            //context.SaveChanges();
            //return resp.Entity;

            //Method intentionally left empty
            throw new NotImplementedException();
        }
    }
}
