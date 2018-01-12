using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GummiBearKingdom.Models;

namespace GummiBearKingdomTests.ModelTests
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void Equals_HaveSameId_True()
        {
            Review review1 = new Review { Id = 1 };
            Review review2 = new Review { Id = 1 };

            bool result = review1.Equals(review2);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Equals_HaveDifferentId_False()
        {
            Review review1 = new Review { Id = 1 };
            Review review2 = new Review { Id = 2 };

            bool result = review1.Equals(review2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetRating_RatingLessThan1_1()
        {
            Review testReview = new Review { Rating = -1 };

            Assert.AreEqual(1, testReview.Rating);
        }

        [TestMethod]
        public void SetRating_RatingGreaterThan5_10()
        {
            Review testReview = new Review { Rating = 10 };

            Assert.AreEqual(5, testReview.Rating);
        }
    }
}
