using GymManagerApp.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations.UserConfiguration;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admin");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Email).IsRequired();
        builder.Property(a => a.Password).IsRequired();
    }
}