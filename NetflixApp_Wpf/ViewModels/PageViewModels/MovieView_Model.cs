using Microsoft.EntityFrameworkCore;
using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Services;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDataAccessLayer.Repositories.Concretes;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class MovieView_Model : NotificationService
{
    public MovieView_? MovieVieww { get; set; }
    public ICommand? ExitAppCommand { get; set; }
    public ICommand? PlayCommand { get; set; }
    public ICommand? TrailerCommand { get; set; }
    public ICommand? MinimizeAppCommand { get; set; }
    //public ICommand? WatchCommand { get; set; }
    //public ICommand? GoSeriesCommand { get; set; }
    public ICommand? PersonItemCommand { get; set; }
    //public ICommand? GoNewCommand { get; set; }
    //public ICommand? AddListCommand { get; set; }
    //public ICommand? GoListCommand { get; set; }
    //public ICommand? HeartCommand { get; set; }
    //public ICommand? SearchCommand { get; set; }

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

    private int selectedMovieIndex = 0;
    private DispatcherTimer? timer;
    public MovieView_Model(MovieView_ movieView, Person currentPerson, int ranking)
    {
        var window = Application.Current.MainWindow;
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(6) };
        timer.Tick += Timer_Tick;
        timer.Start();

        MovieVieww = movieView;
        CurrentPerson = currentPerson;

        MovieVieww.btn_max.IsEnabled = false;

        ExitAppCommand = new RelayCommand(
                action => { Application.Current.Shutdown(); },
                pre => true);

        MinimizeAppCommand = new RelayCommand(
                action => { window.WindowState = WindowState.Minimized; },
                pre => true
                );

        //TrailerCommand = new RelayCommand(
        //        action =>
        //        {
        //            WatchMovieView watch = new(currentPerson, selectedMovieIndex + 1);
        //            MovieVieww.NavigationService.Navigate(watch);
        //        },
        //        pre => true);

        //PlayCommand = new RelayCommand(
        //        action =>
        //        {
        //            WatchMovieView watch = new(currentPerson, selectedMovieIndex + 1);
        //            MovieVieww.NavigationService.Navigate(watch);
        //        },
        //        pre => true);

        PersonItemCommand = new RelayCommand(
                action =>
                {
                    PersonInfoPageView personInfo = new(currentPerson);
                    MovieVieww.NavigationService.Navigate(personInfo);
                },
                pre => true);

        //GoSeriesCommand = new RelayCommand(
        //        action =>
        //        {
        //            TvShowsPageView tvShows = new(currentPerson, "TvShow");
        //            MovieVieww.NavigationService.Navigate(tvShows);
        //        },
        //        pre => true);

        //GoNewCommand = new RelayCommand(
        //        action =>
        //        {
        //            TvShowsPageView tvShows = new(currentPerson, "NewMovie");
        //            MovieVieww.NavigationService.Navigate(tvShows);
        //        },
        //        pre => true);

        //GoListCommand = new RelayCommand(
        //        action =>
        //        {
        //            FilmListPageView filmList = new(currentPerson, "GoList");
        //            MovieVieww.NavigationService.Navigate(filmList);
        //        },
        //        pre => true);

        //HeartCommand = new RelayCommand(
        //        action =>
        //        {
        //            FilmListPageView filmList = new(currentPerson, "Heart");
        //            MovieVieww.NavigationService.Navigate(filmList);
        //        },
        //        pre => true);

        //SearchCommand = new RelayCommand(
        //        action =>
        //        {
        //            var searchText = MovieVieww?.tbSearch?.Text?.Trim();
        //            if (!string.IsNullOrEmpty(searchText))
        //            {
        //                // When you use (StringComparison.OrdinalIgnoreCase) in string operations, it means that the comparison
        //                // will ignore the case of the characters
        //                var searchResults = db.Movies.Where(movie => movie.title.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
        //                Film_view = new ObservableCollection<Movie>(searchResults);
        //            }
        //            else
        //            {
        //                notifier.ShowWarning("This movie doesn't exist in Netflix.");
        //                Film_view = db.Movies;
        //            }
        //        },
        //        pre => true);

        //AddListCommand = new RelayCommand(
        //        action =>
        //        {
        //            var selectedPerson = db.loadedPeople.FirstOrDefault(person => person.Email == CurrentPerson?.Email);

        //            if (selectedPerson != null)
        //            {
        //                if (selectedPerson.AddList.Any(u => u.title == SelectedMovie?.title))
        //                {
        //                    notifier.ShowWarning("This movie already added to the list.");
        //                }
        //                else
        //                {
        //                    // Determine the new rank based on the maximum rank in AddList or set to 1 if AddList is empty
        //                    int lastRank = selectedPerson.AddList.Any() ? selectedPerson.AddList.Max(m => m.rank) : 0;

        //                    // Set the rank for the selectedMovie
        //                    SelectedMovie.rank = lastRank + 1;

        //                    // Add selectedMovie to the AddList of the selectedPerson
        //                    selectedPerson.AddList.Add(SelectedMovie);

        //                    // Save the updated AddList for the selectedPerson
        //                    db.SavePeopleToJson();

        //                    notifier.ShowSuccess("Movie added to the list!");
        //                }
        //            }
        //        },
        //        pre => SelectedMovie != null);

        EditorChoiceRepository editorChoice = new();
        ICollection<EditorChoice> selection = editorChoice!.GetAllWithLanguages()!;
        ICollection<EditorChoice> genresel = editorChoice!.GetAllWithGenres()!;

        IEnumerable<EditorChoiceDTO> dtoList = selection.Where(ec => ec.Languages.Any(l => l.Id == 1)).Select(ec => new EditorChoiceDTO
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
