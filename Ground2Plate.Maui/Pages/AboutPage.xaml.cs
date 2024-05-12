using Ground2Plate.Maui.ViewModels;

namespace Ground2Plate.Maui.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}