using System.Text.Json.Serialization;

namespace GymManagerApp.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TrainingIntensity
{
    Low,
    Moderate,
    High,
    Extreme
}