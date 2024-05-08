using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ground2Plate.Maui.Services;
using Ground2Plate.Maui.UserControls;
using Ground2Plate.Maui.Views;
using Ground2Plate.Models;
using Newtonsoft.Json;

namespace Ground2Plate.Maui.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        private readonly ILoginRepository _loginService = new LoginService();

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Local)
                {
                    if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                    {
                        User user = await _loginService.Login(Email, Password);
                        if (user == null)
                        {
                            await Shell.Current.DisplayAlert("Error", "Username/Password is incorrect", "Ok");
                            return;
                        }
                        if (Preferences.ContainsKey(nameof(App.user)))
                        {
                            Preferences.Remove(nameof(App.user));
                        }
                        string userDetails = JsonConvert.SerializeObject(user);
                        Preferences.Set(nameof(App.user), userDetails);
                        App.user = user;
                        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                        await Shell.Current.GoToAsync(nameof(HomePage));
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                        return;
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No Internet Access", "Ok");
                    return;
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}

