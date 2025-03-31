using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Models;

namespace Web.Validation;

public static class BillingTermsDtoValidation
{
    public static void ValidateBillingTermsDto(this ModelStateDictionary modelState, BillingTermsDto billingTermsDto)
    {
        if (!modelState.IsValid)
        {
            return;
        }

        foreach (var (key, message) in billingTermsDto.InstallmentPlan!.CheckPlanValidity(billingTermsDto.Duration!.NumberOfMonths))
        {
            modelState.TryAddModelError(key, message);
        }
    }
}
