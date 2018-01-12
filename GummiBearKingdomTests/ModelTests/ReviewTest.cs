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
    }
}
