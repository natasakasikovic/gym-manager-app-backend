using System.Text.Json.Serialization;

namespace GymManagerApp.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
	Male,
	Female
}