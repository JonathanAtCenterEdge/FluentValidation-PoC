using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class BillingTermsController(IValidator<BillingTermsDto> billingTermsValidator): Controller
{
    [HttpPost("/billingTerms")]
    public IActionResult CreateBillingTerms(
        [FromBody] BillingTermsDto billingTermsDto)
    {
        billingTermsValidator
            .Validate(billingTermsDto)
            .AddToModelState(ModelState);

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
        billingTermsValidator
            .Validate(billingTermsDto)
            .AddToModelState(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(billingTermsDto);
    }
}
