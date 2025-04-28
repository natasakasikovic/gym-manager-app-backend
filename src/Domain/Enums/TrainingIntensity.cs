namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TrainingIntensity
{
	Low,
	Moderate,
	High,
	Extreme
}