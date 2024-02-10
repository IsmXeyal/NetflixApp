using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Services;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDataAccessLayer.Repositories.Concretes;
using NetflixAppDomainLayer.Entities.Concretes;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class WatchTvShowViewModel : NotificationService
{
    public WatchMovieView? WatchMovieVieww { get; set; }
    public Person? CurrentPerson { get; set; }
    public int Index { get; set; }

    private ObservableCollection<MovieTvShowDTO>? _movies;

    public ObservableCollection<MovieTvShowDTO>? Moviess
    {
        get { return _movies; }
        set { _movies = value; OnPropertyChanged(); }
    }
    public ICommand? PlayCommand { get; set; }
    public ICommand? TrailerCommand { get; set; }
    public ICommand? BackCommand { get; set; }
    public ICommand? ExitCommand { get; set; }
    public ICommand? AddListCommand { get; set; }
    public ICommand? HeartCommand { get; set; }

    public string? Video_Link { get; set; }
    public string? Imdb_Link { get; set; }

    private MovieTvShowDTO? _selectedMovie;

    public MovieTvShowDTO? SelectedMovie
    {
        get { return _selectedMovie; }
        set { _selectedMovie = value; OnPropertyChanged(); }
    }

    private bool _isfavorite;

    public bool? IsFavorite
    {
        get { return _isfavorite; }
        set { _isfavorite = (bool)value!; OnPropertyChanged(); }
    }

    public string? filePath = "../../../DTOs/CurrentPersonEmail.txt";
    public WatchTvShowViewModel(WatchMovieView watchMovie, Person person, int index, int langId, int type)
    {
        WatchMovieVieww = watchMovie;
        CurrentPerson = person;
        Index = index;

        switch (GlobalStringCommand.Commaand)
        {
            case "Top250Movie":
                UpdateTop250MovieFromDatabase(langId);
                break;
            case "Top250TvShow":
                UpdateTop250TvShowFromDatabase(langId);
                break;
            case "Popularmovies":
                UpdatePopularMoviesFromDatabase(langId);
                break;
            case "PopularTvShow":
                UpdatePopularTvShowsFromDatabase(langId);
                break;
            default:
                return;
        }

        if (Index > 0 && Index <= Moviess!.Count)
        {
            SelectedMovie = Moviess[Index - 1];
            Imdb_Link = SelectedMovie.Imdb_link;
        }

        //var selectedPerson = db.loadedPeople.FirstOrDefault(person => person.Email == CurrentPerson?.Email);
        //if (selectedPerson != null)
        //{
        //    if (selectedPerson.FavsList!.Any(u => u.title == SelectedMovie?.Name))
        //        IsFavorite = true;
        //    else
        //        IsFavorite = false;
        //}

        ExitCommand = new RelayCommand(
               action =>
               {
                   try
                   {
                       File.WriteAllText(filePath, person.Email);
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
                            return;
                    }
                    WatchMovieVieww.NavigationService.Navigate(tvShowss);
                },
                pre => true);

        TrailerCommand = new RelayCommand(
                action =>
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Imdb_Link,
                        UseShellExecute = true,
                    });
                },
                pre => !string.IsNullOrEmpty(Imdb_Link));

        PlayCommand = new RelayCommand(
                action =>
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Video_Link,
                        UseShellExecute = true,
                    });
                },
                pre => !string.IsNullOrEmpty(Video_Link));

        //AddListCommand = new RelayCommand(
        //        action =>
        //        {
        //            if (selectedPerson != null)
        //            {
        //                if (selectedPerson.AddList!.Any(u => u.title == selectedMovie?.title))
        //                {
        //                    notifier.ShowWarning("This movie already added to the list.");
        //                }
        //                else
        //                {
        //                     Determine the new rank based on the maximum rank in AddList or set to 1 if AddList is empty
        //                    int lastRank = selectedPerson.AddList.Any() ? selectedPerson.AddList.Max(m => m.rank) : 0;

        //                     Set the rank for the selectedMovie
        //                    selectedMovie.rank = lastRank + 1;

        //                     Add selectedMovie to the AddList of the selectedPerson
        //                    selectedPerson.AddList.Add(selectedMovie);

        //                     Save the updated AddList for the selectedPerson
        //                    db.SavePeopleToJson();

        //                    notifier.ShowSuccess("Movie added to the list!");
        //                }
        //            }
        //        },
        //        pre => selectedMovie != null);

        //HeartCommand = new RelayCommand(
        //        action =>
        //        {
        //            if (selectedPerson != null)
        //            {
        //                if (IsFavorite == false)
        //                {
        //                    Movie? movieToRemove = selectedPerson!.FavsList!.FirstOrDefault(m => m.title == selectedMovie?.title);
        //                    int removedRank = movieToRemove.rank;
        //                    selectedPerson!.FavsList!.Remove(movieToRemove);

        //                    foreach (Movie movie in selectedPerson.FavsList.Where(m => m.rank > removedRank))
        //                    {
        //                        movie.rank--;
        //                    }
        //                    db.SavePeopleToJson();
        //                    notifier.ShowSuccess("Movie removed from favorites!");
        //                }
        //                else
        //                {
        //                    int lastRank = selectedPerson.FavsList!.Any() ? selectedPerson.FavsList!.Max(m => m.rank) : 0;
        //                    selectedMovie!.rank = lastRank + 1;
        //                    selectedPerson.FavsList!.Add(selectedMovie);
        //                    db.SavePeopleToJson();
        //                    notifier.ShowSuccess("Movie added to favorites!");
        //                }
        //            }
        //        },
        //        pre => selectedMovie != null);
    }

    private void UpdateTop250MovieFromDatabase(int num)
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

        Moviess = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void UpdateTop250TvShowFromDatabase(int num)
    {
        Top250TvShowRepository topTv = new Top250TvShowRepository();
        ICollection<Top250TvShow> selection = topTv!.GetAllWithLanguages()!;
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

        Moviess = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void UpdatePopularMoviesFromDatabase(int num)
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

        Moviess = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void UpdatePopularTvShowsFromDatabase(int num)
    {
        MostPopularTvShowRepository toptv = new MostPopularTvShowRepository();
        ICollection<MostPopularTvShow> selection = toptv!.GetAllWithLanguages()!;
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

        Moviess = new ObservableCollection<MovieTvShowDTO>(dtoList);
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
