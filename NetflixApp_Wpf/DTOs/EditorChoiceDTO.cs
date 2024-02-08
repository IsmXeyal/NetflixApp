using NetflixApp_Wpf.Services;

namespace NetflixApp_Wpf.DTOs;

public class EditorChoiceDTO : BaseMovieDTO
{
    private int _rank;
    private string? _url;

    public int Rank { get => _rank; set { _rank = value; OnPropertyChanged(); } }
    public string? Video_link { get => _url; set { _url = value; OnPropertyChanged(); } }
}
