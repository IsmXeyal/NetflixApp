using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Services;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDataAccessLayer.Repositories.Concretes;
using NetflixAppDomainLayer.Entities.Concretes;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class TvShowsPageViewModel : NotificationService
{
    public TvShowsPageView? tvShowsPageView { get; set; }
    public Person? CurrentPerson { get; set; }

    public ICommand? BackCommand { get; set; }
    public ICommand? ExitAppCommand { get; set; }
    public ICommand? ChangeCommand { get; set; }

    private string? _command;

    public string? Commandd
    {
        get { return _command; }
        set { _command = value; OnPropertyChanged(); }
    }

    private ObservableCollection<MovieTvShowDTO>? _tvShows;

    public ObservableCollection<MovieTvShowDTO>? TvShows
    {
        get { return _tvShows; }
        set { _tvShows = value; OnPropertyChanged(); }
    }

    private int num;

    private bool _ischeck;

    public bool? Ischeckk
    {
        get { return _ischeck; }
        set { _ischeck = (bool)value!; OnPropertyChanged(); }
    }

    private string? _myLangSource;
    public string? MyLangSource2
    {
        get { return _myLangSource; }
        set
        {
            _myLangSource = value;
            OnPropertyChanged();
        }
    }

    public string? filePath = "../../../DTOs/CurrentPersonEmail.txt";
    public TvShowsPageViewModel(TvShowsPageView tvShows, Person? currentPerson, string? commandd)
    {
        tvShowsPageView = tvShows;
        CurrentPerson = currentPerson;
        Commandd = commandd;
        TvShows = new ObservableCollection<MovieTvShowDTO>();
        num = 1;
        MyLangSource2 = "../../../StaticFiles/Images/usa.jpg";
        CommandCheck();

        ExitAppCommand = new RelayCommand(
               action =>
               {
                   try
                   {
                       File.WriteAllText(filePath, currentPerson!.Email);
                       Application.Current.Shutdown();
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show($"Error writing to file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                   }
               },
               pre => true
               );

        BackCommand = new RelayCommand(
                action =>
                {
                    var movieView = new MovieView_(currentPerson!, 0);
                    tvShowsPageView?.NavigationService?.Navigate(movieView);
                },
                pre => true);

        ChangeCommand = new RelayCommand(
                action =>
                {
                    switch (Ischeckk)
                    {
                        case false:
                            MyLangSource2 = "../../../StaticFiles/Images/usa.jpg";
                            num = 1;
                            break;
                        case true:
                            MyLangSource2 = "../../../StaticFiles/Images/russia-flag.jpg";
                            num = 2;
                            break;
                    }
                    CommandCheck();
                },
                pre => true);
    }

    private void CommandCheck()
    {
        if (Commandd == "Top250Movie")
            LoadTop250MovieFromDatabase();
        else if (Commandd == "Top250TvShow")
            LoadTop250TvShowFromDatabase();
        else if (Commandd == "Popularmovies")
            LoadPopularMoviesFromDatabase();
        else if (Commandd == "PopularTvShow")
            LoadPopularTvShowsFromDatabase();
    }
    private void LoadTop250MovieFromDatabase()
    {
        Top250MovieRepository topMovie = new Top250MovieRepository();
        ICollection<Top250Movie> selection = topMovie!.GetAllWithLanguages()!;
        IEnumerable<MovieTvShowDTO> dtoList = selection
            .Where(ec => ec.Languages!.Any(l => l.Id == num))
            .Select(ec => new MovieTvShowDTO
            {
                Name = ec.Name,
                Image = ec.Image_link,
                Imdb_link = ec.Imdb_link,
                Duration = ec.Duration,
                Description = ec.Plot,
                Year = ec.Year,
                Rating = ec.Imdb_rating,
                Genre = new ObservableCollection<string>(ec.Genres!.Select(g => g.Name!))
            });

        TvShows = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void LoadTop250TvShowFromDatabase()
    {
        Top250TvShowRepository topTv = new Top250TvShowRepository();
        ICollection<Top250TvShow> selection = topTv!.GetAllWithLanguages()!;
        IEnumerable<MovieTvShowDTO> dtoList = selection
            .Where(ec => ec.Languages!.Any(l => l.Id == num))
            .Select(ec => new MovieTvShowDTO
            {
                Name = ec.Name,
                Image = ec.Image_link,
                Imdb_link = ec.Imdb_link,
                Duration = ec.Duration,
                Description = ec.Plot,
                Year = ec.Year,
                Rating = ec.Imdb_rating,
                Genre = new ObservableCollection<string>(ec.Genres!.Select(g => g.Name!))
            });

        TvShows = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void LoadPopularMoviesFromDatabase()
    {
        MostPopularMovieRepository topMovie = new MostPopularMovieRepository();
        ICollection<MostPopularMovie> selection = topMovie!.GetAllWithLanguages()!;
        IEnumerable<MovieTvShowDTO> dtoList = selection
            .Where(ec => ec.Languages!.Any(l => l.Id == num))
            .Select(ec => new MovieTvShowDTO
            {
                Name = ec.Name,
                Image = ec.Image_link,
                Imdb_link = ec.Imdb_link,
                Duration = ec.Duration,
                Description = ec.Plot,
                Year = ec.Year,
                Rating = ec.Imdb_rating,
                Genre = new ObservableCollection<string>(ec.Genres!.Select(g => g.Name!))
            });

        TvShows = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void LoadPopularTvShowsFromDatabase()
    {
        MostPopularTvShowRepository toptv = new MostPopularTvShowRepository();
        ICollection<MostPopularTvShow> selection = toptv!.GetAllWithLanguages()!;
        IEnumerable<MovieTvShowDTO> dtoList = selection
            .Where(ec => ec.Languages!.Any(l => l.Id == num))
            .Select(ec => new MovieTvShowDTO
            {
                Name = ec.Name,
                Image = ec.Image_link,
                Imdb_link = ec.Imdb_link,
                Duration = ec.Duration,
                Description = ec.Plot,
                Year = ec.Year,
                Rating = ec.Imdb_rating,
                Genre = new ObservableCollection<string>(ec.Genres!.Select(g => g.Name!))
            });

        TvShows = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }
}
