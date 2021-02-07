using System;
using OOPsIDidItAgain._04.OOifying.Web.Exceptions;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain.ItemSaleRule
{
    public class MinimumTimeOfDayForSaleRule : IItemSaleRule
    {
        public MinimumTimeOfDayForSaleRule(TimeSpan minimumTimeOfDayForSale)
        {
            MinimumTimeOfDayForSale = minimumTimeOfDayForSale;
        }

        public TimeSpan MinimumTimeOfDayForSale { get; }
        
        public void Validate(Cart cart, Item item, int quantity)
        {
            if (MinimumTimeOfDayForSale  > DateTime.Now.TimeOfDay)
            {
                throw new ValidationException("Can't buy that yet!");
            }
        }
    }
}