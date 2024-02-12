using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppBusinessLogicLayer.Services;
using NetflixAppDataAccessLayer.Contexts;
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

public static class GlobalVariables
{
    public static string? FilePath { get; } = "../../../DTOs/CurrentPersonEmail.txt";
}

public class MovieView_Model : NotificationService
{
    public MovieView_? MovieVieww { get; set; }
    public ICommand? ExitAppCommand { get; set; }
    public ICommand? PlayCommand { get; set; }
    public ICommand? TrailerCommand { get; set; }
    public ICommand? MinimizeAppCommand { get; set; }
    public ICommand? PersonItemCommand { get; set; }
    public ICommand? SettingItemCommand { get; set; }
    public ICommand? NewPopularItemCommand { get; set; }
    public ICommand? SignOutCommand { get; set; }
    public ICommand? EditorItemCommand { get; set; }
    public ICommand? MoviesItemCommand { get; set; }
    public ICommand? TvShowsItemCommand { get; set; }
    public ICommand? PopularMoviesCommand { get; set; }
    public ICommand? PopularTvShowsCommand { get; set; }
    public ICommand? AddListCommand { get; set; }
    public ICommand? GoListCommand { get; set; }
    public ICommand? HeartCommand { get; set; }
    public ICommand? ChangeCommand { get; set; }
    public ICommand? SearchCommand { get; set; }

    public int countClickMaximize = 0;

    private Person? _currentPerson { get; set; }
    public Person? CurrentPerson
    {
        get { return _currentPerson; }
        set { _currentPerson = value; OnPropertyChanged(); }
    }

    private EditorChoiceDTO? _selectedMovie;

    public EditorChoiceDTO? SelectedMovie
    {
        get { return _selectedMovie; }
        set { _selectedMovie = value; OnPropertyChanged(); }
    }

    private ObservableCollection<EditorChoiceDTO>? film_view;

    public ObservableCollection<EditorChoiceDTO>? Film_view
    {
        get { return film_view; }
        set { film_view = value; OnPropertyChanged(); }
    }

    private bool _ischeck;

    public bool? Ischeck
    {
        get { return _ischeck; }
        set { _ischeck = (bool)value!; OnPropertyChanged(); }
    }

    private string? _myLangSource;
    public string? MyLangSource
    {
        get { return _myLangSource; }
        set
        {
            _myLangSource = value;
            OnPropertyChanged();
        }
    }

    private int selectedMovieIndex = 0;
    private DispatcherTimer? timer;
    private int num;

    NetflixDbContext context = new(); 
    public MovieView_Model(MovieView_ movieView, Person currentPerson, int ranking)
    {
        var window = Application.Current.MainWindow;
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(6) };
        timer.Tick += Timer_Tick;
        timer.Start();

        Ischeck = false;
        num = 1;
        MyLangSource = "../../../StaticFiles/Images/usa.jpg";
        UpdateFilmView();
        MovieVieww = movieView;
        CurrentPerson = currentPerson;

        MovieVieww.btn_max.IsEnabled = false;

