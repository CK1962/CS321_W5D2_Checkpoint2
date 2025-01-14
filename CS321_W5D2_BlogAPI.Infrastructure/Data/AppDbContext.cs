﻿using CS321_W5D2_BlogAPI.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        // TODO: create Blogs, Posts, and Comments DbSets
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Blog>().HasData();

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Test Post" }
            );

            // modelBuilder.Entity<Comment>().HasData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: use Sqlite db
            optionsBuilder.UseSqlite("DataSource=../CS321_W5D2_BlogAPI.Infrastructure/blog.db");
        }
    }
}