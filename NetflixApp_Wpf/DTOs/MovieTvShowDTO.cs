namespace NetflixApp_Wpf.DTOs;

public class MovieTvShowDTO : BaseMovieDTO
{
    private int _id;
    private string? _year;
    private string? _duration;

    public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
    public string? Year { get => _year; set { _year = value; OnPropertyChanged(); } }
    public string? Duration { get => _duration; set { _duration = value; OnPropertyChanged(); } }
}
