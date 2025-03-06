using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class InstallmentPlanDto
{
    [Required]
    [Range(2, 99)]
    public int NumberOfInstallments { get; set; }

    [Required]
    [Range(1, 12)]
    public int InstallmentFrequency { get; set; }
}
