using System.Collections.Generic;
using System.Linq;
using BookShop.Interface;

namespace BookShop.Data
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> storage = new List<T>();
        private int currentId = 1;

        public void Add(T item)
        {
            var prop = item.GetType().GetProperty("Id");
            if (prop != null)
                prop.SetValue(item, currentId++);

            storage.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
                storage.Remove(item);
        }

        public T Get(int id)
        {
            return storage.FirstOrDefault(x =>
            {
                var prop = x.GetType().GetProperty("Id");
                return prop != null && (int)prop.GetValue(x) == id;
            });
        }

        public IEnumerable<T> GetAll()
        {
            return storage;
        }
    }
}
