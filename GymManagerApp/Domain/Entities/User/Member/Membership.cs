using GymManagerApp.Domain.Entities.Common;

namespace GymManagerApp.Domain.Entities.User.Member
{
    public class Membership : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
