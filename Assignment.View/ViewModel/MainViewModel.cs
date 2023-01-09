using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Assignment.View.Model;
using Assignment.View.Reposotories;
using Assignment.View.View;


namespace Assignment.View.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public ICommand Logoutcommand { get; }
        public UserAccountModel CurrentUserAccount 
        {
            get
            {
               return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            LoadCurrentUserData();
            Logoutcommand = new ViewModelCommand(ExecuteLogoutcommand);

        }

     

        private void ExecuteLogoutcommand(object obj)
        {
            MainWindow mwin = new MainWindow();
            mwin.Hide();
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount = new UserAccountModel()
                {
                  Username = user.Email,
                  DisplayName= $"Welcome {user.FirstName} ",
                };
            }
            else
            {
                MessageBox.Show("Invalid user, Not logged in");
                Application.Current.Shutdown();
            }
        }

        
        }
    }

