namespace NetflixApp_Wpf.DTOs;

public class EditorChoiceDTO : BaseMovieDTO
{
    private int _year;
    private int _rank;
    private string? _url;

    public int Year { get => _year; set { _year = value; OnPropertyChanged(); } }
    public int Rank { get => _rank; set { _rank = value; OnPropertyChanged(); } }
    public string? Video_link { get => _url; set { _url = value; OnPropertyChanged(); } }
}
