using FluentValidation.TestHelper;
using Web.Models;
using Web.Validators;

namespace Web.UnitTests;

public class BillingTermsDtoValidatorTests
{
    private readonly BillingTermsDtoValidator _billingTermsValidator = new();

    [Fact]
    public void InstallmentPlan_NumberOfInstallmentsGreaterThanDuration_ShouldReturnFailure()
    {
        var billingTermsDto = new BillingTermsDto
        {
            InstallmentPlan = new InstallmentPlanDto
            {
                NumberOfInstallments = 2,
                InstallmentFrequency = 1
            },
            Duration = new DurationDto
            {
                NumberOfMonths = 1
            }
        };

        var result = _billingTermsValidator.TestValidate(billingTermsDto);

        result.ShouldHaveValidationErrorFor(dto => dto.InstallmentPlan!.NumberOfInstallments);
    }

    [Fact]
    public void InstallmentPlan_DoesNotFitWithinDuration_ShouldReturnFailure()
    {
        var billingTermsDto = new BillingTermsDto
        {
            InstallmentPlan = new InstallmentPlanDto
            {
                NumberOfInstallments = 2,
                InstallmentFrequency = 12
            },
            Duration = new DurationDto
            {
                NumberOfMonths = 6
            }
        };

        var result = _billingTermsValidator.TestValidate(billingTermsDto);

        result
            .ShouldHaveValidationErrorFor(dto => dto.InstallmentPlan)
            .WithErrorMessage("Plan will not fit within the entire membership duration.");
    }
}
