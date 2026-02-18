using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace JanRoosAutoVerhuur.Viewmodel
{
    public partial class SignUpViewModel : ObservableObject
    {
        [ObservableProperty]
        private string usernameEntry = null;

        [ObservableProperty]
        private string passwordEntry = null;

        [ObservableProperty]
        private string usernamePlaceholder = "Username";

        [ObservableProperty]
        private string passwordPlaceholder = "Password";


        [RelayCommand]
        private void SignUpForm()
        {
            string? Password = PasswordEntry;
            string? Username = UsernameEntry;

            if (Username != null) { }
            else if (Password != null) { }
            else
            {
                // database + insertion / Encryptie nog misschien
            }
        }
    }
}
