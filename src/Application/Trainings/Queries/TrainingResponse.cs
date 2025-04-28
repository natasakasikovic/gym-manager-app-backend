namespace Application.Trainings.Queries;

public sealed record TrainingResponse(int Id, string Type, DateTime ScheduledAt, int MaxParticipants);