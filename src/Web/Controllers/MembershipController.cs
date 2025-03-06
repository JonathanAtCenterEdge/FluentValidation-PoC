using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class MembershipController(IValidator<BillingTermsDto?> billingTermsValidator) : Controller
{
    [HttpPost("/membership")]
    public IActionResult CreateMembership(
        [FromBody] MembershipDto membership)
    {
        billingTermsValidator
            .Validate(membership.BillingTermsAtSale)
            .AddToModelState(ModelState);

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
        billingTermsValidator
            .Validate(membership.BillingTermsAtSale)
            .AddToModelState(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(membership);
    }
}
