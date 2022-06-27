using RESTWithASP_NET5Udemy.Data.VO;

namespace RESTWithASP_NET5Udemy.Business
  
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);

    }
}