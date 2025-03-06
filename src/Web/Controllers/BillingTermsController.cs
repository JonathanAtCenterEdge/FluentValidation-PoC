using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Validators;

namespace Web.Controllers;

public class BillingTermsController : Controller
{
    private readonly BillingTermsDtoValidator _billingTermsDtoValidator = new();

    [HttpPost("/billingTerms")]
    public IActionResult CreateBillingTerms(
        [FromBody] BillingTermsDto billingTermsDto)
    {
        _billingTermsDtoValidator
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
        _billingTermsDtoValidator
            .Validate(billingTermsDto)
            .AddToModelState(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(billingTermsDto);
    }
}
