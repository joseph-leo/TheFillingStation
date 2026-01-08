using Microsoft.EntityFrameworkCore;

namespace TheFillingStation.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Event
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateOnly EventDate { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Summary { get; set; }
        public string? Badge { get; set; }
    }
}
