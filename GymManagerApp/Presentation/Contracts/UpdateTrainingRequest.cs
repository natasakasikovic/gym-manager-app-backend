namespace GymManagerApp.Presentation.Contracts
{
	public sealed record UpdateTrainingRequest (DateTime ScheduledAt, int MaxParticipants);
}
