using GymManagerApp.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations
{
    public class TrainingTypeConfiguration : IEntityTypeConfiguration<TrainingType>
    {
        public void Configure(EntityTypeBuilder<TrainingType> builder)
        {
            builder.ToTable("TrainingType");
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(300);
            builder.Property(t => t.Intensity).HasConversion<int>();
        }
    }
}
