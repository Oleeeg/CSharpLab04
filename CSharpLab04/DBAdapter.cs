using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace CSharpLab04
{
    static class DBAdapter
    {
        public static List<Person> allThePeople { get; }

        static DBAdapter()
        {
            var filepath = Path.Combine(GetAndCreateDataPath(), Person.Filename);
            if (File.Exists(filepath))
            {
                try
                {
                    allThePeople = SerializeHelper.Deserialize<List<Person>>(filepath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get users from file.{Environment.NewLine}{ex.Message}");
                    throw;
                }
            }
            else
            {
                allThePeople = new List<Person>();
                Random rnd = new Random();
                string[] lastNames = {"Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clack", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson",
                "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Philips", "Campbell", "Parker", "Evans", "Edwards", "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey", "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray", "Ramirez", "James", "Watson", "Brooks", "Kelly", "Sanders", "Price" };
                string[] firstNames = {
                "Andrew", "Philip", "Jacob", "Kaleb", "Ryan", "Jason", "Alex", "George", "Hayden", "Tom", "Norman", "Drake", "Ramon", "Damon", "Warren", "Jessica", "Ashley", "Jenny", "Carla", "Nancy", "Chris", "Alyssa", "Holly", "Dakota", "Adam", "Cardi", "Nicki", "Britney", "Lucas", "Maria", "Milo", "Paige", "Bruce", "Monica", "Phoebe", "Matthew", "Madison", "Quinne", "Piper", "Melany", "Sophie", "Sarah", "Zack," +
                "Bree", "Jackson", "Vera", "Alexandra", "Zander", "Marissa", "Carter", "Courtney", "Carly", "Mitchel", "Mike", "Carlos", "Erick", "Tacker", "Sandra", "Bart", "Chuck", "Blake", "Layton", "Blair", "Serena", "Lily", "Marisol", "Irma", "Katty", "Raymond", "Ramon", "Oliver", "Jeremy", "Jared", "Brad", "Duke", "Darvin", "Trip", "Lucky"};

                for (int i = 0; i < lastNames.Length; i++)
                    allThePeople.Add(new Person(firstNames[i], lastNames[i], firstNames[i] + lastNames[i].Substring(0, 1) + "@gmail.com", new DateTime(rnd.Next(DateTime.Today.Year - 75, DateTime.Today.Year - 1), rnd.Next(1, 13), rnd.Next(1, 29))));
            }
        }
        internal static Person AddPerson(string lastName, string firstName, string email, DateTime date)
        {
            Person person = new Person(firstName, lastName, email, date);
            allThePeople.Add(person);
            return person;
        }
        internal static void SaveData()
        {
            SerializeHelper.Serialize(allThePeople, Path.Combine(GetAndCreateDataPath(), Person.Filename));
        }

        private static string GetAndCreateDataPath()
        {
            string dir = StationManager.WorkingDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}
