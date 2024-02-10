using NetflixApp_Wpf.Services;
using System.Collections.ObjectModel;

namespace NetflixApp_Wpf.DTOs;

public class MovieTvShowDTO : BaseMovieDTO
{
    private string? _year;
    private string? _duration;

    public string? Year { get => _year; set { _year = value; OnPropertyChanged(); } }
    public string? Duration { get => _duration; set { _duration = value; OnPropertyChanged(); } }
}
