namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Data;

public class Item
{
    public string Id { get; set; }

    public int? MaximumQuantity { get; set; }

    public TimeSpan? MinimumTimeOfDayToSell { get; set; }

    public bool IsInWatchlist { get; set; }
}
