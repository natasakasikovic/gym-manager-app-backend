using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Presentation.Contracts;

public sealed record CreateTrainingTypeRequest(string Name, string Description, TrainingIntensity Intensity);
