using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ground2Plate.Maui.UserControls;
using Ground2Plate.Maui.Pages;
using Ground2Plate.Models;
using Newtonsoft.Json;
using Ground2Plate.Maui.Services.Login;

namespace Ground2Plate.Maui.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        private readonly ILoginService _loginService;

        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
   
        private string _selectedTheme = ThemeManager.SelectedTheme;
        public string SelectedTheme { 
            get => _selectedTheme;  
            set
            {
                if(value != _selectedTheme)
                {
                    _selectedTheme = value;
                    OnPropertyChanged(nameof(SelectedTheme));   
                }
            }
        }

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

        [RelayCommand]
        public async Task ChangeTheme()
        {
             var newTheme = await Shell.Current.DisplayActionSheet("Choose Theme", "Cancel", null, ThemeManager.ThemeNames);
            if(!string.IsNullOrEmpty(newTheme) && newTheme != "Cancel")
            {
                ThemeManager.SetTheme(newTheme);
            }
        }

        public void ThemeManager_SelectedThemeChanged(object sender, EventArgs e)
        {
            SelectedTheme = ThemeManager.SelectedTheme;
        }
    }
}

