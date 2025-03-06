using FluentValidation;
using Web.Models;

namespace Web.Validators;

// Can be async https://docs.fluentvalidation.net/en/latest/async.html?highlight=async
// Strongly typed
// Can be very easily unit tested with native fluent-like assertions
// Lives separate from the model
// Is fluently readable
// Errors and Keys are automatic, but can be manually overridden fluently
public class BillingTermsDtoValidator : AbstractValidator<BillingTermsDto?>
{
    public BillingTermsDtoValidator()
    {
        When(dto => dto is { InstallmentPlan: not null, Duration: not null }, () =>
        {
            RuleFor(dto => dto!.InstallmentPlan!.NumberOfInstallments)
                .LessThan(dto => dto!.Duration!.NumberOfMonths)
                .WithMessage("{PropertyName} must be less than the duration in months."); // https://docs.fluentvalidation.net/en/latest/configuring.html#placeholders

            RuleFor(dto => dto)
                .Must(dto => dto!.InstallmentPlan!.InstallmentFrequency * (dto.InstallmentPlan.NumberOfInstallments - 1) <= dto.Duration!.NumberOfMonths)
                .WithName($"{nameof(BillingTermsDto.InstallmentPlan)}")
                .WithMessage("Plan will not fit within the entire membership duration.");
        });
    }
}
