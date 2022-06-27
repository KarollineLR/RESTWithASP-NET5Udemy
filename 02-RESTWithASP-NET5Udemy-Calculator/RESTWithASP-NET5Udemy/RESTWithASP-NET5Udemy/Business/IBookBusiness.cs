using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Business
  
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}