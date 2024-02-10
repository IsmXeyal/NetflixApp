using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NetflixApp_Wpf.Views.Pages;

public partial class MovieView_ : Page
{
    public Person? CurrentPerson { get; set; }
    private DispatcherTimer? timer;
    public MovieView_(Person currentPerson, int ranking)
    {
        InitializeComponent();
        Loaded += MovieView_Loaded;
        CurrentPerson = currentPerson;
        this.PersonItem.Margin = new Thickness(0, -100, 0, 0);
        this.SettingItem.Margin = new Thickness(0, -20, 0, 0);
        DataContext = new MovieView_Model(this, currentPerson, ranking);
    }

    private void MovieView_Loaded(object sender, RoutedEventArgs e)
    {
        var window = Application.Current.MainWindow;
        timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1) };
        timer.Tick += (sender, args) =>
        {
            // This code will be executed every second
            window.Height = 750;
            window.Width = 1150;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        };
        timer.Start();
    }

    private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
    {
        ButtonOpenMenu.Visibility = Visibility.Collapsed;
        ButtonCloseMenu.Visibility = Visibility.Visible;
    }

    private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
    {
        ButtonOpenMenu.Visibility = Visibility.Visible;
        ButtonCloseMenu.Visibility = Visibility.Collapsed;
    }

    private void movieB_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        //if (sender is Button button && button.DataContext is Movie movie)
        //{
        //    int rank = movie.rank;
        //    WatchMovieView watchMovieView = new(CurrentPerson, rank);
        //    NavigationService?.Navigate(watchMovieView);
        //}
    }
}
