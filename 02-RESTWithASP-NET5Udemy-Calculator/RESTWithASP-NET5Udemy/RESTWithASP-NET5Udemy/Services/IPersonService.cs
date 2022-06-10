﻿using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Services
  
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}