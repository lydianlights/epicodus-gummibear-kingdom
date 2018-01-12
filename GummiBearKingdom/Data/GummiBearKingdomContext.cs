using System;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Data
{
    public class GummiBearKingdomContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql("server=localhost;port=8889;database=gummibearkingdom;uid=root;pwd=root;");
		}
    }
}
