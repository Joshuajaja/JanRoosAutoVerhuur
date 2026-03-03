    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Services;

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
                    PasswordEntry = null;
                    UsernameEntry = null;

                    var service = new CarApiService();
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
                    var account = new _Accounts
                    {
                        Username = Username,
                        Password_hash = Password,
                        Birthdate = Birthdate,
                        Created_at = DateTime.Now
                    };
                await service.CreateAccountAsync(account);
                await Shell.Current.GoToAsync($"//MainPage", userInfo);
            }
            }
        }
