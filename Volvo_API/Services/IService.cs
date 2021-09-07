using System.Collections.Generic;

namespace Volvo_API.Services
{
    public interface IService<T> where T : class
    {
        public IEnumerable<T> Get();

        public T Get(long id);

        public T Post(T value);

        public T Put(long id, T value);

        public void Delete(long id);
    }
}