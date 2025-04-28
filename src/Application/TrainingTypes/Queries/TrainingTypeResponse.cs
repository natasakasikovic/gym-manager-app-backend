using Domain.Enums;

namespace Application.TrainingTypes.Queries.GetTrainingTypes;

public record TrainingTypeResponse(int Id, string Name, string Description, TrainingIntensity Intensity);