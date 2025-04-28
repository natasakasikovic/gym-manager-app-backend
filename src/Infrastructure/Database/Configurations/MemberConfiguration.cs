using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
	public void Configure(EntityTypeBuilder<Member> builder)
	{
		builder.Property(u => u.MembershipExpiration)
			.HasColumnType("timestamp without time zone");
	}
}