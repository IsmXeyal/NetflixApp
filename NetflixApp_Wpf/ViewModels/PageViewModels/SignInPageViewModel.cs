using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.Services;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class SignInPageViewModel : NotificationService
{
    public SignInPageView? SignInPageView { get; set; }
    public Person? CurrentPerson { get; set; } = new();
    public ICommand? SignInCommand { get; set; }
    public ICommand? ForgotPasswordCommand { get; set; }
    public ICommand? SignUpCommand { get; set; }
    public ICommand? ExitCommand { get; set; }

    NetflixDbContext context = new();
    public SignInPageViewModel(SignInPageView signInPageView)
    {
        SignInPageView = signInPageView;

        ForgotPasswordCommand = new RelayCommand(
                action =>
                {
                    ForgotPasswordPageView forgotPasswordPage = new();
                    SignInPageView?.NavigationService.Navigate(forgotPasswordPage);
                },
                pre => true);

        ExitCommand = new RelayCommand(
               action =>
               {
                   Application.Current.Shutdown();
               },
               pre => true
               );

        SignUpCommand = new RelayCommand(
                action =>
                {
                    SignUpPageView SignUpPage = new();
                    SignInPageView?.NavigationService.Navigate(SignUpPage);
                },
                pre => true);

        SignInCommand = new RelayCommand(
                action =>
                {
                    if (SignInPageView.tbEmail.Text == string.Empty || SignInPageView.pbPassword.Password == string.Empty)
                        notifier.ShowInformation("Please fill in the information completely.");
                    else if (!Regex.IsMatch(SignInPageView.tbEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                        notifier.ShowInformation("Please enter a valid email address.");
                    else if (context.People.Any(u => u.Email == SignInPageView.tbEmail.Text && u.Password == SignInPageView.pbPassword.Password))
                    {
                        CurrentPerson = context.People.FirstOrDefault(u => u.Email == SignInPageView.tbEmail.Text && u.Password == SignInPageView.pbPassword.Password);
                        notifier.ShowSuccess("The entry was successful. We'll take you to the main page in a few seconds.");
                        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                        timer.Start();
                        timer.Tick += (sender, args) =>
                        {
                            timer.Stop();

                            MovieView_ movieView_ = new(CurrentPerson, 0);
                            SignInPageView?.NavigationService.Navigate(movieView_);
                        };
                    }
                    else if (context.People.Any(u => u.Email == SignInPageView.tbEmail.Text && u.Password != SignInPageView.pbPassword.Password))
                        notifier.ShowWarning("Incorrect password. Please try again.");
                    else
                        notifier.ShowWarning("Couldn’t find a Netflix account associated with this email. Please try again.");
                },
                pre => true);
    }

    Notifier notifier = new(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopRight,
            offsetX: 425,
            offsetY: 85);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(2),
            maximumNotificationCount: MaximumNotificationCount.FromCount(2));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
}
