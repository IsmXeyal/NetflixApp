using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Services.Validations;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppBusinessLogicLayer.Network;
using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDataAccessLayer.Repositories.Concretes;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class SignUpPageViewModel
{
    public SignUpPageView? SignUpPageView { get; set; }
    private Random _randomCode { get; set; }
    public ICommand? SignInBackCommand { get; set; }
    public ICommand? SignUpPCommand { get; set; }
    public ICommand? BackCommand { get; set; }
    public ICommand? SendCodeEmailCommand { get; set; }

    NetflixDbContext context = new();
    public SignUpPageViewModel(SignUpPageView signUpPageView)
    {
        SignUpPageView = signUpPageView;
        _randomCode = new Random();
        int regCode = _randomCode.Next(10000, 99999);

        // Ensure that only numeric input is allowed in the text box
        SignUpPageView.tbregisterCode.PreviewTextInput += NumberValidationTextBox;

        BackCommand = new RelayCommand(
                action =>
                {
                    var signInPage = new SignInPageView();
                    SignUpPageView?.NavigationService?.Navigate(signInPage);
                },
                pre => true);

        SignInBackCommand = BackCommand;

        SignUpPCommand = new RelayCommand(
                action =>
                {
                    if (string.IsNullOrWhiteSpace(SignUpPageView.tbFirstname.Text) || string.IsNullOrWhiteSpace(SignUpPageView.tbLastname.Text) ||
                        string.IsNullOrWhiteSpace(SignUpPageView.tbPhoneNumber.Text) || string.IsNullOrWhiteSpace(SignUpPageView.tbEmail.Text) ||
                        string.IsNullOrWhiteSpace(SignUpPageView.pbPassword.Password) || string.IsNullOrWhiteSpace(SignUpPageView.pbConfirmPassword.Password) ||
                        string.IsNullOrWhiteSpace(SignUpPageView.tbUsername.Text))
                    {
                        notifier.ShowInformation("Please fill in the information completely.");
                    }
                    else if (SignUpPageView.pbPassword.Password.Length < 8)
                    {
                        notifier.ShowWarning("Password must be at least 8 characters.");
                    }
                    else if (SignUpPageView.pbPassword.Password != SignUpPageView.pbConfirmPassword.Password)
                    {
                        notifier.ShowWarning("Passwords are not the same.Try again.");
                        signUpPageView.pbPassword.Password = string.Empty;
                        signUpPageView.pbConfirmPassword.Password = string.Empty;
                    }
                    else if (SignUpPageView.tbregisterCode.Text != regCode.ToString())
                    {
                        notifier.ShowWarning("Please write the code which is sent to the email correctly.");
                    }
                    else if (ErrorService.IsError == true)
                    {
                        notifier.ShowWarning("Please enter the information correctly.");
                    }
                    else if (context.People.Any(u => u.Username == SignUpPageView.tbUsername.Text))
                    {
                        notifier.ShowWarning("There is already an account with this username. Please check another username.");
                        SignUpPageView.tbUsername.Text = "";
                    }
                    else if (context.People.Any(u => u.Email == SignUpPageView.tbEmail.Text))
                    {
                        notifier.ShowWarning("There is already an account with this email. Please check another email.");
                        SignUpPageView.tbEmail.Text = "";
                    }
                    else
                    {
                        PersonDTO newPersonDto = new()
                        {
                            Firstname = SignUpPageView.tbFirstname.Text,
                            Lastname = SignUpPageView.tbLastname.Text,
                            Username = SignUpPageView.tbUsername.Text,
                            PhoneNumber = SignUpPageView.tbPhoneNumber.Text,
                            Image = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png",
                            Email = SignUpPageView.tbEmail.Text,
                            Password = SignUpPageView.pbPassword.Password,
                            FavsListEditor = new ObservableCollection<EditorChoiceDTO>(),
                            FavsListMovie = new ObservableCollection<MovieTvShowDTO>(),
                            AddListEditor = new ObservableCollection<EditorChoiceDTO>(),
                            AddListMovie = new ObservableCollection<MovieTvShowDTO>()
                        };
                        
                        try
                        {
                            PersonRepository personRepository = new();
                            Person newPerson = ConvertToPerson(newPersonDto);
                            personRepository.Add(newPerson);
                            personRepository.SaveChanges();
                            notifier.ShowSuccess("Successfully register.\nWe will direct you to the sign in page for a few seconds.");
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError("Error adding user to database: " + ex.Message);
                        }

                        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                        timer.Start();
                        timer.Tick += (sender, args) =>
                        {
                            timer.Stop();
                            SignInPageView signInPage = new();
                            SignUpPageView.NavigationService.Navigate(signInPage);
                        };
                    }
                },
                pre => true);

        SendCodeEmailCommand = new RelayCommand(
                action =>
                {
                    if (string.IsNullOrWhiteSpace(SignUpPageView.tbFirstname.Text) || string.IsNullOrWhiteSpace(SignUpPageView.tbLastname.Text) ||
                        string.IsNullOrWhiteSpace(SignUpPageView.tbPhoneNumber.Text) || string.IsNullOrWhiteSpace(SignUpPageView.tbEmail.Text) ||
                        string.IsNullOrWhiteSpace(SignUpPageView.pbPassword.Password) || string.IsNullOrWhiteSpace(SignUpPageView.pbConfirmPassword.Password) ||
                        string.IsNullOrWhiteSpace(SignUpPageView.tbUsername.Text))
                    {
                        notifier.ShowInformation("Please fill in the information completely.");
                    }
                    else if (SignUpPageView.pbPassword.Password.Length < 8)
                    {
                        notifier.ShowWarning("Password must be at least 8 characters.");
                    }
                    else if (SignUpPageView.pbPassword.Password != SignUpPageView.pbConfirmPassword.Password)
                    {
                        notifier.ShowWarning("Passwords are not the same. Try again.");
                        signUpPageView.pbPassword.Password = string.Empty;
                        signUpPageView.pbConfirmPassword.Password = string.Empty;
                    }
                    else if (ErrorService.IsError == true)
                    {
                        notifier.ShowWarning("Please enter the information correctly.");
                    }
                    else if (context.People.Any(u => u.Username == SignUpPageView.tbUsername.Text))
                    {
                        notifier.ShowWarning("There is already an account with this username. Please check another username.");
                        SignUpPageView.tbUsername.Text = "";
                    }
                    else if (context.People.Any(u => u.Email == SignUpPageView.tbEmail.Text))
                    {
                        notifier.ShowWarning("There is already an account with this email. Please check another email.");
                        SignUpPageView.tbEmail.Text = "";
                    }
                    else
                    {
                        try
                        {
                            SignUpPageView.btnSendCode.Visibility = Visibility.Hidden;
                            SignUpPageView.tbregisterCode.IsEnabled = true;
                            notifier.ShowInformation("Enter the code sent to your email as a registration code.");

                            string regmessage = $"\t\t\t\t Attention!!\nDo not share this registration code with anyone! => {regCode}";
                            NetWork.SendNotification(SignUpPageView.tbEmail.Text, "Register Code", regmessage);
                            SignUpPageView.btnSignUp.IsEnabled = true;
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError(ex.Message);
                        }
                    }
                },
                pre => true);
    }

    #region Create notifier
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
    #endregion

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private Person ConvertToPerson(PersonDTO personDto)
    {
        return new Person
        {
            Firstname = personDto.Firstname,
            Lastname = personDto.Lastname,
            Username = personDto.Username,
            PhoneNumber = personDto.PhoneNumber,
            Email = personDto.Email,
            Image = personDto.Image,
            Password = personDto.Password,
        };
    }
}
