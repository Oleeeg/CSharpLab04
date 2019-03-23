namespace CSharpLab04
{
    public class PersonManager
    {
        readonly PersonRepository _personRepository;
        public PersonManager()
        {
            _personRepository = new PersonRepository();
        }

        public bool Add(Person person)
        {
            return true;
        }
    }
}
