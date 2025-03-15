using GymManagerApp.Domain.Entities.Common;
using GymManagerApp.Domain.Entities.User;
using GymManagerApp.Domain.Entities.User.Member;

namespace GymManagerApp.Domain.Entities.Training
{
    public class Training : BaseEntity
    {
        public TrainingType Type { get; private set; }

        public DateTime ScheduledAt { get; private set; }

        public Trainer Trainer { get; private set; }

        public int MaxParticipants { get; private set; }

        public List<Member> Participants { get; private set; }  

        private Training() { }

		public bool IsUpcoming()
		{
			return ScheduledAt > DateTime.UtcNow;
		}
	}
}
