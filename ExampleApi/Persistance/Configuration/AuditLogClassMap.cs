using ExampleApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleApi.Persistance.Configuration
{
    public class AuditLogClassMap : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("AuditLog", "audit");

            builder.HasKey(x => x.AuditId);

            builder.Property(x => x.AuditId)
                .HasColumnName("AuditId")
                .HasColumnType("bigint")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TableName)
                .HasColumnName("TableName")
                .IsRequired(true);  

            builder.Property(x => x.AuditUser)
                .HasColumnName("AuditUser")
                .IsRequired(true);

            builder.Property(x => x.AuditAction)
                .HasColumnName("AuditAction")
                .IsRequired(true);

            builder.Property(x => x.AuditData)
                .HasColumnName("AuditData")
                .IsRequired(true);

            builder.Property(x => x.AuditDate)
                .HasColumnName("AuditDate")
                .IsRequired(true);
        }
    }
}