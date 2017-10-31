using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
  public  class MemoryRepository<T> : IRepository<T> where T : IStoreable
    {
        private List<T> store;

        public MemoryRepository()
        {
            store = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return store;
        }

        public void Delete(IComparable id)
        {
            store.RemoveAll(StoreIdMatch(id));
        }

        public void Save(T item)
        {
            store.RemoveAll(StoreIdMatch(item.Id));
            store.Add(item);
        }

        public T FindById(IComparable id)
        {
            return store.Find(StoreIdMatch(id));
        }

        private static Predicate<T> StoreIdMatch(IComparable id)
        {
            return i => i.Id.Equals(id);
        }
    }
}
