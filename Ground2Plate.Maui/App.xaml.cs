using Ground2Plate.Maui.Resources.Themes;
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

        protected override void OnStart()
        {
            base.OnStart();
            ThemeManager.Initialize();
        }
    }
}
