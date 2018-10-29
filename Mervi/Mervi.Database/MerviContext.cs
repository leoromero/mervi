using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mervi.Database.Entities;
using Mervi.Database.Entities.Catalogue;
using Mervi.Database.Entities.Common;
using Mervi.Database.Entities.Customer;
using Mervi.Database.Entities.Orders;
using Mervi.Database.Entities.Shop;
using Mervi.Database.EntityTypeConfigurations;

namespace Mervi.Database
{
    public class MerviContext : DbContext
    {
        public MerviContext(DbContextOptions<MerviContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        }
    }

    public class MerviContextFactory : IDesignTimeDbContextFactory<MerviContext>
    {
        public MerviContext CreateDbContext(string[] args)
        {
            //var configurationPackage = Context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            //var connectionStringParameter = configurationPackage.Settings.Sections["UserDatabase"].Parameters["UserDatabaseConnectionString"];
            //var baseUri = Environment.GetEnvironmentVariable("ConnectionString");

            var builder = new DbContextOptionsBuilder<MerviContext>();
            builder.UseSqlServer(@"Server=.\sqlexpress;Database=Mervi;Integrated Security=True;");
            return new MerviContext(builder.Options);
        }
    }
}
