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

        private Training(TrainingType type, DateTime scheduledAt, Trainer trainer, int maxParticipants)
		{
			Type = type;
			ScheduledAt = scheduledAt;
			Trainer = trainer;
			MaxParticipants = maxParticipants;
			Participants = new();
		}

		public static Training Create (TrainingType type, DateTime scheduledAt, Trainer trainer, int maxParticipants)
		{
			return new Training(type, scheduledAt, trainer, maxParticipants);
		}

		public void Update(DateTime scheduledAt, int maxParticipants)
		{
			ScheduledAt = scheduledAt;
			MaxParticipants = maxParticipants;
		}

		public bool IsUpcoming()
		{
			return ScheduledAt > DateTime.UtcNow;
		}
	}
}