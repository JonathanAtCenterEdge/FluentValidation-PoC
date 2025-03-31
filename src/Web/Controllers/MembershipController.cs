using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Validation;

namespace Web.Controllers;

public class MembershipController : Controller
{
    [HttpPost("/membership")]
    public IActionResult CreateMembership(
        [FromBody] MembershipDto membership)
    {
        ModelState.ValidateBillingTermsDto(membership.BillingTermsAtSale!);

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
        ModelState.ValidateBillingTermsDto(membership.BillingTermsAtSale!);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(membership);
    }
}
