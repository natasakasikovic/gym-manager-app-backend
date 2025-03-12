namespace GymManagerApp.Application.DTOs
{
    public class TrainingDto
    {
        // TODO: add more attributes
        public DateTime ScheduledAt { get; set; }
        public int MaxParticipants { get; set; }

        public TrainingDto(DateTime scheduledAt, int maxParticipants)
        {
            this.ScheduledAt = scheduledAt;
            this.MaxParticipants = maxParticipants;
        }
    }
}
