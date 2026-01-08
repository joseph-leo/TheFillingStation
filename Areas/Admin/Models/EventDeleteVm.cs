using System.ComponentModel.DataAnnotations;

namespace TheFillingStation.Areas.Admin.Models;

public sealed class EventDeleteVm
{
    [Required]
    public int Id { get; init; }

    public required string Title { get; init; }

    [Display(Name = "Date")]
    public DateOnly EventDate { get; init; }

    public TimeOnly? StartTime { get; init; }

    public TimeOnly? EndTime { get; init; }

    public string? Badge { get; init; }
}