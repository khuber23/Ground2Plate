namespace Ground2Plate.Maui.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
        if (App.user != null)
        {
            lblUserName.Text = "Welcome " + App.user.Name;
        }

    }
}