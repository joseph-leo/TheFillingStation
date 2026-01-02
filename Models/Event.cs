namespace TheFillingStation.Models
{
    public record Event(
        DateTime Date, 
        string Title, 
        string Time,
        string Summary,
        string Badge);
}
