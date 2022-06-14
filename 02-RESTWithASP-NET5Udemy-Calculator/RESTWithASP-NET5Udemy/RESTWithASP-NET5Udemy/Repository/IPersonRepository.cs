using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Repository

  
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long id);

    }
}