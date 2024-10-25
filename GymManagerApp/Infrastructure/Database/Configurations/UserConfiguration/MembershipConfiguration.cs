using GymManagerApp.Domain.Entities.User.Member;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagerApp.Infrastructure.Database.Configurations.UserConfiguration
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("Memberships");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.StartDate).IsRequired();
            builder.Property(m => m.ExpirationDate).IsRequired();
        }
    }
}
