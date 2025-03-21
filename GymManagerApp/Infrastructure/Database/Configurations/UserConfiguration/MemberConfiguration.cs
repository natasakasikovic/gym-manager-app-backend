using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GymManagerApp.Domain.Entities.User;

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
        }
    }
}
