using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview;
namespace RepositoryTest
{
    [TestClass]
    public class Tests
    {
        private StoreableItem initialItem;
        private StoreableItem anotherItem;
        private StoreableItem itemToBeDeleted;
        private MemoryRepository<StoreableItem> repository;
        private object result;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new MemoryRepository<StoreableItem>();
        }

        [TestMethod]
        public void ShouldGetAllItems()
        {
            initialItem = new StoreableItem { Id = 1, Name = "initialFirstItem" };
            repository.Save(initialItem);
            initialItem = new StoreableItem { Id = 2, Name = "initialSecondItem" };
            repository.Save(initialItem);
            var items =  repository.All();
            Assert.AreEqual(items.Count(), 2);
        }

        [TestMethod]
        public void ShouldSaveItem()
        {
            initialItem = new StoreableItem { Id = 1, Name = "initialItem" };
            repository.Save(initialItem);
            result = repository.All();
            Assert.IsTrue(((IEnumerable<StoreableItem>)result).Contains(initialItem));
        }

        [TestMethod]
        public void ShoulFindSavedItem()
        {
            anotherItem = new StoreableItem { Id = 2, Name = "newItem" };
            repository.Save(anotherItem);
            result = repository.FindById(2);
            Assert.AreEqual(result, anotherItem);
        }

        [TestMethod]
        public void ShoulDeleteSavedItem()
        {
            itemToBeDeleted = new StoreableItem { Id = 3, Name = "deleteItem" };
            repository.Save(itemToBeDeleted);
            repository.Delete(3);
            result = repository.All();
            Assert.IsFalse(((IEnumerable<StoreableItem>)result).Contains(itemToBeDeleted));
        }
    }
}
