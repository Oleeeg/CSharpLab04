using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static CSharpLab04.PersonException;

namespace CSharpLab04
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        private readonly Person _person;
        private readonly Action<bool> _showLoaderAction;
        public PersonViewModel(Action<bool> showLoader)
        {
            _person = new Person();
            new PersonManager();
            Persons = new ObservableCollection<Person>(DBAdapter.allThePeople);
            AddPersonCmd = new RelayCommand(Add);
            EditPersonCmd = new RelayCommand(Edit);
            SavePersonCmd = new RelayCommand(Save);
            DeletePersonCmd = new RelayCommand(Delete);
            _showLoaderAction = showLoader;
        }
        public PersonViewModel()
        {
            _person = new Person();
            new PersonManager();
            Persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add);
        }
        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string LastName
        {
            get => _person.LastName;
            set
            {
                _person.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Email
        {
            get => _person.Email;
            set
            {
                _person.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                _person.DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public bool IsAdult => _person.IsAdult;
        public string SunSign => _person.SunSign;
        public string ChineseSign => _person.ChineseSign;
        public bool IsBirthday => _person.IsBirthday;

        public ObservableCollection<Person> Persons { get; }
        public ICommand AddPersonCmd { get; }
        public ICommand EditPersonCmd { get; }
        public ICommand SavePersonCmd { get; }
        public ICommand DeletePersonCmd { get; }
        public Person SelectedItem { get; set; }
        public async void Add(object obj)
        {
            _showLoaderAction.Invoke(true);

            await Task.Run((() =>
            {
                Thread.Sleep(2000);
            }));
            try
            {
                if ((LastName == string.Empty) || (LastName.Length < 2) || (Regex.IsMatch(LastName, "[^a-zA-Z]")))
                {
                    throw new InvalidLastNameException(LastName);
                }
                if ((Name == string.Empty) || (Name.Length < 2) || (Regex.IsMatch(Name, "[^a-zA-Z]")))
                {
                    throw new InvalidNameException(Name);
                }
                if (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new InvalidEmailAddressException(Email);
                }
                if ((DateTime.Today.Year - _person.DateOfBirth.Year) > 135)
                {
                    throw new InvalidDDate(_person.DateOfBirth);
                }
                if (DateTime.Today.Year == _person.DateOfBirth.Year)
                {
                    if (DateTime.Today.DayOfYear < _person.DateOfBirth.DayOfYear)
                    {
                        throw new InvalidFDate(_person.DateOfBirth);
                    }
                }
                var person = new Person { LastName = LastName, Name = Name, Email = Email, DateOfBirth = DateOfBirth };
                DBAdapter.AddPerson(LastName, Name, Email, DateOfBirth);
                Persons.Add(person);
                if (person.DateOfBirth.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("Hey, you! HAPPYYYY BIRTHDAY!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ResetPerson();
            _showLoaderAction.Invoke(false);
        }

        public void Edit(object obj)
        {
            SetPerson(SelectedItem);
        }

        public void Save(object obj)
        {
            try
            {
                if ((LastName == string.Empty) || (LastName.Length < 2) || (Regex.IsMatch(LastName, "[^a-zA-Z]")))
                {
                    throw new InvalidLastNameException(LastName);
                }
                if ((Name == string.Empty) || (Name.Length < 2) || (Regex.IsMatch(Name, "[^a-zA-Z]")))
                {
                    throw new InvalidNameException(Name);
                }
                if (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new InvalidEmailAddressException(Email);
                }
                if ((DateTime.Today.Year - _person.DateOfBirth.Year) > 135)
                {
                    throw new InvalidDDate(_person.DateOfBirth);
                }
                if (DateTime.Today.Year == _person.DateOfBirth.Year)
                {
                    if (DateTime.Today.DayOfYear < _person.DateOfBirth.DayOfYear)
                    {
                        throw new InvalidFDate(_person.DateOfBirth);
                    }
                }

                SelectedItem.LastName = LastName;
                SelectedItem.Name = Name;
                SelectedItem.Email = Email;
                SelectedItem.DateOfBirth = DateOfBirth;
                if (DateOfBirth.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("Hey, you! HAPPYYYY BIRTHDAY!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ResetPerson();
        }
        public void Delete(object obj)
        {
            Persons.Remove(SelectedItem);
            DBAdapter.allThePeople.Remove(SelectedItem);
        }

        private void ResetPerson()
        {
            LastName = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
        }
        private void SetPerson(Person p)
        {
            LastName = p.LastName;
            Name = p.Name;
            Email = p.Email;
            DateOfBirth = p.DateOfBirth;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

