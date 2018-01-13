using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Data;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Controllers
{
    public class ReviewsControllerSettings
    {
        public IDbRepo<Product> ProductRepo { get; }
        public IDbRepo<Review> ReviewRepo { get; }

        public ReviewsControllerSettings()
        {
            ProductRepo = new EFProductRepo();
            ReviewRepo = new EFReviewRepo();
        }

        public ReviewsControllerSettings(IDbRepo<Product> productRepo, IDbRepo<Review> reviewRepo)
        {
            ProductRepo = productRepo;
            ReviewRepo = reviewRepo;
        }
    }
}
