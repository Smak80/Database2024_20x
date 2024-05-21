using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Database2024
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly User _currentUser = new();

        public string UserName
        {
            get => _currentUser.Name;
            set
            {
                _currentUser.Name = value;
                OnPropertyChanged();
            }
        }

        public uint UserAge
        {
            get => _currentUser.Age;
            set
            {
                _currentUser.Age = value;
                OnPropertyChanged();
            }
        }

        public string UserPosition
        {
            get => _currentUser.Position;
            set
            {
                _currentUser.Position = value;
                OnPropertyChanged();
            }
            
        }

        public float UserSalary
        {
            get => _currentUser.Salary;
            set
            {
                _currentUser.Salary = value;
                OnPropertyChanged();
            }
        }
        private readonly ObservableCollection<User> _users = new ();
        public ObservableCollection<User> Users => _users;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            LoadUsers();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddUser()
        {
            DbHelper.AddUser(_currentUser);
            LoadUsers();
            _currentUser.Clear();
        }

        private void LoadUsers()
        {
            _users.Clear();
            foreach (var user in DbHelper.LoadAll())
            {
                _users.Add(user);
            }
        }
    }

}
