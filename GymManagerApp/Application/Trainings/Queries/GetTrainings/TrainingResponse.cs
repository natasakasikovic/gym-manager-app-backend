namespace GymManagerApp.Application.Trainings.Queries.GetTrainings
{
    public class TrainingResponse
    {
        // TODO: add more attributes
        public DateTime ScheduledAt { get; init; }
        public int MaxParticipants { get; init; }

        public TrainingResponse(DateTime scheduledAt, int maxParticipants)
        {
            ScheduledAt = scheduledAt;
            MaxParticipants = maxParticipants;
        }
    }
}
