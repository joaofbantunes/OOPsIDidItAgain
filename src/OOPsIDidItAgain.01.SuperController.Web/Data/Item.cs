using System;

namespace OOPsIDidItAgain._01.SuperController.Web.Data
{
    public class Item
    {
        public Guid Id { get; set; }

        public int? MaximumQuantity { get; set; }

        public TimeSpan? MinimumTimeOfDayToSell { get; set; }

        public bool IsInWatchlist { get; set; }
    }
}