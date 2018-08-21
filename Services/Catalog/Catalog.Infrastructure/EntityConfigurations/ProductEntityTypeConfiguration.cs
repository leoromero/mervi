using Catalog.Domain.AggregatesModels.ProductAggregate;
using Catalog.Domain.AggregatesModels.ProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> orderConfiguration)
        {
            orderConfiguration.ToTable("Products");
            orderConfiguration.HasKey(x => x.Id);

            orderConfiguration.Ignore(x => x.DomainEvents);

            orderConfiguration.Property<string>("Name").IsRequired();
            orderConfiguration.Property<decimal>("Price").IsRequired();


            orderConfiguration.Metadata.FindNavigation(nameof(Product.ProductTags))
                .SetPropertyAccessMode(PropertyAccessMode.Field);


            orderConfiguration.HasOne<Category>("Category")
                .WithMany()
                .IsRequired()
                .HasForeignKey("CategoryId");

            orderConfiguration.HasOne<Provider>()
                .WithMany()
                .HasForeignKey("ProviderId");
        }
    }
}
