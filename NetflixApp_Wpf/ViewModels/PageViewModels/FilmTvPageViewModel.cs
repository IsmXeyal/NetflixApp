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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class FilmTvPageViewModel : NotificationService
{
    public FilmListPageView? FilmList { get; set; }
    public Person? CurrentPerson { get; set; }

    public ICommand? BackCommand { get; set; }
    public ICommand? ExitAppCommand { get; set; }

    private ObservableCollection<MovieTvShowDTO>? add_view;

    public ObservableCollection<MovieTvShowDTO>? Add_view
    {
        get { return add_view; }
        set { add_view = value; OnPropertyChanged(); }
    }

    private string? command;

    public string? Commandd
    {
        get { return command; }
        set { command = value; OnPropertyChanged(); }
    }

    NetflixDbContext context = new();
    public FilmTvPageViewModel(FilmListPageView filmlist, Person? currentPerson, string? commandd)
    {
        FilmList = filmlist;
        CurrentPerson = currentPerson;
        Commandd = commandd;

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
                       notifier.ShowError($"Error writing to file: {ex.Message}");
                   }
               },
               pre => true);

        BackCommand = new RelayCommand(
                action =>
                {
                    TvShowsPageView tvShowss;
                    switch (GlobalStringCommand.Commaand)
                    {
                        case "Top250Movie":
                            tvShowss = new TvShowsPageView(CurrentPerson!, "Top250Movie");
                            break;
                        case "Top250TvShow":
                            tvShowss = new TvShowsPageView(CurrentPerson!, "Top250TvShow");
                            break;
                        case "Popularmovies":
                            tvShowss = new TvShowsPageView(CurrentPerson!, "Popularmovies");
                            break;
                        case "PopularTvShow":
                            tvShowss = new TvShowsPageView(CurrentPerson!, "PopularTvShow");
                            break;
                        default:
                            var movieView = new MovieView_(currentPerson!, 0);
                            FilmList?.NavigationService?.Navigate(movieView);
                            return;
                    }
                    FilmList.NavigationService.Navigate(tvShowss);                    
                },
                pre => true);

        if (Commandd == "GoList")
        {
            switch (GlobalStringCommand.Commaand)
            {
                case "Top250Movie":
                    Top250MovieRepository top250M = new();
                    ICollection<Top250Movie> selection = top250M!.GetAllWithAddListTMs()!;
                    IEnumerable<MovieTvShowDTO> dtoList = selection
                        .Where(ec => ec.AddListTMs!.Any(l => (l.Id_TM == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == false && l.IsBoth == false)
                                || (l.Id_TM == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsBoth == true)))
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
                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList);
                    break;
                case "Top250TvShow":
                    Top250TvShowRepository top250T = new();
                    ICollection<Top250TvShow> selection2 = top250T!.GetAllWithAddListTTs()!;
                    IEnumerable<MovieTvShowDTO> dtoList2 = selection2
                        .Where(ec => ec.AddListTTs!.Any(l => (l.Id_TT == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == false && l.IsBoth == false)
                                || (l.Id_TT == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsBoth == true)))
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
                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList2);
                    break;
                case "Popularmovies":
                    MostPopularMovieRepository pm = new();
                    ICollection<MostPopularMovie> selection3 = pm!.GetAllWithAddListMPMs()!;
                    IEnumerable<MovieTvShowDTO> dtoList3 = selection3
                        .Where(ec => ec.AddListMPMs!.Any(l => (l.Id_MPM == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == false && l.IsBoth == false)
                                || (l.Id_MPM == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsBoth == true)))
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
                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList3);
                    break;
                case "PopularTvShow":
                    MostPopularTvShowRepository pt = new();
                    ICollection<MostPopularTvShow> selection4 = pt!.GetAllWithAddListMpTs()!;
                    IEnumerable<MovieTvShowDTO> dtoList4 = selection4
                        .Where(ec => ec.AddListMpTs!.Any(l => (l.Id_MpT == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == false && l.IsBoth == false)
                                || (l.Id_MpT == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsBoth == true)))
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
                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList4);
                    break;
                default:
                    return;
            }           
        }
        else if (Commandd == "Heart")
        {
            switch (GlobalStringCommand.Commaand)
            {
                case "Top250Movie":
                    Top250MovieRepository top250M = new();
                    ICollection<Top250Movie> selection = top250M!.GetAllWithAddListTMs()!;
                    IEnumerable<MovieTvShowDTO> dtoList = selection
                        .Where(ec => ec.AddListTMs!.Any(l => l.Id_TM == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == true))
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

                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList);
                    break;
                case "Top250TvShow":
                    Top250TvShowRepository top250Tv = new();
                    ICollection<Top250TvShow> selection2 = top250Tv!.GetAllWithAddListTTs()!;
                    IEnumerable<MovieTvShowDTO> dtoList2 = selection2
                        .Where(ec => ec.AddListTTs!.Any(l => l.Id_TT == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == true))
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

                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList2);
                    break;
                case "Popularmovies":
                    MostPopularMovieRepository pm = new();
                    ICollection<MostPopularMovie> selection3 = pm!.GetAllWithAddListMPMs()!;
                    IEnumerable<MovieTvShowDTO> dtoList3 = selection3
                        .Where(ec => ec.AddListMPMs!.Any(l => l.Id_MPM == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == true))
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

                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList3);
                    break;
                case "PopularTvShow":
                    MostPopularTvShowRepository pt = new();
                    ICollection<MostPopularTvShow> selection4= pt!.GetAllWithAddListMpTs()!;
                    IEnumerable<MovieTvShowDTO> dtoList4 = selection4
                        .Where(ec => ec.AddListMpTs!.Any(l => l.Id_MpT == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == true))
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

                    Add_view = new ObservableCollection<MovieTvShowDTO>(dtoList4);
                    break;
                default:
                    return;
            }
        }
    }

    Notifier notifier = new(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopRight,
            offsetX: 5,
            offsetY: 30);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(2),
            maximumNotificationCount: MaximumNotificationCount.FromCount(2));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
}
