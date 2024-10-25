namespace GymManagerApp.Domain.Entities.User.Member
{
    public class Member : User
    {
        public List<Membership> Membership { get; set; }
    }
}
