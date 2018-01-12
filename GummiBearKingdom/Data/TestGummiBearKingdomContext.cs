using System;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Data
{
    public class TestGummiBearKingdomContext : GummiBearKingdomContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("server=localhost;port=8889;database=gummibearkingdom_test;uid=root;pwd=root;");
        }
    }
}
