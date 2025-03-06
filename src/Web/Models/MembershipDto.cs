using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class MembershipDto
{
    [Required]
    public BillingTermsDto BillingTermsAtSale { get; set; } = new();
}
