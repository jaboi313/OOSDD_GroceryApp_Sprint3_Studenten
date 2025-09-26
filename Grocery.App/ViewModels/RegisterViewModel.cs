using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using Grocery.Core.Exceptions;
using Grocery.App.Views;

namespace Grocery.App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly GlobalViewModel _global;

        [ObservableProperty]
        private string email = "new_user@fake_mail.com";

        [ObservableProperty]
        private string password = "New_user_password!01";

        [ObservableProperty]
        private string name = "new_user_name";

        [ObservableProperty]
        private string errorMessage = "";

        public RegisterViewModel(IAuthService authService, GlobalViewModel global)
        {
            _authService = authService;
            _global = global;
        }

        [RelayCommand]
        private void Register()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Email))
                ErrorMessage += "Email mag niet leeg zijn. ";

            if (string.IsNullOrWhiteSpace(Name))
                ErrorMessage += "Naam mag niet leeg zijn. ";

            if (string.IsNullOrWhiteSpace(Password))
                ErrorMessage += "Wachtwoord mag niet leeg zijn. ";
            
            if (ErrorMessage != "")
                return;

            try
            {
                Client client = _authService.Register(Email, Password, Name);

                _global.Client = client;
                Application.Current.MainPage = new AppShell();
            }
            catch (UsedEmailException _)
            {
                ErrorMessage = "Emailadres is ongeldig of al in gebruik.";
            }
            catch (InvalidEmailException _)
            {
                ErrorMessage = "Emailadres is ongeldig of al in gebruik.";
            }
            catch (InvalidPasswordException _)
            {
                ErrorMessage = "Wachtwoord moet minimaal 8 tekens bevatten, waaronder een hoofdletter, kleine letter, cijfer en speciaal teken.";
            }
            catch (Exception _)
            {
                ErrorMessage = "Er is iets mis gegaan met het registreren.";
            }
        }
    }
}
