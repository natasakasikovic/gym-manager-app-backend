namespace GymManagerApp.Application.Trainings.Queries.GetTrainings
{
    public class TrainingResponse
    {
        // TODO: add more attributes
        public int Id { get; init; }
        public DateTime ScheduledAt { get; init; }
        public int MaxParticipants { get; init; }

        public TrainingResponse(int id, DateTime scheduledAt, int maxParticipants)
        {
            Id = id;
            ScheduledAt = scheduledAt;
            MaxParticipants = maxParticipants;
        }
    }
}
