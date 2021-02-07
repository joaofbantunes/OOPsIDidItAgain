using System;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain.ItemSaleRule
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
                throw new DomainException(new ErrorDetail.Invalid("Can't buy that yet!"));
            }
        }
    }
}