using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class BillingTermsController : Controller
{
    [HttpPost("/billingTerms")]
    public IActionResult CreateBillingTerms(
        [FromBody] BillingTermsDto billingTermsDto)
    {
        ValidateBillingTermsDto(billingTermsDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(billingTermsDto);
    }

    [HttpPut("/billingTerms")]
    public IActionResult UpdateBillingTerms(
        [FromBody] BillingTermsDto billingTermsDto)
    {
        ValidateBillingTermsDto(billingTermsDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(billingTermsDto);
    }

    private void ValidateBillingTermsDto(BillingTermsDto billingTermsDto)
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        foreach (var (key, message) in billingTermsDto.InstallmentPlan!.CheckPlanValidity(billingTermsDto.Duration!.NumberOfMonths))
        {
            ModelState.TryAddModelError(key, message);
        }
    }
}
