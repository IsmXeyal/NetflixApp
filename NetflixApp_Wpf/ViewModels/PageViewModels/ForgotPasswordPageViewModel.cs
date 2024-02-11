using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.Services.Validations;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppBusinessLogicLayer.Network;
using NetflixAppDataAccessLayer.Contexts;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class ForgotPasswordPageViewModel
{
    public ForgotPasswordPageView? ForgotPasswordPageView { get; set; }
    public ICommand? BackCommand { get; set; }
    public ICommand? SendCodeForgotPassCommand { get; set; }
    public ICommand? EnterVerifyCommand { get; set; }
    public ICommand? UpdatePassCommand { get; set; }
    private Random _randomCode { get; set; }

    NetflixDbContext context = new();
    public ForgotPasswordPageViewModel(ForgotPasswordPageView forgotPassword)
    {
        ForgotPasswordPageView = forgotPassword;
        _randomCode = new Random();
        int regCode = _randomCode.Next(10000, 99999);

        BackCommand = new RelayCommand(
                action =>
                {
                    var signInPage = new SignInPageView();
                    ForgotPasswordPageView?.NavigationService?.Navigate(signInPage);
                },
                pre => true);

        SendCodeForgotPassCommand = new RelayCommand(
                action =>
                {
                    if (ForgotPasswordPageView.tbEmail.Text == string.Empty)
                        notifier.ShowInformation("Please fill in the blank.");
                    else if (ErrorService.IsError == true)
                        notifier.ShowInformation("Please enter a valid email address.");
                    else if (!context.People.Any(u => u.Email == ForgotPasswordPageView.tbEmail.Text))
                        notifier.ShowWarning("There is not registered gmail like that!");
                    else
                    {
                        forgotPassword.btnSendCode.IsEnabled = false;
                        string regmessage = $"\t\t\t\t Attention!!\nDo not share this registration code with anyone! => {regCode}";
                        NetWork.SendNotification(ForgotPasswordPageView.tbEmail.Text, "Register Code", regmessage);
                        forgotPassword.tbEmail.IsEnabled = false;
                        forgotPassword.tbEmail.Visibility = Visibility.Hidden;
                        forgotPassword.btnSendCode.IsEnabled = false;
                        forgotPassword.btnSendCode.Visibility = Visibility.Hidden;
                        forgotPassword.EnterCode.IsEnabled = true;
                        forgotPassword.EnterCode.Visibility = Visibility.Visible;                
                        forgotPassword.tbVertfCode.IsEnabled = true;
                        forgotPassword.tbVertfCode.Visibility = Visibility.Visible;
                    }
                },
                pre => true);

        EnterVerifyCommand = new RelayCommand(
            action =>
            {
                if (ForgotPasswordPageView.tbVertfCode.Text == "")
                    notifier.ShowInformation("Please enter the verification code.");
                else if (ForgotPasswordPageView.tbVertfCode.Text != regCode.ToString())
                    notifier.ShowWarning("Please write the code sent to the email correctly.");
                else
                {
                    notifier.ShowSuccess("The verification code is correct. You can now enter a new password.");
                    forgotPassword.MyGrid.Height = 270;
                    forgotPassword.tbEmail.IsEnabled = false;
                    forgotPassword.tbEmail.Visibility = Visibility.Hidden;
                    forgotPassword.btnSendCode.IsEnabled = false;
                    forgotPassword.btnSendCode.Visibility = Visibility.Hidden;
                    forgotPassword.EnterCode.IsEnabled = false;
                    forgotPassword.EnterCode.Visibility = Visibility.Hidden;
                    forgotPassword.tbVertfCode.IsEnabled = false;
                    forgotPassword.tbVertfCode.Visibility = Visibility.Hidden;
                    forgotPassword.pbPassword.IsEnabled = true;
                    forgotPassword.pbPassword.Visibility = Visibility.Visible;
                    forgotPassword.pbConfirmPass.IsEnabled = true;
                    forgotPassword.pbConfirmPass.Visibility = Visibility.Visible;
                    forgotPassword.UpdatePass.IsEnabled = true;
                    forgotPassword.UpdatePass.Visibility = Visibility.Visible;
                }
            },
            pre => true);

        UpdatePassCommand = new RelayCommand(
                action =>
                {
                    if (string.IsNullOrWhiteSpace(ForgotPasswordPageView.pbPassword.Password) || string.IsNullOrWhiteSpace(ForgotPasswordPageView.pbConfirmPass.Password))
                    {
                        notifier.ShowInformation("Please fill in the blanks.");
                    }
                    else if (ForgotPasswordPageView.pbPassword.Password.Length < 8)
                    {
                        notifier.ShowWarning("Password must be at least 8 characters.");
                    }
                    else if (ForgotPasswordPageView.pbPassword.Password != ForgotPasswordPageView.pbConfirmPass.Password)
                    {
                        notifier.ShowWarning("Passwords are not the same.Try again...");
                        ForgotPasswordPageView.pbPassword.Password = string.Empty;
                        ForgotPasswordPageView.pbConfirmPass.Password = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            var person = context.People.FirstOrDefault(u => u.Email == ForgotPasswordPageView.tbEmail.Text);
                            person!.Password = forgotPassword.pbPassword.Password;
                            context.SaveChanges();
                            notifier.ShowSuccess("Password changed successfully.");
                            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                            timer.Start();
                            timer.Tick += (sender, args) =>
                            {
                                timer.Stop();
                                SignInPageView signInPage = new();
                                ForgotPasswordPageView.NavigationService.Navigate(signInPage);
                            };
                            ForgotPasswordPageView.UpdatePass.IsEnabled = false;
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError("Error updating password in the database: " + ex.Message);
                        }
                    }
                },
                pre => true);
    }

    Notifier notifier = new(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopRight,
            offsetX: 175,
            offsetY: 35);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(3),
            maximumNotificationCount: MaximumNotificationCount.FromCount(2));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
}
