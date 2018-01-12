using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Data
{
    public class EFProductRepo : IDbRepo<Product>
    {
        private GummiBearKingdomContext db;
        public IQueryable<Product> Data { get => db.Products; }

        public EFProductRepo()
        {
            db = new GummiBearKingdomContext();
        }

        public EFProductRepo(GummiBearKingdomContext db)
        {
            this.db = db;
        }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand($"DELETE FROM {Product.TableName}");
        }
    }
}
