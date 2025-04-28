using Domain.Enums;

namespace Presentation.Contracts;

public sealed record UpdateTrainingTypeRequest(string Name, string Description, TrainingIntensity Intensity);