using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class MembershipController : Controller
{
    [HttpPost("/membership")]
    public IActionResult CreateMembership(
        [FromBody] MembershipDto membership)
    {
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(membership);
    }
}
