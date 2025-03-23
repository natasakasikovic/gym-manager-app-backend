﻿using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations.UserConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");
		builder.HasKey(u => u.Id);

		builder.Property(u => u.Name)
			   .IsRequired()
			   .HasMaxLength(50);

		builder.Property(u => u.LastName)
			   .IsRequired()
			   .HasMaxLength(50);

		builder.Property(u => u.Email)
			   .IsRequired()
			   .HasMaxLength(100);

		builder.HasIndex(u => u.Email)
			   .IsUnique();

		builder.Property(u => u.Password)
			   .IsRequired();

		builder.Property(u => u.PhoneNumber)
			   .HasMaxLength(20);

		builder.Property(u => u.Role)
			   .IsRequired();

		builder.Property(u => u.Gender)
			   .IsRequired();

		builder.HasDiscriminator<Role>("Role")
			   .HasValue<User>(Role.Administrator)
			   .HasValue<User>(Role.Trainer)
			   .HasValue<Member>(Role.Member);
	}
}
