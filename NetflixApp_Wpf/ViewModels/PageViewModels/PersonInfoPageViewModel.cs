using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows.Input;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using NetflixAppBusinessLogicLayer.Network;
using System.Windows.Threading;
using ToastNotifications.Messages;
using NetflixApp_Wpf.Services.Validations;
using NetflixAppDataAccessLayer.Contexts;
using Microsoft.Win32;
using NetflixAppBusinessLogicLayer.Services;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class PersonInfoPageViewModel : NotificationService
{
    public PersonInfoPageView? PersonInfoPageVieww { get; set; }
    public ICommand? BackCommand { get; set; }
    public ICommand? SendCodeForgotPassCommand { get; set; }
    public ICommand? EnterVerifyCommand { get; set; }
    public ICommand? UpdatePassCommand { get; set; }
    public ICommand? UpdatePersonCommand { get; set; }
    public ICommand? EditCommand { get; set; }
    public ICommand? AddPhotoCommand { get; set; }
    private Random _randomCode { get; set; }
    private Person? _currentPerson { get; set; }
    public Person? CurrentPerson
    {
        get { return _currentPerson; }
        set { _currentPerson = value; OnPropertyChanged(); }
    }

    NetflixDbContext context = new();
    public PersonInfoPageViewModel(PersonInfoPageView personInfoPageView, Person? currentPerson)
    {

        PersonInfoPageVieww = personInfoPageView;
        CurrentPerson = currentPerson;

        PersonInfoPageVieww.tbName.Text = currentPerson!.Firstname;
        PersonInfoPageVieww.tbSurname.Text = currentPerson.Lastname;
        PersonInfoPageVieww.tbUsername.Text = currentPerson.Username;
        PersonInfoPageVieww.tbPhone.Text = currentPerson.PhoneNumber;
        _randomCode = new Random();
        int regCode = _randomCode.Next(10000, 99999);

        BackCommand = new RelayCommand(
                action =>
                {
                    var movieView = new MovieView_(CurrentPerson!, 0);
                    PersonInfoPageVieww?.NavigationService?.Navigate(movieView);
                },
                pre => true);

        EditCommand = new RelayCommand(
                action =>
                {
                    personInfoPageView.tbName.IsEnabled = true;
                    personInfoPageView.tbSurname.IsEnabled = true;
                    personInfoPageView.tbPhone.IsEnabled = true;
                    personInfoPageView.tbUsername.IsEnabled = true;
                    personInfoPageView.Update.IsEnabled = true;
                    personInfoPageView.btn_add.IsEnabled = true;
                    personInfoPageView.btn_edit.IsEnabled = false;
                    personInfoPageView.myEdit.Visibility = Visibility.Hidden;
                },
                pre => true);

        AddPhotoCommand = new RelayCommand(
                action =>
                {
                    var openFileDialog = new OpenFileDialog
                    {
                        Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*"
                    };
                    if (openFileDialog.ShowDialog() == true)
                    {
                        try
                        {
                            var selectedPerson = context.People.FirstOrDefault(person => person.Email == CurrentPerson!.Email);
                            if (selectedPerson != null)
                            {
                                string selectedImagePath = openFileDialog.FileName;
                                selectedPerson.Image = selectedImagePath;
                                CurrentPerson!.Image = selectedImagePath;
                                context.SaveChanges();
                                OnPropertyChanged(nameof(CurrentPerson));
                                notifier.ShowSuccess("Profile photo updated successfully.");
                            }
                            else
                            {
                                notifier.ShowWarning("Selected person not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError("An error occurred while updating the profile photo: " + ex.Message);
                        }
                    }
                },
                pre => true);

        EnterVerifyCommand = new RelayCommand(
            action =>
            {
                if (PersonInfoPageVieww.tbVertfCode.Text == "")
                    notifier.ShowInformation("Please enter the verification code.");
                else if (PersonInfoPageVieww.tbVertfCode.Text != regCode.ToString())
                    notifier.ShowWarning("Please write the code sent to the email correctly.");
                else
                {
                    notifier.ShowSuccess("The verification code is correct. You can now enter a new password.");
                    personInfoPageView.tbVertfCode.IsEnabled = false;
                    personInfoPageView.tbVertfCode.Visibility = Visibility.Hidden;
                    personInfoPageView.EnterCode.IsEnabled = false;
                    personInfoPageView.EnterCode.Visibility = Visibility.Hidden;
                    personInfoPageView.MyGrid.Height = 350;
                    personInfoPageView.pbPassword.IsEnabled = true;
                    personInfoPageView.pbPassword.Visibility = Visibility.Visible;
                    personInfoPageView.pbConfirmPass.IsEnabled = true;
                    personInfoPageView.pbConfirmPass.Visibility = Visibility.Visible;
                    personInfoPageView.UpdatePass.IsEnabled = true;
                    personInfoPageView.UpdatePass.Visibility = Visibility.Visible;
                }
            },
            pre => true);

        UpdatePersonCommand = new RelayCommand(
                action =>
                {
                    if (PersonInfoPageVieww.tbName.Text == "" || PersonInfoPageVieww.tbSurname.Text == "" || PersonInfoPageVieww.tbPhone.Text == ""
                        || PersonInfoPageVieww.tbUsername.Text == "")
                    {
                        notifier.ShowInformation("Please fill in the information completely.");
                    }
                    else if (ErrorService.IsError == true)
                    {
                        notifier.ShowWarning("Please enter the information correctly.");
                    }
                    else
                    {
                        try
                        {
                            var selectedPerson = context.People.FirstOrDefault(person => person.Email == CurrentPerson!.Email);

                            if (selectedPerson != null)
                            {
                                selectedPerson.PhoneNumber = personInfoPageView.tbPhone.Text;
                                selectedPerson.Lastname = personInfoPageView.tbSurname.Text;
                                selectedPerson.Firstname = personInfoPageView.tbName.Text;
                                selectedPerson.Username = personInfoPageView.tbUsername.Text;
                                context.SaveChanges();
                            }
                            else
                            {
                                notifier.ShowWarning("Selected person not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError("Error updating datas in the database: " + ex.Message);
                        }

                        notifier.ShowSuccess("Datas changed successfully.");
                        PersonInfoPageVieww.tbName.IsEnabled = false;
                        PersonInfoPageVieww.tbSurname.IsEnabled = false;
                        PersonInfoPageVieww.tbPhone.IsEnabled = false;
                        PersonInfoPageVieww.tbUsername.IsEnabled = false;
                        PersonInfoPageVieww.Update.IsEnabled = false;
                        PersonInfoPageVieww.btn_add.IsEnabled = false;
                        personInfoPageView.btn_edit.IsEnabled = true;
                        personInfoPageView.myEdit.Visibility = Visibility.Visible;
                    }
                },
                pre => true);

        UpdatePassCommand = new RelayCommand(
                action =>
                {
                    if (PersonInfoPageVieww.pbPassword.Password == "" || PersonInfoPageVieww.pbConfirmPass.Password == "")
                    {
                        notifier.ShowInformation("Please fill in the blanks.");
                    }
                    else if (PersonInfoPageVieww.pbPassword.Password.Length < 8)
                    {
                        notifier.ShowWarning("Password must be at least 8 characters.");
                    }
                    else if (PersonInfoPageVieww.pbPassword.Password != PersonInfoPageVieww.pbConfirmPass.Password)
                    {
                        notifier.ShowWarning("Passwords are not the same.Try again...");
                        PersonInfoPageVieww.pbPassword.Password = string.Empty;
                        PersonInfoPageVieww.pbConfirmPass.Password = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            var selectedPerson = context.People.FirstOrDefault(person => person.Email == CurrentPerson!.Email);

                            if (selectedPerson != null)
                            {
                                selectedPerson!.Password = personInfoPageView.pbPassword.Password;
                                notifier.ShowSuccess("Password changed successfully.");
                                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };
                                timer.Start();
                                timer.Tick += (sender, args) =>
                                {
                                    timer.Stop();
                                };
                                context.SaveChanges();
                                PersonInfoPageVieww.UpdatePass.IsEnabled = false;
                                PersonInfoPageView personInfo = new(currentPerson);
                                PersonInfoPageVieww.NavigationService.Navigate(personInfo);
                            }
                            else
                            {
                                notifier.ShowWarning("Selected person not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            notifier.ShowError("Error updating password in the database: " + ex.Message);
                        }
                    }
                },
                pre => true);

        SendCodeForgotPassCommand = new RelayCommand(
                action =>
                {
                    try
                    {
                        string regmessage = $"\t\t\t\t Attention!!\nDo not share this registration code with anyone! => {regCode}";
                        NetWork.SendNotification(CurrentPerson!.Email!, "Register Code", regmessage);
                        personInfoPageView.tbName.IsEnabled = false;
                        personInfoPageView.tbName.Visibility = Visibility.Hidden;
                        personInfoPageView.tbSurname.IsEnabled = false;
                        personInfoPageView.tbSurname.Visibility = Visibility.Hidden;
                        personInfoPageView.tbPhone.IsEnabled = false;
                        personInfoPageView.tbPhone.Visibility = Visibility.Hidden;
                        personInfoPageView.tbUsername.IsEnabled = false;
                        personInfoPageView.tbUsername.Visibility = Visibility.Hidden;
                        personInfoPageView.Update.IsEnabled = false;
                        personInfoPageView.Update.Visibility = Visibility.Hidden;
                        personInfoPageView.btn_add.IsEnabled = false;
                        personInfoPageView.btn_add.Visibility = Visibility.Hidden;
                        personInfoPageView.btn_edit.IsEnabled = false;
                        personInfoPageView.myEdit.Visibility = Visibility.Hidden;
                        personInfoPageView.btn_chng.IsEnabled = false;
                        personInfoPageView.btn_chng.Visibility = Visibility.Hidden;
                        personInfoPageView.myAdd.Visibility = Visibility.Hidden;
                        personInfoPageView.myPhoto.Visibility = Visibility.Hidden;
                        personInfoPageView.MyGrid.Height = 300;
                        personInfoPageView.tbVertfCode.IsEnabled = true;
                        personInfoPageView.tbVertfCode.Visibility = Visibility.Visible;
                        personInfoPageView.EnterCode.IsEnabled = true;
                        personInfoPageView.EnterCode.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                    }
                },
                pre => true);
    }

    Notifier notifier = new(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopRight,
            offsetX: 100,
            offsetY: 75);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(2),
            maximumNotificationCount: MaximumNotificationCount.FromCount(1));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
}