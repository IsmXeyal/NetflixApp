using NetflixApp_Wpf.Services;
using System.Collections.ObjectModel;

namespace NetflixApp_Wpf.DTOs;

public class PersonDTO : NotificationService
{
    private string? _firstname;
    private string? _lastname;
    private string? _username;
    private string? _email;
    private string? _image;
    private string? _password;
    private string? _phoneNumber;
    private ObservableCollection<EditorChoiceDTO>? _favsListEditor { get; set; }
    private ObservableCollection<MovieTvShowDTO>? _favsListMovie { get; set; }
    private ObservableCollection<EditorChoiceDTO>? _addListEditor { get; set; }
    private ObservableCollection<MovieTvShowDTO>? _addListMovie { get; set; }

    public string? Firstname
    {
        get => _firstname;
        set
        {
            if (_firstname != value)
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Lastname
    {
        get => _lastname;
        set
        {
            if (_lastname != value)
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Email
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Image
    {
        get => _image;
        set
        {
            if (_image != value)
            {
                _image = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }

    public string? PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (_phoneNumber != value)
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<EditorChoiceDTO>? FavsListEditor { get => _favsListEditor; set { _favsListEditor = value; OnPropertyChanged(); } }
    public ObservableCollection<MovieTvShowDTO>? FavsListMovie { get => _favsListMovie; set { _favsListMovie = value; OnPropertyChanged(); } }
    public ObservableCollection<EditorChoiceDTO>? AddListEditor { get => _addListEditor; set { _addListEditor = value; OnPropertyChanged(); } }
    public ObservableCollection<MovieTvShowDTO>? AddListMovie { get => _addListMovie; set { _addListMovie = value; OnPropertyChanged(); } }
}
