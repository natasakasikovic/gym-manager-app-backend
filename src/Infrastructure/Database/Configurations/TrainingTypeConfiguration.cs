using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

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