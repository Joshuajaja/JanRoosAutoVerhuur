using JanRoosAutoVerhuur.Viewmodel;

namespace JanRoosAutoVerhuur;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}