using GymManagerApp.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations.UserConfiguration;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.ToTable("Trainer");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Email).IsRequired();
        builder.Property(t => t.Password).IsRequired();
    }
}