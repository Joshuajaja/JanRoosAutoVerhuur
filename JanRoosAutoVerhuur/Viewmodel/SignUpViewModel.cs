using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace JanRoosAutoVerhuur.Viewmodel
{
    public partial class SignUpViewModel : ObservableObject
    {
        [ObservableProperty]
        private string usernameEntry;

        [ObservableProperty]
        private string passwordEntry;

        [ObservableProperty]
        private DateTime birthdate;

        [ObservableProperty]
        private string usernamePlaceholder = "Username";

        [ObservableProperty]
        private string passwordPlaceholder = "Password";


        [RelayCommand]
            private async Task SignUpForm()
            {
                string? Password = PasswordEntry;
                string? Username = UsernameEntry;
                string? dbUser = "user"; //placeholder for retrieved user
                string? dbPassword = "pass"; //placeholder for retrieved password
                string nullErrorMessage = "One of your properties is wrong or not set.";

            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlertAsync("Error",
                    "Username and Password are required.",
                    "OK");
                await Shell.Current.GoToAsync("//Signup");
                return;
            }
            var userInfo = new Dictionary<string, object>
            {
                { "Username", Username }
            };
            await Shell.Current.GoToAsync($"//MainPage", userInfo);
        }
        }
    }
