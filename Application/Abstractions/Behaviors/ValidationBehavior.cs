﻿using Domain.Shared;
using Domain.Shared.Errors;
using Domain.Shared.Validation;

namespace Application.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
    where TResponse : Response
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        Error[] errors = _validators
            .Select(async validator => await validator.ValidateAsync(request))
            .SelectMany(validationResult => validationResult.Result.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(failure.ErrorMessage, failure.PropertyName))
            .Distinct()
            .ToArray();

        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Response
    {
        if (typeof(TResult) == typeof(Response))
            return (ValidationResult.WithErrors(errors) as TResult)!;

        object validationReuslt = typeof(ValidationResult)
                                    .GetGenericTypeDefinition()
                                    .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                                    .GetMethod(nameof(ValidationResult.WithErrors))
                                    .Invoke(null, new object[] { errors })!;

        return (TResult)validationReuslt;


    }
}