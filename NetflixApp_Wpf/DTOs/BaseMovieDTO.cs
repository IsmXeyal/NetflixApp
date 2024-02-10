using NetflixApp_Wpf.Services;
using System.Collections.ObjectModel;

namespace NetflixApp_Wpf.DTOs;

public abstract class BaseMovieDTO : NotificationService
{
    private int _year;
    private decimal _rating;
    private string? _name;
    private string? _description;
    private string? _image;
    private string? _link;
    private ObservableCollection<string>? _genre;
    private ObservableCollection<string>? _language;
    private ObservableCollection<string>? _comment;

    public int Year { get => _year; set { _year = value; OnPropertyChanged(); } }
    public decimal Rating { get => _rating; set { _rating = value; OnPropertyChanged(); } }
    public string? Name { get => _name; set { _name = value; OnPropertyChanged(); } }
    public string? Description { get => _description; set { _description = value; OnPropertyChanged(); } }
    public string? Image { get => _image; set { _image = value; OnPropertyChanged(); } }
    public string? Imdb_link { get => _link; set { _link = value; OnPropertyChanged(); } }
    public ObservableCollection<string>? Genre { get => _genre; set { _genre = value; OnPropertyChanged(); } }
    public ObservableCollection<string>? Language { get => _language; set { _language = value; OnPropertyChanged(); } }
    public ObservableCollection<string>? Comment { get => _comment; set { _comment = value; OnPropertyChanged(); } }
}