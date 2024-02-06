using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace NetflixApp_Wpf.Views.Windows;

public partial class MainView : NavigationWindow
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
}
