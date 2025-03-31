using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class BillingTermsController(IValidator<BillingTermsDto> billingTermsDtoValidator) : Controller
{
    [HttpPost("/billingTerms")]
    public IActionResult CreateBillingTerms(
        [FromBody] BillingTermsDto billingTermsDto)
    {
        billingTermsDtoValidator
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
        billingTermsDtoValidator
            .Validate(billingTermsDto)
            .AddToModelState(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(billingTermsDto);
    }
}
