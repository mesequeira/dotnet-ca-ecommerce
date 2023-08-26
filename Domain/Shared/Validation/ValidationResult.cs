using Domain.Shared.Errors;

namespace Domain.Shared.Validation;

public sealed class ValidationResult : Response, IValidationResult
{
    public Error[] Errors { get; }

    Error IValidationResult.Errors => throw new NotImplementedException();

    private ValidationResult(Error[] errors) => Errors = errors;

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}
