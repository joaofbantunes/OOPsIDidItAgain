namespace OOPsIDidItAgain._04.OOifying.Web.Domain;

public interface ICartRepository
{
    Cart Get(string id);

    Cart Save(Cart cart);

    void Delete(string id);
}
