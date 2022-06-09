using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private olatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Danilo",
                LastName = "Urtado",
                Address = "Ilha dos Moleques",
                Gender = "Discutivel"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {

                Id = IncrementAndGet(),
                FirstName = "Danilo Jr" + i,
                LastName = "Pererinha" + i,
                Address = "Ilha dos Moleques, n°" + i,
                Gender = "Discutivel"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);

        }
    }
}
