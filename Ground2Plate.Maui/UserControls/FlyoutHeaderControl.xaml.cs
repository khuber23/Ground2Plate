namespace Ground2Plate.Maui.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
        if (App.user != null)
        {
            lblUserName.Text = "Logged in as: " + App.user.Name;
            lblUserEmail.Text = App.user.Email;
        }

    }
}