using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDomainLayer.Entities.Concretes;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NetflixApp_Wpf.Views.Pages;

public partial class IntroScreenPageView : Page
{
    public Person? CurrentPerson { get; set; }

    NetflixDbContext context = new();

    public IntroScreenPageView()
    {
        InitializeComponent();
        try
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(150) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                if (pbInput.Value >= 100)
                {
                    timer.Stop();
                    string currentUserEmailFilePath = "../../../DTOs/CurrentPersonEmail.txt";

                    if (File.Exists(currentUserEmailFilePath))
                    {
                        string userEmail = File.ReadAllText(currentUserEmailFilePath);
                        CurrentPerson = context.People.FirstOrDefault(x => x.Email == userEmail);
                        NavigationService?.Navigate(new MovieView_(CurrentPerson!, 0));
                    }
                    else
                    {
                        NavigationService?.Navigate(new SignInPageView());
                    }
                }
                else if (pbInput.Value < 30)
                    pbInput.Value += 1;
                else
                    pbInput.Value += 10;
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
