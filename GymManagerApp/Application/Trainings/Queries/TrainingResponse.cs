namespace GymManagerApp.Application.Trainings.Queries.GetTrainings;

public sealed record TrainingResponse(int Id, string Type, DateTime ScheduledAt, int MaxParticipants);