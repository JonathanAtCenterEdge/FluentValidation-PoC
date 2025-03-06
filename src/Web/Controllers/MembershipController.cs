using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class MembershipController : Controller
{
    [HttpPost("/membership")]
    public IActionResult CreateMembership(
        [FromBody] MembershipDto membership)
    {
        ValidateBillingTermsDto(membership.BillingTermsAtSale);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(membership);
    }

    [HttpPut("/membership")]
    public IActionResult UpdateMembership(
        [FromBody] MembershipDto membership)
    {
        ValidateBillingTermsDto(membership.BillingTermsAtSale);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(membership);
    }

    private void ValidateBillingTermsDto(BillingTermsDto billingTermsDto)
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        foreach (var (key, message) in billingTermsDto.InstallmentPlan.CheckPlanValidity(billingTermsDto.Duration.NumberOfMonths))
        {
            ModelState.TryAddModelError(key, message);
        }
    }
}
