using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NetflixApp_Wpf.Views.Pages;


public partial class IntroScreenPageView : Page
{
    public IntroScreenPageView()
    {
        InitializeComponent();
        try
        {
            InitializeComponent();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(150) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                if (pbInput.Value >= 100)
                {
                    timer.Stop();
                    //NavigationService?.Navigate(new SignInPageView());
                }
                else if (pbInput.Value < 30)
                    pbInput.Value += 1;
                else
                    pbInput.Value += 10;
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
