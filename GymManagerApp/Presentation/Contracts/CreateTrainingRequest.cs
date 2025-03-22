namespace GymManagerApp.Presentation.Contracts;

public sealed record CreateTrainingRequest(int TrainingTypeId, DateTime ScheduledAt, int TrainerId, int MaxParticipants) { }