namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Data
{
    public interface ICartRepository
    {
        Cart Get(string id);

        Cart Save(Cart cart);

        void Delete(string id);
    }
}
