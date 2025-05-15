using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
     class ClubMemebershipDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {AppDomain.CurrentDomain.BaseDirectory}ClubMemberShipDb.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User>Users { get; set; }

    }
}
