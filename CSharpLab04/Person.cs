using System;

namespace CSharpLab04
{
    [Serializable]
    public class Person
    {
        internal const string Filename = "PeopleBase.dat";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        private static String[] chineseHor = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", };
        private static String[] sunSign = { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pieces" };

        public bool IsAdult => IsAdultAlready();
        public bool IsBirthday => IsBirthdayToday();
        public string ChineseSign => FindChineseSign();
        public string SunSign => FindSunSign();

        public Person(string name, string lastName, string email, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Person(string name, string lastName, string email) : this(name, lastName, email, DateTime.Today)
        {
        }

        public Person(string name, string lastName, DateTime dateOfBirth) : this(name, lastName, "no info", dateOfBirth)
        {
        }

        public Person()
        {
            DateOfBirth = DateTime.Today;
        }

        private bool IsAdultAlready()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (today.DayOfYear < DateOfBirth.DayOfYear) age--;
            return age >= 18;
        }

        private bool IsBirthdayToday()
        {
            DateTime today = DateTime.Today;
            return today.DayOfYear == DateOfBirth.DayOfYear;
        }

        private string FindChineseSign()
        {
            return chineseHor[DateOfBirth.Year % 12];
        }

        private string FindSunSign()
        {
            string sign = "";
            if (((DateOfBirth.Month == 1) && (DateOfBirth.Day >= 20 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 2) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 17)))) sign = sunSign[10];
            if (((DateOfBirth.Month == 2) && (DateOfBirth.Day >= 18 && (DateOfBirth.Day <= 28)) || ((DateOfBirth.Month == 3) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 19)))) sign = sunSign[11];
            if (((DateOfBirth.Month == 3) && (DateOfBirth.Day >= 20 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 4) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 19)))) sign = sunSign[0];
            if (((DateOfBirth.Month == 4) && (DateOfBirth.Day >= 20 && (DateOfBirth.Day <= 30)) || ((DateOfBirth.Month == 5) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 20)))) sign = sunSign[1];
            if (((DateOfBirth.Month == 5) && (DateOfBirth.Day >= 21 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 6) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 20)))) sign = sunSign[2];
            if (((DateOfBirth.Month == 6) && (DateOfBirth.Day >= 21 && (DateOfBirth.Day <= 30)) || ((DateOfBirth.Month == 7) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 22)))) sign = sunSign[3];
            if (((DateOfBirth.Month == 7) && (DateOfBirth.Day >= 23 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 8) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 22)))) sign = sunSign[4];
            if (((DateOfBirth.Month == 8) && (DateOfBirth.Day >= 23 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 9) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 22)))) sign = sunSign[5];
            if (((DateOfBirth.Month == 9) && (DateOfBirth.Day >= 23 && (DateOfBirth.Day <= 30)) || ((DateOfBirth.Month == 10) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 22)))) sign = sunSign[6];
            if (((DateOfBirth.Month == 10) && (DateOfBirth.Day >= 23 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 11) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 21)))) sign = sunSign[7];
            if (((DateOfBirth.Month == 11) && (DateOfBirth.Day >= 22 && (DateOfBirth.Day <= 30)) || ((DateOfBirth.Month == 12) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 19)))) sign = sunSign[8];
            if (((DateOfBirth.Month == 12) && (DateOfBirth.Day >= 20 && (DateOfBirth.Day <= 31)) || ((DateOfBirth.Month == 1) && (DateOfBirth.Day >= 1 && DateOfBirth.Day <= 19)))) sign = sunSign[9];
            return sign;
        }
    }
}