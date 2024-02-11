using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.ViewModels.PageViewModels;
using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Views.Pages;


public partial class FilmListPageView : Page
{
    public Person? CurrentPerson { get; set; }
    public string? Commandd {  get; set; }
    NetflixDbContext context = new();
    public FilmListPageView(Person? currentPerson, string? commandd, int page)
    {
        InitializeComponent();
        CurrentPerson = currentPerson;
        Commandd = commandd;
        if(page == 1)
            DataContext = new FilmPageViewModel(this, currentPerson, commandd);
        else if(page == 2)
            DataContext = new FilmTvPageViewModel(this, currentPerson, commandd);
    }
    private void movie_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        WatchMovieView watchMovieView;
        if (sender is Button button && button.DataContext is EditorChoiceDTO movie)
        {
            string movieName = movie.Name!;
            int rank = GetRankFromNameEditor(movieName);
            watchMovieView = new(CurrentPerson!, rank, 1, 1);
            NavigationService?.Navigate(watchMovieView);
        }
        else if (sender is Button button2 && button2.DataContext is MovieTvShowDTO tv)
        {
            string movieName = tv.Name!;
            int rank;

            switch (GlobalStringCommand.Commaand)
            {
                case "Top250Movie":
                    rank = GetRankFromNameTop250Movie(movieName);
                    break;
                case "Top250TvShow":
                    rank = GetRankFromNameTop250TvShow(movieName);
                    break;
                case "Popularmovies":
                    rank = GetRankFromNamePopularM(movieName);
                    break;
                case "PopularTvShow":
                    rank = GetRankFromNamePopularTv(movieName);
                    break;
                default:
                    rank = 0;
                    break;
            }

            watchMovieView = new(CurrentPerson!, rank, 1, 2);
            NavigationService?.Navigate(watchMovieView);
        }
    }

    private int GetRankFromNameEditor(string movieName)
    {
        var selectedMovie = context.EditorChoices.FirstOrDefault(m => m.Name == movieName);
        return selectedMovie?.Rank ?? 0;
    }

    private int GetRankFromNameTop250Movie(string movieName)
    {
        var selectedMovie = context.Top250Movies.FirstOrDefault(m => m.Name == movieName);
        return selectedMovie?.Id ?? 0;
    }

    private int GetRankFromNameTop250TvShow(string movieName)
    {
        var selectedMovie = context.Top250TvShows.FirstOrDefault(m => m.Name == movieName);
        return selectedMovie?.Id - 146 ?? 0;
    }

    private int GetRankFromNamePopularM(string movieName)
    {
        var selectedMovie = context.MostPopularMovies.FirstOrDefault(m => m.Name == movieName);
        return selectedMovie?.Id ?? 0;
    }

    private int GetRankFromNamePopularTv(string movieName)
    {
        var selectedMovie = context.MostPopularTvShows.FirstOrDefault(m => m.Name == movieName);
        return selectedMovie?.Id - 1 ?? 0;
    }
}
