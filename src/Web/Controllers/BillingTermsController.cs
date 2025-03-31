using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Validation;

namespace Web.Controllers;

public class BillingTermsController : Controller
{
    [HttpPost("/billingTerms")]
    public IActionResult CreateBillingTerms(
        [FromBody] BillingTermsDto billingTermsDto)
    {
        ModelState.ValidateBillingTermsDto(billingTermsDto);

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
        ModelState.ValidateBillingTermsDto(billingTermsDto);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(billingTermsDto);
    }
}
