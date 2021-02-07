using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Domain
{
    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; }
        
    }
}