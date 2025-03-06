using System.ComponentModel.DataAnnotations;
using Web.Attributes;

namespace Web.Models;

[BillingTermsDtoValidation]
public class BillingTermsDto
{
    [Required]
    public InstallmentPlanDto? InstallmentPlan { get; set; }

    [Required]
    public DurationDto? Duration { get; set; }
}
