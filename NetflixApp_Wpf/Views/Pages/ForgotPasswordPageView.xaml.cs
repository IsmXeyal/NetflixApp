using NetflixApp_Wpf.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;

public partial class ForgotPasswordPageView : Page
{
    public ForgotPasswordPageView()
    {
        InitializeComponent();
        DataContext = new ForgotPasswordPageViewModel(this);
    }
}
