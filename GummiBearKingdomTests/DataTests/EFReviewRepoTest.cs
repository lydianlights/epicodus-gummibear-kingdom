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
    public class EFReviewRepoTest : IDisposable
    {
        EFProductRepo testProductRepo = new EFProductRepo(new TestGummiBearKingdomContext());
        EFReviewRepo testReviewRepo = new EFReviewRepo(new TestGummiBearKingdomContext());

        private void LoadTestData()
        {
            Dispose();
            foreach (Product product in TestData.Products.ToList())
            {
                testProductRepo.Save(product);
            }
            foreach (Review review in TestData.Reviews.ToList())
            {
                testReviewRepo.Save(review);
            }
        }

        public void Dispose()
        {
            testProductRepo.DeleteAll();
            testReviewRepo.DeleteAll();
        }

        [TestMethod]
        public void Dispose_DbIsEmptyAtFirst_0Entries()
        {
            List<Review> entries = testReviewRepo.Data.ToList();

            int result = entries.Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesAllTestData_DataSaved()
        {
            LoadTestData();
            Review[] testData = TestData.Reviews;

            List<Review> dbData = testReviewRepo.Data.ToList();

            CollectionAssert.AreEqual(testData, dbData);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllTestData_DataDeleted()
        {
            LoadTestData();

            testReviewRepo.DeleteAll();
            List<Review> resultData = testReviewRepo.Data.ToList();
            int result = resultData.Count;

            Assert.AreEqual(0, result);
        }

        // TODO: This test passes even if the Update method doen't call SaveChanges(), probably due to how EF tracks objects
        [TestMethod]
        public void Update_UpdatesTestDataEntry_EntryUpdated()
        {
            LoadTestData();
            string newContent = "FakeTestContent";
            Review modifiedReview = TestData.Reviews[0];
            modifiedReview.ContentBody = newContent;

            testReviewRepo.Update(modifiedReview);
            Review resultReview = testReviewRepo.Data.FirstOrDefault(review => review.Id == modifiedReview.Id);

            Assert.AreEqual(newContent, resultReview.ContentBody);
        }

        [TestMethod]
        public void Delete_DeletesATestDataEntry_EntryDeleted()
        {
            LoadTestData();
            Review deletedReview = TestData.Reviews[0];

            testReviewRepo.Delete(deletedReview);
            Review resultReview = testReviewRepo.Data.FirstOrDefault(review => review.Id == deletedReview.Id);

            Assert.IsNull(resultReview);
        }
    }
}
