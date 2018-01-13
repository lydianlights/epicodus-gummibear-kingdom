using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Data
{
    public class EFReviewRepo : IDbRepo<Review>
    {
        private GummiBearKingdomContext db;
        public IQueryable<Review> Data { get => db.Reviews; }

        public EFReviewRepo()
        {
            db = new GummiBearKingdomContext();
        }

        public EFReviewRepo(GummiBearKingdomContext db)
        {
            this.db = db;
        }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Delete(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand($"DELETE FROM {Review.TableName}");
        }
    }
}
