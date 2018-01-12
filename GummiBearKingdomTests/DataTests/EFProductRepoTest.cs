using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GummiBearKingdom.Data;
using GummiBearKingdom.Models;

namespace GummiBearKingdomTests.DataTests
{
    [TestClass]
    public class EFProductRepoTest : IDisposable
    {
        EFProductRepo testProductRepo = new EFProductRepo(new TestGummiBearKingdomContext());

        private void LoadTestData()
        {
            Dispose();
            foreach(Product product in TestData.Products.ToList())
            {
                testProductRepo.Save(product);
            }
        }

        public void Dispose()
        {
            testProductRepo.DeleteAll();
        }

        [TestMethod]
        public void DeleteAll_DbIsEmptyAtFirst_0()
        {
            List<Product> entries = testProductRepo.Data.ToList();

            int result = entries.Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesAllTestData_DataSaved()
        {
            LoadTestData();
            Product[] testData = TestData.Products;

            List<Product> dbData = testProductRepo.Data.ToList();

            CollectionAssert.AreEqual(testData, dbData);
        }

        // TODO: This test passes even if the Update method doen't call SaveChanges(), probably due to how EF tracks objects
        [TestMethod]
        public void Update_UpdatesTestDataEntry_EntryUpdated()
        {
            LoadTestData();
            string newName = "FakeTestName";
            Product modifiedProduct = TestData.Products[0];
            modifiedProduct.Name = newName;

            testProductRepo.Update(modifiedProduct);
            Product resultProduct = testProductRepo.Data.FirstOrDefault(product => product.Id == modifiedProduct.Id);

            Assert.AreEqual(newName, resultProduct.Name);
        }

        [TestMethod]
        public void Delete_DeletesATestDataEntry_EntryDeleted()
        {
            LoadTestData();
            Product deletedProduct = TestData.Products[0];

            testProductRepo.Delete(deletedProduct);
            Product resultProduct = testProductRepo.Data.FirstOrDefault(product => product.Id == deletedProduct.Id);

            Assert.IsNull(resultProduct);
        }
    }
}
