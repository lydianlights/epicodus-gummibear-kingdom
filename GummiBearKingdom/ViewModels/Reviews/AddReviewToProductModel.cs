using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.ViewModels
{
    public class AddReviewToProductModel
    {
        public Product CurrentProduct { get; }
        public Review NewReview { get; set; } = null;

        public AddReviewToProductModel(Product currentProduct)
        {
            CurrentProduct = currentProduct;
        }
    }
}
