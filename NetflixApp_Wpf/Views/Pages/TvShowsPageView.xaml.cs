using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class TvShowsPageView : Page
{
    public TvShowsPageView(Person currentPerson, string? commandd)
    {
        InitializeComponent();
        DataContext = new TvShowsPageViewModel(this, currentPerson, commandd);
    }
}