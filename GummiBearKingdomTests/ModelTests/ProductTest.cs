using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void GetCostAsUSD_ConvertsCostToUSDString_String()
        {
            Product product = new Product { Cost = 3.75m };
            string expected = "$3.75";

            string result = product.GetCostAsUSD();

            Assert.AreEqual(expected, result);
        }
    }
}
