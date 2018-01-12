using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GummiBearKingdom.Data;
using GummiBearKingdom.Models;

namespace GummiBearKingdomTests.ModelTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Equals_HaveSameId_True()
        {
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 1 };

            bool result = product1.Equals(product2);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Equals_HaveDifferentId_False()
        {
            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 2 };

            bool result = product1.Equals(product2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetCostAsUSD_CostIs2DigitDecimal_CostAsString()
        {
            Product product = new Product { Cost = 3.75m };
            string expected = "$3.75";

            string result = product.GetCostAsUSD();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAverageRating_Has1orMoreReviews_AverageOfRatings()
        {
            Review[] testReviews = {
                new Review {
                    Rating = 5
                },
                new Review {
                    Rating = 3
                },
                new Review {
                    Rating = 1
                },
            };
            Product testProduct = new Product {
                Reviews = testReviews
            };

            decimal result = testProduct.GetAverageRating();

            Assert.AreEqual(3.0m, result);
        }
        [TestMethod]
        public void GetAverageRating_HasNoReviews_0()
        {
            Product testProduct = new Product();

            decimal result = testProduct.GetAverageRating();

            Assert.AreEqual(0, result);
        }
    }
}
