
using JanRoosAutoVerhuur.Viewmodel;

namespace JanRoosAutoVerhuur;

public partial class Signup : ContentPage
{
	public Signup()
	{
		InitializeComponent();
        BindingContext = new SignUpViewModel();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
    }
}