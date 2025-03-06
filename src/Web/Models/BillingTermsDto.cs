using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class BillingTermsDto : IValidatableObject
{
    [Required]
    public InstallmentPlanDto? InstallmentPlan { get; set; }

    [Required]
    public DurationDto? Duration { get; set; }

    // Easier to unit test, but you still need to be quite verbose when checking for failures.
    // Cannot be async, the MVC validation pipeline is synchronous.
    // Errors and Keys must be manually specified.
    // Validation Logic lives in the model. May or may not be a con depending on your perspective.
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (InstallmentPlan is null || Duration is null)
        {
            yield break;
        }

        if (InstallmentPlan.NumberOfInstallments > Duration.NumberOfMonths)
        {
            yield return new ValidationResult(
                errorMessage: $"{nameof(InstallmentPlanDto.NumberOfInstallments)} must be less than the duration in months.",
                memberNames: [$"{nameof(BillingTermsDto.InstallmentPlan.NumberOfInstallments)}"]);
        }

        if (InstallmentPlan.InstallmentFrequency * (InstallmentPlan.NumberOfInstallments - 1) > Duration.NumberOfMonths)
        {
            yield return new ValidationResult(
                errorMessage: "Plan will not fit within the entire membership duration.",
                memberNames: [$"{nameof(InstallmentPlan)}"]);
        }
    }
}
