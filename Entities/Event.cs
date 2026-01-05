using Microsoft.EntityFrameworkCore;

namespace TheFillingStation.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Event(string title, DateOnly eventDate, TimeOnly startTime, TimeOnly endTime, string summary, string badge)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public DateOnly EventDate { get; set; } = eventDate;
        public TimeOnly StartTime { get; set; } = startTime;
        public TimeOnly EndTime { get; set; } = endTime;
        public string Summary { get; set; } = summary;
        public string Badge { get; set; } = badge;
    }
}
