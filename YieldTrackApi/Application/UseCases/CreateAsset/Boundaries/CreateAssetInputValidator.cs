using FluentValidation;

namespace Application.UseCases.CreateAsset.Boundaries;

public class CreateAssetInputValidator : AbstractValidator<CreateAssetInput>
{
    private const int MinimumValue = 0;

    public CreateAssetInputValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("The code is required.");

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Issuer)
            .NotEmpty();

        RuleFor(x => x.FaceValue)
            .GreaterThan(MinimumValue).NotEmpty();

        RuleFor(x => x.CurrentRate)
            .GreaterThan(MinimumValue).NotEmpty();

        RuleFor(x => x.MaturityDate)
            .GreaterThan(DateTime.Now).NotEmpty();

        RuleFor(x => x.RateType)
            .NotEmpty();
    }
}
