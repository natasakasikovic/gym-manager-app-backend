using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.TrainingTypes.Queries.GetTrainingTypes;

public record TrainingTypeResponse(int Id, string Name, string Description, TrainingIntensity Intensity);
