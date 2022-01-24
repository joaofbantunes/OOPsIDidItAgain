namespace OOPsIDidItAgain._01.SuperController.Web.Data;

public interface ICartRepository
{
    Cart Get(string id);
        
    Cart Save(Cart cart);

    void Delete(string id);
}