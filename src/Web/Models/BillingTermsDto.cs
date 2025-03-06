using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class BillingTermsDto
{
    [Required]
    public InstallmentPlanDto? InstallmentPlan { get; set; }

    [Required]
    public DurationDto? Duration { get; set; }
}
