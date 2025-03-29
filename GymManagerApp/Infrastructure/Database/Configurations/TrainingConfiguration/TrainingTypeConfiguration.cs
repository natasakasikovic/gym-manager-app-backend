using GymManagerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations.TrainingConfiguration;

public class TrainingTypeConfiguration : IEntityTypeConfiguration<TrainingType>
{
    public void Configure(EntityTypeBuilder<TrainingType> builder)
    {
        builder.ToTable("TrainingType");
        builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(150).IsRequired();
        builder.Property(t => t.Intensity).HasConversion<int>().IsRequired();
    }
}