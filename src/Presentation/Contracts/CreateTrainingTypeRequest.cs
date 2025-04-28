using Domain.Enums;

namespace Presentation.Contracts;

public sealed record CreateTrainingTypeRequest(string Name, string Description, TrainingIntensity Intensity);