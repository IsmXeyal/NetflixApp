using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class WatchMovieView : Page
{
    public WatchMovieView(Person person, int value, int langId, int type)
    {
        InitializeComponent();
        if(type == 1)
        {
            DataContext = new WatchMovieViewModel(this, person, value, langId, type);
            webView.Url = ((WatchMovieViewModel)DataContext).SelectedMovie?.Imdb_link;
        }
        else if(type == 2)
        {
            DataContext = new WatchTvShowViewModel(this, person, value, langId, type);
            webView.Url = ((WatchTvShowViewModel)DataContext).SelectedMovie?.Imdb_link;
            this.btn_play.IsEnabled = false;
            this.YearT.Width = 400;
            this.YearT.Margin = new System.Windows.Thickness(280,- 10, 0, 0);
        }
    }
}
