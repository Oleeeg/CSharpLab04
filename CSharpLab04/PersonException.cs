using System;

namespace CSharpLab04
{
    class PersonException : Exception
    {
        public PersonException(string message) : base(message) { }

        public class InvalidNameException : PersonException
        {
            internal InvalidNameException(string name) : base(name + " - can't be someone's name.") { }
        }

        public class InvalidLastNameException : Exception
        {
            internal InvalidLastNameException(string lastName) : base(lastName + " - can't be someone's last name.") { }
        }

        public class InvalidEmailAddressException : Exception
        {
            internal InvalidEmailAddressException(string email) : base(email + " - invalid email address.") { }
        }

        public class InvalidDDate : Exception
        {
            internal InvalidDDate(DateTime date) : base(date.ToShortDateString() + " - incorrect date. The person who wast born that day must be dead now.") { }
        }

        public class InvalidFDate : Exception
        {
            internal InvalidFDate(DateTime date) : base(date.ToShortDateString() + " - incorrect date. This day hasn't come yet.") { }
        }
    }
}
