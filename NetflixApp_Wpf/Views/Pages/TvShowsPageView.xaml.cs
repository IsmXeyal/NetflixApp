using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class TvShowsPageView : Page
{
    public Person? CurrentPerson { get; set; }
    public TvShowsPageView(Person currentPerson, string? commandd)
    {
        InitializeComponent();
        CurrentPerson = currentPerson;
        DataContext = new TvShowsPageViewModel(this, currentPerson, commandd);
    }

    private void movieT_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is MovieTvShowDTO movie)
        {
            int rank = movie.Id;
            WatchMovieView watchMovieView;

            if (this.chng_language2.IsChecked == false)
                watchMovieView = new WatchMovieView(CurrentPerson!, rank, 1, 2);
            else
                watchMovieView = new WatchMovieView(CurrentPerson!, rank, 2, 2);

            NavigationService?.Navigate(watchMovieView);
        }
    }
}