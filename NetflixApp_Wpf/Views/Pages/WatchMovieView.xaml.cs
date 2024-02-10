using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class WatchMovieView : Page
{
    public WatchMovieView(Person person, int value, int langId)
    {
        InitializeComponent();
        DataContext = new WatchMovieViewModel(this, person, value, langId);
        webView.Url = ((WatchMovieViewModel)DataContext).SelectedMovie?.Imdb_link;
    }
}
