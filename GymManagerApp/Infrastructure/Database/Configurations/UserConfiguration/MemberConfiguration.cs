using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Infrastructure.Database.Configurations.UserConfiguration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
	public void Configure(EntityTypeBuilder<Member> builder)
	{
		builder.Property(u => u.MembershipExpiration)
			.HasColumnType("timestamp without time zone");
	}
}
