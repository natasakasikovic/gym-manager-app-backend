namespace GymManagerApp.Application.DTOs
{
    public class TrainingDto
    {
        // TODO: add more attributes
        public DateTime ScheduledAt { get; init; }
        public int MaxParticipants { get; init; }

        public TrainingDto(DateTime scheduledAt, int maxParticipants)
        {
            this.ScheduledAt = scheduledAt;
            this.MaxParticipants = maxParticipants;
        }
    }
}
