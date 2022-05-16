using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class EFContext : DbContext
    {
        public DbSet<Data> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=HP-PERSONAL\LOCALSQLSERVER;Initial Catalog=OrmTests;Integrated Security=True");
            }


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Data>().HasKey("Id");
            base.OnModelCreating(builder);
        }

    }
}
