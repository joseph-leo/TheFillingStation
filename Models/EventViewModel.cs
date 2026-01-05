namespace TheFillingStation.Models
{
    public record EventViewModel(
        DateTime Date, 
        string Title, 
        string Time,
        string Summary,
        string Badge);
}
