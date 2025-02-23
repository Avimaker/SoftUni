using System;
using EFCoreCodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Data
{
	public class MyBlogDbContext : DbContext
	{
		public MyBlogDbContext()
		{

		}

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options)
			: base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder
                    .UseSqlServer(DbConfig.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}

