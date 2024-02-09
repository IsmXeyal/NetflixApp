using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NetflixApp_Wpf.Views.Pages;

public partial class PersonInfoPageView : Page
{
    private DispatcherTimer? timer;
    public PersonInfoPageView(Person person)
    {
        InitializeComponent();
        DataContext = new PersonInfoPageViewModel(this, person);
    }
}
