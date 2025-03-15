﻿namespace GymManagerApp.Application.Common
{
	public sealed record Error (string Code, string? Description = null)
	{ 
		public static readonly Error None = new(string.Empty, string.Empty);
		public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
	}
}
