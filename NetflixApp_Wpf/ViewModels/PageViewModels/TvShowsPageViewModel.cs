using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Services;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDataAccessLayer.Repositories.Concretes;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public static class GlobalStringCommand
{
    public static string? Commaand { get; set; }
}

public class TvShowsPageViewModel : NotificationService
{
    public TvShowsPageView? tvShowsPageView { get; set; }
    public Person? CurrentPerson { get; set; }

    public ICommand? BackCommand { get; set; }
    public ICommand? ExitAppCommand { get; set; }
    public ICommand? ChangeCommand { get; set; }
    public ICommand? SearchCommand { get; set; }
    public ICommand? GoListCommand { get; set; }
    public ICommand? HeartCommand { get; set; }

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

    public TvShowsPageViewModel(TvShowsPageView tvShows, Person? currentPerson, string? commandd)
    {
        tvShowsPageView = tvShows;
        CurrentPerson = currentPerson;
        Commandd = commandd;
        GlobalStringCommand.Commaand = commandd;
        TvShows = new ObservableCollection<MovieTvShowDTO>();
        num = 1;
        MyLangSource2 = "../../../StaticFiles/Images/usa.jpg";
        CommandCheck();

        ExitAppCommand = new RelayCommand(
               action =>
               {
                   try
                   {
                       File.WriteAllText(GlobalVariables.FilePath!, currentPerson!.Email);
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

        SearchCommand = new RelayCommand(
                action =>
                {
                    var searchText = tvShowsPageView?.tbSearch2?.Text?.Trim();
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        // When you use (StringComparison.OrdinalIgnoreCase) in string operations, it means that the comparison
                        // will ignore the case of the characters
                        var searchResults = TvShows?.Where(movie => movie!.Name!.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
                        TvShows = new ObservableCollection<MovieTvShowDTO>(searchResults!);
                    }
                    else
                    {
                        notifier.ShowWarning("This Movie or Tv Show doesn't exist in Netflix.");
                        DispatcherTimer timer = new();
                        timer.Interval = TimeSpan.FromSeconds(3);
                        timer.Tick += (sender, e) =>
                        {
                            timer.Stop();
                            CommandCheck();
                        };
                        timer.Start();                       
                    }
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

        GoListCommand = new RelayCommand(
                action =>
                {
                    FilmListPageView filmList = new(currentPerson, "GoList", 2);
                    tvShowsPageView.NavigationService.Navigate(filmList);
                },
                pre => true);

        HeartCommand = new RelayCommand(
                action =>
                {
                    FilmListPageView filmList = new(currentPerson, "Heart", 2);
                    tvShowsPageView.NavigationService.Navigate(filmList);
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
                Id = ec.Id,
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
                Id = ec.Id - 146,
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
                Id = ec.Id,
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
                Id = ec.Id - 1,
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

    Notifier notifier = new(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopRight,
            offsetX: 5,
            offsetY: 90);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(2),
            maximumNotificationCount: MaximumNotificationCount.FromCount(2));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
}
