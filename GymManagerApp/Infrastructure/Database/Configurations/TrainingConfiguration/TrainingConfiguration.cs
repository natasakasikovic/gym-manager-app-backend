﻿using GymManagerApp.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations.TrainingConfiguration
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable("Training");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Type).WithMany().HasForeignKey("TrainingTypeId");
            builder.HasOne(t => t.Trainer).WithMany().HasForeignKey("TrainerId");
        }
    }
}