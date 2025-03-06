using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class DurationDto
{
    [Required]
    public int NumberOfMonths { get; set; }
}
