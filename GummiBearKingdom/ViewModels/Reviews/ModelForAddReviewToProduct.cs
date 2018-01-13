using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.ViewModels.Reviews
{
    public class ModelForAddReviewToProduct
    {
        public Product CurrentProduct { get; } = new Product();
        public Review NewReview { get; set; } = new Review();

        public ModelForAddReviewToProduct() {}

        public ModelForAddReviewToProduct(Product currentProduct)
        {
            CurrentProduct = currentProduct;
        }
    }
}
