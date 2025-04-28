using Application.Common.Models;

namespace Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
																								where TResponse : Result
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
	{
		_validators = validators;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if (_validators.Any())
		{
			var context = new ValidationContext<TRequest>(request);

			var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

			var firstError = validationResults
				.SelectMany(r => r.Errors)
				.FirstOrDefault();

			if (firstError != null)
			{
				var error = new Error("Validation.Failed", firstError.ErrorMessage);
				return (TResponse)(object)Result.Failure(error);
			}
		}

		return await next();
	}
}