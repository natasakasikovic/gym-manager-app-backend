﻿namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
	Male,
	Female
}