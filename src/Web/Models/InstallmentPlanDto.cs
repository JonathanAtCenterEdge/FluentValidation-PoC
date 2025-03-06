using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class InstallmentPlanDto
{
    [Required]
    [Range(2, 99)]
    public int NumberOfInstallments { get; set; } = 2;

    [Required]
    [Range(1, 12)]
    public int InstallmentFrequency { get; set; } = 1;

    /// <summary>
    /// Ensures the plan can fit inside a <see cref="DurationDto"/>.
    /// </summary>
    public IEnumerable<(string Key, string Message)> CheckPlanValidity(int durationInMonths)
    {
        if (NumberOfInstallments > durationInMonths)
        {
            yield return (nameof(NumberOfInstallments), $"{nameof(NumberOfInstallments)} must be less than the duration in months.");
        }

        if (InstallmentFrequency * (NumberOfInstallments - 1) > durationInMonths)
        {
            yield return (nameof(InstallmentPlanDto), "Plan will not fit within the entire membership duration.");
        }
    }
}
