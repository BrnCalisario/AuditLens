using ExampleApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExampleApi.Persistance.Configuration
{
    public class OrderClassMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")                
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.OrderDate)
                .HasColumnName("OrderDate")
                .IsRequired(true);

            builder.Property(x => x.CustomerName)
                .HasColumnName("CustomerName")
                .IsRequired(true);

            builder.Property(x => x.TotalAmount)
                .HasColumnName("TotalAmount")
                .HasColumnType("decimal(18, 2)")
                .IsRequired(true);

            builder.Property(x => x.OrderType)
                .HasColumnName("OrderType")
                .HasConversion<EnumToStringConverter<OrderType>>()
                .IsRequired(true);
        }
    }
}