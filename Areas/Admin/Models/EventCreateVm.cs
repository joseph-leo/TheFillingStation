using System.ComponentModel.DataAnnotations;

namespace TheFillingStation.Areas.Admin.Models;

public sealed class EventCreateVm
{
    [Required, StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly EventDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [DataType(DataType.Time)]
    public TimeOnly? StartTime { get; set; }

    [DataType(DataType.Time)]
    public TimeOnly? EndTime { get; set; }

    [StringLength(2000)]
    public string? Summary { get; set; }

    [StringLength(50)]
    public string? Badge { get; set; }
}