using GymManagerApp.Domain.Entities.User.Member;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApp.Infrastructure.Database.Configurations.UserConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.Password).IsRequired();
            builder.HasMany(m => m.Membership).WithOne().HasForeignKey("Id");
        }
    }
}
