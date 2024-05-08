using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Ground2Plate.Maui.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [RelayCommand]
        async Task SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.user)))
            {
                Preferences.Remove(nameof(App.user));
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}

