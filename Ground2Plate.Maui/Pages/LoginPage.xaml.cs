using Ground2Plate.Maui.ViewModels;

namespace Ground2Plate.Maui.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}