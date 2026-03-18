using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JanRoosAutoVerhuur.Viewmodel
{
    partial class LoginViewModel : ObservableObject
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
                await Shell.Current.GoToAsync("//Login");
                return;
            }
            Console.WriteLine("no whitespaces etc, getting user by account");
            
            Task<_Accounts> accountResult = service.GetUserByUsernameAsync<_Accounts>(Username); 
            await accountResult;
            _Accounts account = accountResult.Result;
            Console.WriteLine("got user by account");
            Console.WriteLine("username+password = " + account.Password_hash + account.Username);
            var var = 1;
            if(account.Password_hash != Password)
            {
                Console.WriteLine("password is wrong");
                await Shell.Current.DisplayAlertAsync("Error",
                    "Password or username is invalid.",
                    "OK");
                await Shell.Current.GoToAsync("//Login");
            }
            Console.WriteLine("password is correct");

            var userInfo = new Dictionary<string, object>
                {
                    { "Username", Username},
                    {  "Birthdate", account.Birthdate  }
                };
            Console.WriteLine("going to home page");
            await Shell.Current.GoToAsync("//MainPage", userInfo);
            return;
        }
    }
}
