using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using VOneDomain.Models;

namespace VOneDal.UnitOfWork
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        // User Tables
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<AccessLevel> AccessLevel { get; set; }
        public virtual DbSet<Department> Department { get; set; }

        // Product Tables
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductTag> ProductTag { get; set; }
        public virtual DbSet<ProductGallery> ProductGallery { get; set; }
        public virtual DbSet<ProductStatus> ProductStatus { get; set; }

        // Trakt Tables
        public virtual DbSet<Trakt> Trakt { get; set; }
        public virtual DbSet<TraktCategory> TraktCategory { get; set; }
        public virtual DbSet<TraktTag> TraktTag { get; set; }
        public virtual DbSet<TraktStatus> TraktStatus { get; set; }
        public virtual DbSet<TraktType> TraktType { get; set; }

        // Plant Tables
        public virtual DbSet<Plant> Plant { get; set; }
        public virtual DbSet<PlantDetails> PlantDetails { get; set; }
        public virtual DbSet<PlantStatus> PlantStatus { get; set; }
        public virtual DbSet<PlantType> PlantType { get; set; }
        public virtual DbSet<PlantJoinTrakt> PlantJoinTrakt { get; set; }

        // General Tables
        public virtual DbSet<Setting> Setting { get; set; }
    }
}
