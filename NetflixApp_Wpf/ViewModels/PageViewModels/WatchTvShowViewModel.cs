using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppBusinessLogicLayer.Services;
using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDataAccessLayer.Repositories.Concretes;
using NetflixAppDomainLayer.Entities.Concretes;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
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
    public ICommand? SendCommand { get; set; }
    public ICommand? HeartCommand { get; set; }

    public string? Video_Link { get; set; }
    public string? Imdb_Link { get; set; }

    private MovieTvShowDTO? _selectedMovie;

    public MovieTvShowDTO? SelectedMovie
    {
        get { return _selectedMovie; }
        set { _selectedMovie = value; OnPropertyChanged(); }
    }

    private ObservableCollection<CommentDTO>? _comment;

    public ObservableCollection<CommentDTO>? Comments
    {
        get { return _comment; }
        set { _comment = value; OnPropertyChanged(); }
    }

    private bool _isfavorite;

    public bool? IsFavorite
    {
        get { return _isfavorite; }
        set { _isfavorite = (bool)value!; OnPropertyChanged(); }
    }

    NetflixDbContext context = new();
    DispatcherTimer timer = new();
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

        switch (GlobalStringCommand.Commaand)
        {
            case "Top250Movie":
                UpdateCommentsTM();
                break;
            case "Top250TvShow":
                UpdateCommentsTT();
                break;
            case "Popularmovies":
                UpdateCommentsMPM();
                break;
            case "PopularTvShow":
                UpdateCommentsMPT();
                break;
            default:
                return;
        }

        var selectedPerson = context.People.FirstOrDefault(person => person.Email == CurrentPerson!.Email);
        if (selectedPerson != null)
        {
            switch (GlobalStringCommand.Commaand)
            {
                case "Top250Movie":
                    if (selectedPerson.AddListTMs!.FirstOrDefault(add => add.Id_TM == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id && add.IsFavorite == true) != null)
                        IsFavorite = true;
                    else
                        IsFavorite = false;
                    break;
                case "Top250TvShow":
                    if (selectedPerson.AddListTTs!.FirstOrDefault(add => add.Id_TT == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id && add.IsFavorite == true) != null)
                        IsFavorite = true;
                    else
                        IsFavorite = false;
                    break;
                case "Popularmovies":
                    if (selectedPerson.AddListMPMs!.FirstOrDefault(add => add.Id_MPM == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id && add.IsFavorite == true) != null)
                        IsFavorite = true;
                    else
                        IsFavorite = false;
                    break;
                case "PopularTvShow":
                    if (selectedPerson.AddListMpTs!.FirstOrDefault(add => add.Id_MpT == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id && add.IsFavorite == true) != null)
                        IsFavorite = true;
                    else
                        IsFavorite = false;
                    break;
                default:
                    return;
            }
        }
        

        ExitCommand = new RelayCommand(
               action =>
               {
                   try
                   {
                       File.WriteAllText(GlobalVariables.FilePath!, person.Email);
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

        AddListCommand = new RelayCommand(
                action =>
                {
                    if (selectedPerson != null)
                    {
                        switch (GlobalStringCommand.Commaand)
                        {
                            case "Top250Movie":
                                if (selectedPerson.AddListTMs!.Any(u => (u.Id_TM == SelectedMovie!.Id && u.IsBoth == false && u.IsFavorite == false)
                                    || (u.Id_TM == SelectedMovie!.Id && u.IsBoth == true)))
                                {
                                    notifier.ShowWarning("This movie is already added to the list.");
                                }
                                else
                                {
                                    var addListTM = new AddListTM
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_TM = SelectedMovie!.Id,
                                    };

                                    context.AddListTMs.Add(addListTM);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie added to the list!");
                                }
                                break;
                            case "Top250TvShow":
                                if (selectedPerson.AddListTTs!.Any(u => (u.Id_TT == SelectedMovie!.Id && u.IsBoth == false && u.IsFavorite == false)
                                    || (u.Id_TT == SelectedMovie!.Id && u.IsBoth == true)))
                                {
                                    notifier.ShowWarning("This movie is already added to the list.");
                                }
                                else
                                {
                                    var addListTT = new AddListTT
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_TT = SelectedMovie!.Id + 146,
                                    };

                                    context.AddListTTs.Add(addListTT);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie added to the list!");
                                }
                                break;
                            case "Popularmovies":
                                if (selectedPerson.AddListMPMs!.Any(u => (u.Id_MPM == SelectedMovie!.Id && u.IsBoth == false && u.IsFavorite == false)
                                    || (u.Id_MPM == SelectedMovie!.Id && u.IsBoth == true)))
                                {
                                    notifier.ShowWarning("This movie is already added to the list.");
                                }
                                else
                                {
                                    var addListMPM = new AddListMPM
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_MPM = SelectedMovie!.Id,
                                    };

                                    context.AddListMPMs.Add(addListMPM);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie added to the list!");
                                }
                                break;
                            case "PopularTvShow":
                                if (selectedPerson.AddListMpTs!.Any(u => (u.Id_MpT == SelectedMovie!.Id && u.IsBoth == false && u.IsFavorite == false)
                                    || (u.Id_MpT == SelectedMovie!.Id && u.IsBoth == true)))
                                {
                                    notifier.ShowWarning("This movie is already added to the list.");
                                }
                                else
                                {
                                    var addListMpT = new AddListMpT
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_MpT = SelectedMovie!.Id + 1,
                                    };

                                    context.AddListMpTs.Add(addListMpT);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie added to the list!");
                                }
                                break;
                            default:
                                return;
                        }
                    }
                },
                pre => SelectedMovie != null);

        HeartCommand = new RelayCommand(
                action =>
                {
                    switch (GlobalStringCommand.Commaand)
                    {
                        case "Top250Movie":
                            if (selectedPerson != null)
                            {
                                var addListTM = selectedPerson.AddListTMs!.FirstOrDefault(add => add.Id_TM == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id);

                                if (addListTM != null)
                                {
                                    addListTM.IsFavorite = !addListTM.IsFavorite;
                                    if (addListTM.IsFavorite)
                                    {
                                        notifier.ShowSuccess("Movie marked as favorite!");
                                        addListTM.IsBoth = true;
                                    }
                                    else
                                    {
                                        if (addListTM.IsBoth == true)
                                            addListTM.IsBoth = false;
                                        else
                                            context.AddListTMs.Remove(addListTM);
                                        notifier.ShowSuccess("Movie removed from favorites!");
                                    }
                                    context.SaveChanges();
                                }
                                else
                                {
                                    addListTM = new AddListTM
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_TM = SelectedMovie!.Id,
                                        IsFavorite = true
                                    };

                                    context.AddListTMs.Add(addListTM);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie marked as favorite!");
                                }
                            }
                            break;
                        case "Top250TvShow":
                            if (selectedPerson != null)
                            {
                                var addListTT = selectedPerson.AddListTTs!.FirstOrDefault(add => add.Id_TT == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id);

                                if (addListTT != null)
                                {
                                    addListTT.IsFavorite = !addListTT.IsFavorite;
                                    if (addListTT.IsFavorite)
                                    {
                                        notifier.ShowSuccess("Movie marked as favorite!");
                                        addListTT.IsBoth = true;
                                    }
                                    else
                                    {
                                        if (addListTT.IsBoth == true)
                                            addListTT.IsBoth = false;
                                        else
                                            context.AddListTTs.Remove(addListTT);
                                        notifier.ShowSuccess("Movie removed from favorites!");
                                    }
                                    context.SaveChanges();
                                }
                                else
                                {
                                    addListTT = new AddListTT
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_TT = SelectedMovie!.Id + 146,
                                        IsFavorite = true
                                    };

                                    context.AddListTTs.Add(addListTT);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie marked as favorite!");
                                }
                            }
                            break;
                        case "Popularmovies":
                            if (selectedPerson != null)
                            {
                                var addListMPM = selectedPerson.AddListMPMs!.FirstOrDefault(add => add.Id_MPM == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id);

                                if (addListMPM != null)
                                {
                                    addListMPM.IsFavorite = !addListMPM.IsFavorite;
                                    if (addListMPM.IsFavorite)
                                    {
                                        notifier.ShowSuccess("Movie marked as favorite!");
                                        addListMPM.IsBoth = true;
                                    }
                                    else
                                    {
                                        if (addListMPM.IsBoth == true)
                                            addListMPM.IsBoth = false;
                                        else
                                            context.AddListMPMs.Remove(addListMPM);
                                        notifier.ShowSuccess("Movie removed from favorites!");
                                    }
                                    context.SaveChanges();
                                }
                                else
                                {
                                    addListMPM = new AddListMPM
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_MPM = SelectedMovie!.Id,
                                        IsFavorite = true
                                    };

                                    context.AddListMPMs.Add(addListMPM);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie marked as favorite!");
                                }
                            }
                            break;
                        case "PopularTvShow":
                            if (selectedPerson != null)
                            {
                                var addListMpT = selectedPerson.AddListMpTs!.FirstOrDefault(add => add.Id_MpT == SelectedMovie!.Id && add.Id_Person == CurrentPerson.Id);

                                if (addListMpT != null)
                                {
                                    addListMpT.IsFavorite = !addListMpT.IsFavorite;
                                    if (addListMpT.IsFavorite)
                                    {
                                        notifier.ShowSuccess("Movie marked as favorite!");
                                        addListMpT.IsBoth = true;
                                    }
                                    else
                                    {
                                        if (addListMpT.IsBoth == true)
                                            addListMpT.IsBoth = false;
                                        else
                                            context.AddListMpTs.Remove(addListMpT);
                                        notifier.ShowSuccess("Movie removed from favorites!");
                                    }
                                    context.SaveChanges();
                                }
                                else
                                {
                                    addListMpT = new AddListMpT
                                    {
                                        Id_Person = selectedPerson.Id,
                                        Id_MpT = SelectedMovie!.Id + 1,
                                        IsFavorite = true
                                    };

                                    context.AddListMpTs.Add(addListMpT);
                                    context.SaveChanges();
                                    notifier.ShowSuccess("Movie marked as favorite!");
                                }
                            }
                            break;
                        default:
                            return;
                    }
                },
                pre => SelectedMovie != null);

        SendCommand = new RelayCommand(
                action =>
                {
                    switch (GlobalStringCommand.Commaand)
                    {
                        case "Top250Movie":
                            if (!string.IsNullOrWhiteSpace(WatchMovieVieww!.tbComment.Text))
                            {
                                var newComment = new CommentTM
                                {
                                    Id_Top250Movie = SelectedMovie!.Id,
                                    UserName = CurrentPerson!.Username,
                                    Description = WatchMovieVieww!.tbComment.Text
                                };
                                try
                                {
                                    context.CommentTMs.Add(newComment);
                                    context.SaveChanges();
                                    WatchMovieVieww!.tbComment.Clear();
                                    notifier.ShowSuccess("Comment is sent successfully!!");
                                    timer.Interval = TimeSpan.FromSeconds(2);
                                    timer.Tick += (sender, e) =>
                                    {
                                        timer.Stop();
                                        var watchAgain = new WatchMovieView(CurrentPerson!, SelectedMovie.Id, 1, 2);
                                        WatchMovieVieww?.NavigationService?.Navigate(watchAgain);
                                    };
                                    timer.Start();
                                }
                                catch (Exception ex)
                                {
                                    notifier.ShowError("Error adding comment to database: " + ex.Message);
                                }
                            }
                            else
                                notifier.ShowWarning("Please enter a comment before sending.");
                            break;
                        case "Top250TvShow":
                            if (!string.IsNullOrWhiteSpace(WatchMovieVieww!.tbComment.Text))
                            {
                                var newComment2 = new CommentTT
                                {
                                    Id_Top250TvShow = SelectedMovie!.Id + 146,
                                    UserName = CurrentPerson!.Username,
                                    Description = WatchMovieVieww!.tbComment.Text
                                };
                                try
                                {
                                    context.CommentTTs.Add(newComment2);
                                    context.SaveChanges();
                                    WatchMovieVieww!.tbComment.Clear();
                                    notifier.ShowSuccess("Comment is sent successfully!!");
                                    timer.Interval = TimeSpan.FromSeconds(2);
                                    timer.Tick += (sender, e) =>
                                    {
                                        timer.Stop();
                                        var watchAgain = new WatchMovieView(CurrentPerson!, SelectedMovie.Id, 1, 2);
                                        WatchMovieVieww?.NavigationService?.Navigate(watchAgain);
                                    };
                                    timer.Start();
                                }
                                catch (Exception ex)
                                {
                                    notifier.ShowError("Error adding comment to database: " + ex.Message);
                                }
                            }
                            else
                                notifier.ShowWarning("Please enter a comment before sending.");
                            break;
                        case "Popularmovies":
                            if (!string.IsNullOrWhiteSpace(WatchMovieVieww!.tbComment.Text))
                            {
                                var newComment3 = new CommentMPM
                                {
                                    Id_MostPopularMovie = SelectedMovie!.Id,
                                    UserName = CurrentPerson!.Username,
                                    Description = WatchMovieVieww!.tbComment.Text
                                };
                                try
                                {
                                    context.CommentMPMs.Add(newComment3);
                                    context.SaveChanges();
                                    WatchMovieVieww!.tbComment.Clear();
                                    notifier.ShowSuccess("Comment is sent successfully!!");
                                    timer.Interval = TimeSpan.FromSeconds(2);
                                    timer.Tick += (sender, e) =>
                                    {
                                        timer.Stop();
                                        var watchAgain = new WatchMovieView(CurrentPerson!, SelectedMovie.Id, 1, 2);
                                        WatchMovieVieww?.NavigationService?.Navigate(watchAgain);
                                    };
                                    timer.Start();
                                }
                                catch (Exception ex)
                                {
                                    notifier.ShowError("Error adding comment to database: " + ex.Message);
                                }
                            }
                            else
                                notifier.ShowWarning("Please enter a comment before sending.");
                            break;
                        case "PopularTvShow":
                            if (!string.IsNullOrWhiteSpace(WatchMovieVieww!.tbComment.Text))
                            {
                                var newComment4 = new CommentMPT
                                {
                                    Id_MostPopularTvShow = SelectedMovie!.Id + 1,
                                    UserName = CurrentPerson!.Username,
                                    Description = WatchMovieVieww!.tbComment.Text
                                };
                                try
                                {
                                    context.CommentMPTs.Add(newComment4);
                                    context.SaveChanges();
                                    WatchMovieVieww!.tbComment.Clear();
                                    notifier.ShowSuccess("Comment is sent successfully!!");
                                    timer.Interval = TimeSpan.FromSeconds(2);
                                    timer.Tick += (sender, e) =>
                                    {
                                        timer.Stop();
                                        var watchAgain = new WatchMovieView(CurrentPerson!, SelectedMovie.Id, 1, 2);
                                        WatchMovieVieww?.NavigationService?.Navigate(watchAgain);
                                    };
                                    timer.Start();
                                }
                                catch (Exception ex)
                                {
                                    notifier.ShowError("Error adding comment to database: " + ex.Message);
                                }
                            }
                            else
                                notifier.ShowWarning("Please enter a comment before sending.");
                            break;
                        default:
                            return;
                    }
                },
                pre => SelectedMovie != null && CurrentPerson != null);
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

        Moviess = new ObservableCollection<MovieTvShowDTO>(dtoList);
    }

    private void UpdateCommentsMPT()
    {
        CommentMPTRepository comMPT = new();
        ICollection<CommentMPT> selection = comMPT.GetAllWithMostPopularTvShows()!;
        IEnumerable<CommentDTO> dtoList = selection
            .Where(ec => ec.Id_MostPopularTvShow == SelectedMovie?.Id + 1)
            .Select(ec => new CommentDTO
            {
                Username = ec.UserName,
                CreatedDate = ec.CreatedDate,
                Description = ec.Description
            });

        Comments = new ObservableCollection<CommentDTO>(dtoList);
    }

    private void UpdateCommentsTM()
    {
        CommentTMRepository comTM = new();
        ICollection<CommentTM> selection = comTM.GetAllWithTop250Movies()!;
        IEnumerable<CommentDTO> dtoList = selection
            .Where(ec => ec.Id_Top250Movie == SelectedMovie?.Id)
            .Select(ec => new CommentDTO
            {
                Username = ec.UserName,
                CreatedDate = ec.CreatedDate,
                Description = ec.Description
            });

        Comments = new ObservableCollection<CommentDTO>(dtoList);
    }

    private void UpdateCommentsTT()
    {
        CommentTTRepository comTT = new();
        ICollection<CommentTT> selection = comTT.GetAllWithTop250TvShows()!;
        IEnumerable<CommentDTO> dtoList = selection
            .Where(ec => ec.Id_Top250TvShow == SelectedMovie?.Id + 146)
            .Select(ec => new CommentDTO
            {
                Username = ec.UserName,
                CreatedDate = ec.CreatedDate,
                Description = ec.Description
            });

        Comments = new ObservableCollection<CommentDTO>(dtoList);
    }

    private void UpdateCommentsMPM()
    {
        CommentMPMRepository comMPM = new();
        ICollection<CommentMPM> selection = comMPM.GetAllWithMostPopularMovies()!;
        IEnumerable<CommentDTO> dtoList = selection
            .Where(ec => ec.Id_MostPopularMovie == SelectedMovie?.Id)
            .Select(ec => new CommentDTO
            {
                Username = ec.UserName,
                CreatedDate = ec.CreatedDate,
                Description = ec.Description
            });

        Comments = new ObservableCollection<CommentDTO>(dtoList);
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
