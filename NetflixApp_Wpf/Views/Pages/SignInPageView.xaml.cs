using NetflixApp_Wpf.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;


public partial class SignInPageView : Page
{
    public SignInPageView()
    {
        InitializeComponent();
        DataContext = new SignInPageViewModel(this);
    }
}
