namespace GymManagerApp.Domain.Entities.User.Member
{
    public class Membership : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
