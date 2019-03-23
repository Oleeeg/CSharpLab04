using System.Collections.Generic;

namespace CSharpLab04
{ 
    public class PersonRepository
    {
        private static readonly List<Person> Persons = new List<Person>();
     
        internal void Add(Person person)
        {
            Persons.Add(person);
        }
        internal void Remove(Person person)
        {
            Persons.Remove(person);
        }

    }
}

