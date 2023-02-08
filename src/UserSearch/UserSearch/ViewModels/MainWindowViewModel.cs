using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using UserSearch.Models;
using UserSearch.Services;
namespace UserSearch.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly IRepository<User, int> _repository = new UserRepository(
            new XmlSerializationService()
        );
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public ICommand InitalizeUsers => new RelayCommand(() => LoadUsers(), () => true);
        public ICommand SearchByFirstNameCommand =>
            new RelayCommand(() => SearchUsersByFirstName(), () => true);
        public ICommand SearchByLastNameCommand =>
            new RelayCommand(() => SearchUsersByLastName(), () => true);
        public ICommand SearchByFirstAndLastNameCommand =>
            new RelayCommand(() => SearchUsersByFirstAndLastName(), () => true);
        public ICommand SearchByEmailCommand =>
            new RelayCommand(() => SearchUsersByEmail(), () => true);

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        private void SearchUsersByFirstName()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                MessageBox.Show(
                    "The first name field can not be empty when searching by first name."
                );
                return;
            }
            Users.Clear();
            var firstName = FirstName.ToLowerInvariant().Trim();
            var users =
                from user in _repository.GetAll()
                where user.FirstName.ToLowerInvariant() == firstName
                select user;
            foreach (var user in users.ToArray())
            {
                Users.Add(user);
            }
        }

        private void SearchUsersByLastName()
        {
            if (string.IsNullOrEmpty(LastName))
            {
                MessageBox.Show(
                    "The last name field can not be empty when searching by last name."
                );
                return;
            }
            Users.Clear();
            var lastName = LastName.ToLowerInvariant().Trim();
            var users =
                from user in _repository.GetAll()
                where user.LastName.ToLowerInvariant() == lastName
                select user;
            foreach (var user in users.ToArray())
            {
                Users.Add(user);
            }
        }
        private void SearchUsersByFirstAndLastName()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                MessageBox.Show(
                    "The first name field can not be empty when searching by first and last name."
                );
                return;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                MessageBox.Show(
                    "The last name field can not be empty when searching by first and name."
                );
                return;
            }
            Users.Clear();
            var firstName = FirstName.ToLowerInvariant().Trim();
            var lastName = LastName.ToLowerInvariant().Trim();
            var users =
                from user in _repository.GetAll()
                where
                    user.FirstName.ToLowerInvariant() == firstName
                    && user.LastName.ToLowerInvariant() == lastName
                select user;
            foreach (var user in users.ToArray())
            {
                Users.Add(user);
            }
        }
        private void SearchUsersByEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("The email field can not be empty when searching by email.");
                return;
            }
            var email = Email.ToLowerInvariant().Trim();
            var users =
                from user in _repository.GetAll()
                where user.Email.ToLowerInvariant() == email
                select user;
            Users.Clear();
            foreach (var user in users.ToArray())
            {
                Users.Add(user);
            }
        }

        private void LoadUsers()
        {
            _repository.GetAll().ToList().ForEach(Users.Add);
        }
    }
}

