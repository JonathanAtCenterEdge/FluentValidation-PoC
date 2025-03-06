using System.ComponentModel.DataAnnotations;
using Web.Models;

namespace Web.Attributes;

// Hard to unit test, we'd need to publicly expose it in some way.
// Not strongly typed, it relies on object.
// Cannot be async, the MVC validation pipeline is synchronous.
// Errors and Keys must be manually specified.
public class BillingTermsDtoValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not BillingTermsDto { InstallmentPlan: not null, Duration: not null } billingTermsDto)
        {
            return ValidationResult.Success;
        }

        if (billingTermsDto.InstallmentPlan.NumberOfInstallments > billingTermsDto.Duration.NumberOfMonths)
        {
            return new ValidationResult(
                errorMessage: $"{nameof(InstallmentPlanDto.NumberOfInstallments)} must be less than the duration in months.",
                memberNames: [$"{nameof(BillingTermsDto.InstallmentPlan.NumberOfInstallments)}"]);
        }

        if (billingTermsDto.InstallmentPlan.InstallmentFrequency * (billingTermsDto.InstallmentPlan.NumberOfInstallments - 1) > billingTermsDto.Duration.NumberOfMonths)
        {
            return new ValidationResult(
                errorMessage: "Plan will not fit within the entire membership duration.",
                memberNames: [$"{nameof(BillingTermsDto.InstallmentPlan)}"]);
        }

        return ValidationResult.Success;
    }
}
