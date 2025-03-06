using FluentValidation;
using Web.Models;

namespace Web.Validators;

public class BillingTermsDtoValidator : AbstractValidator<BillingTermsDto>
{
    public BillingTermsDtoValidator()
    {
        When(dto => dto.InstallmentPlan is not null && dto.Duration is not null, () =>
        {
            RuleFor(dto => dto.InstallmentPlan!.NumberOfInstallments)
                .LessThan(dto => dto.Duration!.NumberOfMonths)
                .WithMessage("{PropertyName} must be less than the duration in months.");

            RuleFor(dto => dto)
                .Must(dto => dto.InstallmentPlan!.InstallmentFrequency * (dto.InstallmentPlan.NumberOfInstallments - 1) <= dto.Duration!.NumberOfMonths)
                .WithName($"{nameof(BillingTermsDto.InstallmentPlan)}")
                .WithMessage("Plan will not fit within the entire membership duration.");
        });
    }
}