        ExitAppCommand = new RelayCommand(
                action => 
                {
                    try
                    {
                        File.WriteAllText(GlobalVariables.FilePath!, currentPerson.Email);
                        Application.Current.Shutdown();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error writing to file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                },
                pre => true);

        MinimizeAppCommand = new RelayCommand(
                action => { window.WindowState = WindowState.Minimized; },
                pre => true);

        TrailerCommand = new RelayCommand(
                action =>
                {
                    WatchMovieView watchMovieView;

                    if (movieView.chng_language.IsChecked == false)
                        watchMovieView = new WatchMovieView(CurrentPerson!, selectedMovieIndex + 1, 1, 1);
                    else
                        watchMovieView = new WatchMovieView(CurrentPerson!, selectedMovieIndex + 1, 2, 1);

                    MovieVieww.NavigationService.Navigate(watchMovieView);
                },
                pre => true);

        PlayCommand = new RelayCommand(
                action =>
                {
                    WatchMovieView watchMovieView;

                    if (movieView.chng_language.IsChecked == false)
                        watchMovieView = new WatchMovieView(CurrentPerson!, selectedMovieIndex + 1, 1, 1);
                    else
                        watchMovieView = new WatchMovieView(CurrentPerson!, selectedMovieIndex + 1, 2, 1);

                    MovieVieww.NavigationService.Navigate(watchMovieView);
                },
                pre => true);

        SettingItemCommand = new RelayCommand(
                action =>
                {
                    if (movieView.SignoutItem.Visibility == Visibility.Visible)
                        movieView.SignoutItem.Visibility = Visibility.Hidden;
                    else
                        movieView.SignoutItem.Visibility = Visibility.Visible;
                },
                pre => true);

        PersonItemCommand = new RelayCommand(
                action =>
                {
                    PersonInfoPageView personInfo = new(currentPerson);
                    MovieVieww.NavigationService.Navigate(personInfo);
                },
                pre => true);

        EditorItemCommand = new RelayCommand(
                action =>
                {
                    var movieView = new MovieView_(currentPerson!, 0);
                    MovieVieww?.NavigationService?.Navigate(movieView);
                },
                pre => true);

        NewPopularItemCommand = new RelayCommand(
                action =>
                {
                    if (movieView.PopularMoviesItem.Visibility == Visibility.Visible && movieView.PopularTvShowsItem.Visibility == Visibility.Visible)
                    {
                        movieView.PopularMoviesItem.Visibility = Visibility.Hidden;
                        movieView.PersonItem.Margin = new Thickness(0, -100, 0, 0);
                        movieView.PopularTvShowsItem.Visibility = Visibility.Hidden;
                        movieView.SettingItem.Margin = new Thickness(0, -20, 0, 0);
                    }
                    else
                    {
                        movieView.PopularMoviesItem.Visibility = Visibility.Visible;
                        movieView.PersonItem.Margin = new Thickness(0, 0, 0, 0);
                        movieView.PopularTvShowsItem.Visibility = Visibility.Visible;
                    }
                },
                pre => true);

        SignOutCommand = new RelayCommand(
                action =>
                {
                    ClearPersonData();
                    notifier.ShowSuccess("Signing Out...");
                    DispatcherTimer timer = new();
                    timer.Interval = TimeSpan.FromSeconds(3);
                    timer.Tick += (sender, e) =>
                    {
                        timer.Stop();
                        var signInPage = new SignInPageView();
                        MovieVieww?.NavigationService?.Navigate(signInPage);
                    };
                    timer.Start();
                },
                pre => true);

        MoviesItemCommand = new RelayCommand(
                action =>
                {
                    TvShowsPageView tvShows = new(currentPerson, "Top250Movie");
                    MovieVieww.NavigationService.Navigate(tvShows);
                },
                pre => true);

        TvShowsItemCommand = new RelayCommand(
                action =>
                {
                    TvShowsPageView tvShows = new(currentPerson, "Top250TvShow");
                    MovieVieww.NavigationService.Navigate(tvShows);
                },
                pre => true);

        PopularMoviesCommand = new RelayCommand(
                action =>
                {
                    TvShowsPageView tvShows = new(currentPerson, "Popularmovies");
                    MovieVieww.NavigationService.Navigate(tvShows);
                },
                pre => true);

        PopularTvShowsCommand = new RelayCommand(
                action =>
                {
                    TvShowsPageView tvShows = new(currentPerson, "PopularTvShow");
                    MovieVieww.NavigationService.Navigate(tvShows);
                },
                pre => true);

        GoListCommand = new RelayCommand(
                action =>
                {
                    FilmListPageView filmList = new(currentPerson, "GoList", 1);
                    MovieVieww.NavigationService.Navigate(filmList);
                },
                pre => true);

        HeartCommand = new RelayCommand(
                action =>
                {
                    FilmListPageView filmList = new(currentPerson, "Heart", 1);
                    MovieVieww.NavigationService.Navigate(filmList);
                },
                pre => true);

        ChangeCommand = new RelayCommand(
                action =>
                {
                    switch (Ischeck)
                    {
                        case false:
                            MyLangSource = "../../../StaticFiles/Images/usa.jpg";
                            num = 1;
                            movieView.imdb.Content = "IMDB";
                            movieView.year.Content = "YEAR";
                            movieView.mySearch.Text = "Search";
                            break;
                        case true:
                            MyLangSource = "../../../StaticFiles/Images/russia-flag.jpg";
                            num = 2;
                            movieView.imdb.Content = "ИМДБ";
                            movieView.year.Content = "Год";
                            movieView.mySearch.Text = "Поиск";
                            break;
                    }
                    UpdateFilmView();
                },
                pre => true);

        SearchCommand = new RelayCommand(
                action =>
                {
                    var searchText = MovieVieww?.tbSearch?.Text?.Trim();
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        // When you use (StringComparison.OrdinalIgnoreCase) in string operations, it means that the comparison
                        // will ignore the case of the characters
                        var searchResults = Film_view?.Where(movie => movie!.Name!.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
                        Film_view = new ObservableCollection<EditorChoiceDTO>(searchResults!);
                    }
                    else
                    {
                        notifier.ShowWarning("This movie doesn't exist in Netflix.");
                        UpdateFilmView();
                    }
                },
                pre => true);

        AddListCommand = new RelayCommand(
                action =>
                {
                    var selectedPerson = context.People.FirstOrDefault(person => person.Email == CurrentPerson!.Email);

                    if (selectedPerson != null)
                    {
                        if (selectedPerson.AddListECs!.Any(u => u.Id_ECMovie == SelectedMovie!.Rank))
                        {
                            notifier.ShowWarning("This movie is already added to the list.");
                        }
                        else
                        {
                            var addListEC = new AddListEC
                            {
                                Id_Person = selectedPerson.Id,
                                Id_ECMovie = SelectedMovie!.Rank,
                            };

                            context.AddListECs.Add(addListEC);
                            context.SaveChanges();
                            notifier.ShowSuccess("Movie added to the list!");
                        }
                    }
                },
                pre => SelectedMovie != null);

    }

