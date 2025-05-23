﻿using Application.Common.Enums;

namespace Application.Common.Models;

public sealed record Error(string Code, string? Description = null, ErrorType ErrorType = ErrorType.BadRequest)
{
	public static readonly Error None = new(string.Empty, string.Empty);
	public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
}