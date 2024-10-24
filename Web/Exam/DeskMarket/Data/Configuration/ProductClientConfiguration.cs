namespace DeskMarket.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.ClientId });

            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pc => pc.Client)
                .WithMany()
                .HasForeignKey(pc => pc.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
