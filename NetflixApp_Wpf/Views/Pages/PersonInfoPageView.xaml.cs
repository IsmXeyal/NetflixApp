using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class PersonInfoPageView : Page
{
    public PersonInfoPageView(Person person)
    {
        InitializeComponent();
        DataContext = new PersonInfoPageViewModel(this, person);
    }
}
