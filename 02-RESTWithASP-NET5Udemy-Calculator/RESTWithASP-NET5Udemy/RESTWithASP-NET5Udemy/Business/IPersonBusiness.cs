using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Business
  
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}