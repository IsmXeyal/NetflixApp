using NetflixApp_Wpf.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class SignUpPageView : Page
{
    public SignUpPageView()
    {
        InitializeComponent();
        DataContext = new SignUpPageViewModel(this);
    }
}
