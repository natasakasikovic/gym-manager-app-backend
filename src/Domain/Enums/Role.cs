namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
	Member,
	Administrator,
	Trainer
}