    private void UpdateFilmView()
    {
        EditorChoiceRepository editorChoice = new();
        ICollection<EditorChoice> selection = editorChoice!.GetAllWithLanguages()!;
        IEnumerable<EditorChoiceDTO> dtoList = selection
            .Where(ec => ec.Languages!.Any(l => l.Id == num))
            .Select(ec => new EditorChoiceDTO
            {
                Name = ec.Name,
                Image = ec.Image_link,
                Imdb_link = ec.Imdb_link,
                Video_link = ec.Video_link,
                Rank = ec.Rank,
                Description = ec.Plot,
                Year = ec.Year,
                Rating = ec.Imdb_rating,
                Genre = new ObservableCollection<string>(collection: ec.Genres!.Select(g => g.Name!))
            });

        Film_view = new ObservableCollection<EditorChoiceDTO>(dtoList);
        UpdateSelectedMovie();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        selectedMovieIndex = (selectedMovieIndex + 1) % 7;
        UpdateSelectedMovie();
    }

    private void UpdateSelectedMovie()
    {
        SelectedMovie = Film_view?.Count > selectedMovieIndex ? Film_view[selectedMovieIndex] : null;
    }

    private void ClearPersonData()
    {
        try
        {
            if (File.Exists(GlobalVariables.FilePath))
                File.Delete(GlobalVariables.FilePath);
        }
        catch (Exception ex)
        {
            notifier.ShowError($"Error clearing user data: {ex.Message}");
        }
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
