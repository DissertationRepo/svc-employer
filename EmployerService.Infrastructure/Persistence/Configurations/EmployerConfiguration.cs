using EmployerService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerService.Infrastructure.Persistence.Configurations;

public sealed class EmployerEntityConfiguration : IEntityTypeConfiguration<EmployerEntity>
{
    public void Configure(EntityTypeBuilder<EmployerEntity> builder)
    {
        builder.ToTable("employers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.Property(x => x.CompanyName)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("company_name");

        builder.Property(x => x.CompanyDescription)
            .HasColumnType("text")
            .HasColumnName("company_description");

        builder.Property(x => x.Industry)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("industry");

        builder.Property(x => x.CompanySize)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("company_size");

        builder.Property(x => x.ContactEmail)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("contact_email");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
    }
}
