using Ground2Plate.Models;

namespace Ground2Plate.Maui
{
    public partial class App : Application
    {
        public static User? user;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
