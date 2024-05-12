using Ground2Plate.Maui.ViewModels;

namespace Ground2Plate.Maui.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}