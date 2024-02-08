using NetflixApp_Wpf.Services;
using System.Collections.ObjectModel;

namespace NetflixApp_Wpf.DTOs;

public class MovieTvShowDTO : BaseMovieDTO
{
    private string? _duration;

    public string? Duration { get => _duration; set { _duration = value; OnPropertyChanged(); } }
}
