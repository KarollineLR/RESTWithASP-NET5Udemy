using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Hypermedia.Utils;
using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Business
  
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);

    }
}