using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Condi.DBStorage;

namespace Condi.ViewModel
{
    public class EmployeeVM : BaseViewModel
    {
        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private int _postId;
        public int PostId
        {
            get => _postId;
            set
            {
                _postId = value;
                OnPropertyChanged(nameof(PostId));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        private string _lastname;
        public string LastName
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private bool _isAutheticated;
        public bool IsAutheticated
        {
            get => _isAutheticated;
            set
            {
                _isAutheticated = value;
                OnPropertyChanged(nameof(IsAutheticated));
            }
        }

        private bool Authetication(string login, string password)
        {
            using (var db = new CondiEntities())
            {
                var res = db.Employee.FirstOrDefault(e => e.Login == login && e.Password == password);
                if (res!=null)
                {
                    _employee = res;
                    _postId = res.PostId;
                    _id = res.Id;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AuthInApp()
        {
            var res = Authetication(Login, Password);
            if (res)
            {
                IsAutheticated = true;
                if (PostId == 1)
                {
                    MainWindow mw = new MainWindow(this);
                    mw.Show();
                }
                else if (PostId == 2)
                {
                    MainWindow mw = new MainWindow(this);
                    mw.Show(); 
                }
                else if (PostId == 3)
                {
                    MainWindow mw = new MainWindow(this);
                    mw.Show();
                }
                else if (PostId == 4)
                {
                    MainWindow mw = new MainWindow(this);
                    mw.Show();
                }
                else
                {
                    MessageBox.Show("Во время авторизации произошла ошибка\nПожалуйста, обратитесь к администратору", "Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                IsAutheticated = false;
                MessageBox.Show("Во время авторизации произошла ошибка\nПожалуйста, проверьте корректность введенных данных","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
