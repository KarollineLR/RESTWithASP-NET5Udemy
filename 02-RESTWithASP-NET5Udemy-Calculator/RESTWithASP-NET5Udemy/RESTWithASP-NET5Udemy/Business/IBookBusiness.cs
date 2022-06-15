using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Business
  
{
    public interface IBookBusiness
    {
        Book Create(Book person);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);

    }
}