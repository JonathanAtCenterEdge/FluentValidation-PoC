using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Validators;

namespace Web.Controllers;

public class MembershipController : Controller
{
    private readonly BillingTermsDtoValidator _billingTermsDtoValidator = new();

    [HttpPost("/membership")]
    public IActionResult CreateMembership(
        [FromBody] MembershipDto membership)
    {
        _billingTermsDtoValidator
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
        _billingTermsDtoValidator
            .Validate(membership.BillingTermsAtSale)
            .AddToModelState(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(membership);
    }
}
