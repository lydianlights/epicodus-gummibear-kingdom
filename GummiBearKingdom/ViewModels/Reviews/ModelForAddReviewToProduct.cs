using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.ViewModels
{
    public class ModelForAddReviewToProduct
    {
        public Product CurrentProduct { get; }
        public Review NewReview { get; set; } = null;

        public ModelForAddReviewToProduct(Product currentProduct)
        {
            CurrentProduct = currentProduct;
        }
    }
}
