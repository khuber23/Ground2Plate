using Ground2Plate.Maui.ViewModels;

namespace Ground2Plate.Maui.Pages;

public partial class ContactPage : ContentPage
{
	public ContactPage(ContactPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}