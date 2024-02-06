using NetflixApp_Wpf.ViewModels.WindowViewModels;
using NetflixApp_Wpf.Views.Windows;
using System.Windows;

namespace NetflixApp_Wpf;

public partial class App : Application
{
    private void Main(object sender, StartupEventArgs e)
    {
        var mainview = new MainView
        {
            DataContext = new MainViewModel()
        };
        mainview.ShowDialog();
    }
}
