﻿namespace GymManagerApp.Application.Common
{
	public class Result
	{
		protected Result(bool isSuccess, Error error)
		{
			if (isSuccess && error != Error.None || !isSuccess && error == Error.None )
				throw new ArgumentException("Invalid error ", nameof(error));
			
			IsSuccess = isSuccess;
			Error = error;
		}

		public bool IsSuccess { get; set; }

		public Error Error { get; }

		public bool IsFailure => !IsSuccess;

		public static Result Success() => new Result(true, Error.None);

		public static Result Failure(Error error) => new Result(false, error);

		public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

		public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

		public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

	}
}
