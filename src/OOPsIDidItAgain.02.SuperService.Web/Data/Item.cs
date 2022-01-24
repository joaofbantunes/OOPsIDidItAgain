namespace OOPsIDidItAgain._02.SuperService.Web.Data;

public class Item
{
    public string Id { get; set; }

    public int? MaximumQuantity { get; set; }

    public TimeSpan? MinimumTimeOfDayToSell { get; set; }

    public bool IsInWatchlist { get; set; }
}