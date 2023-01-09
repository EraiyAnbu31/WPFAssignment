using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Assignment.View.Model;
using Assignment.View.Reposotories;
using System.Net;
using System.Threading;
using System.Security.Principal;
using Assignment.View.View;

namespace Assignment.View.ViewModel
{
    internal class LoginViewModel:ViewModelBase
    {
        //fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible=true;

        private IUserRepository userRepository;

        //properties
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
       // commands
       public ICommand LoginCommand { get; }
       public ICommand RecoverPasswordCommand { get; }
       public ICommand ShowPasswordCommand { get; }
       public ICommand RememberPasswordCommand { get; }
       public ICommand RegisterCommand { get; }


     //constructor
     public LoginViewModel()
        {
            userRepository= new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, canExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("",""));
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            Window1 win1 = new Window1();
            win1.Close();
            Window2 win2= new Window2();
            win2.Show();

        }

        private bool canExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(Username)|| Username.Length<3 || Password==null || 
                Password.Length<3)
                validData= false;
            else
                validData= true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if ((bool)isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username),null);
                IsViewVisible= false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
