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
        public IQueryable<Product> Data => throw new NotImplementedException();

        public EFProductRepo()
        {
            db = new GummiBearKingdomContext();
        }

        public EFProductRepo(GummiBearKingdomContext db)
        {
            this.db = db;
        }

        public Product Save(Product obj)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
