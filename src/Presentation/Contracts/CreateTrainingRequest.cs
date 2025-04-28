namespace Presentation.Contracts;

public sealed record CreateTrainingRequest(DateTime ScheduledAt, int TrainingTypeId, int MaxParticipants) { }