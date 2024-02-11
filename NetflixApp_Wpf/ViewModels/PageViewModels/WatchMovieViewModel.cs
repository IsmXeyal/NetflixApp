using NetflixApp_Wpf.Command;
using NetflixApp_Wpf.DTOs;
using NetflixApp_Wpf.Services;
using NetflixApp_Wpf.Views.Pages;
using NetflixAppDataAccessLayer.Contexts;
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
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace NetflixApp_Wpf.ViewModels.PageViewModels;

public class WatchMovieViewModel : NotificationService
{
    public WatchMovieView? WatchMovieVieww { get; set; }
    public Person? CurrentPerson { get; set; }
    public int Index { get; set; }

    private ObservableCollection<EditorChoiceDTO>? _movies;

    public ObservableCollection<EditorChoiceDTO>? Moviess
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

    private EditorChoiceDTO? _selectedMovie;

    public EditorChoiceDTO? SelectedMovie
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

    NetflixDbContext context = new();
    public WatchMovieViewModel(WatchMovieView watchMovie, Person person, int index, int langId, int type)
    {
        WatchMovieVieww = watchMovie;
        CurrentPerson = person;
        Index = index;

        UpdateMovies(langId);

        if (Index > 0 && Index <= Moviess!.Count)
        {
            SelectedMovie = Moviess[Index - 1];
            Video_Link = SelectedMovie.Video_link;
            Imdb_Link = SelectedMovie.Imdb_link;
        }

        var selectedPerson = context.People.FirstOrDefault(person => person.Email == CurrentPerson!.Email);
        if (selectedPerson != null)
        {
            if (selectedPerson.AddListECs!.FirstOrDefault(add => add.Id_ECMovie == SelectedMovie!.Rank && add.Id_Person == CurrentPerson.Id && add.IsFavorite == true) != null)
                IsFavorite = true;
            else
                IsFavorite = false;
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
                    var movieView = new MovieView_(person, Index);
                    WatchMovieVieww?.NavigationService?.Navigate(movieView);
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
                        if (selectedPerson.AddListECs!.Any(u => (u.Id_ECMovie == SelectedMovie!.Rank && u.IsBoth == false && u.IsFavorite == false)
                            || (u.Id_ECMovie == SelectedMovie!.Rank && u.IsBoth == true)))
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

        HeartCommand = new RelayCommand(
                action =>
                {
                    if (selectedPerson != null)
                    {
                        var addListEC = selectedPerson.AddListECs!.FirstOrDefault(add => add.Id_ECMovie == SelectedMovie!.Rank && add.Id_Person == CurrentPerson.Id);

                        if (addListEC != null)
                        {
                            addListEC.IsFavorite = !addListEC.IsFavorite;
                            if (addListEC.IsFavorite)
                            {
                                notifier.ShowSuccess("Movie marked as favorite!");
                                addListEC.IsBoth = true;
                            }
                            else
                            {
                                if(addListEC.IsBoth == true)
                                    addListEC.IsBoth = false;
                                else
                                    context.AddListECs.Remove(addListEC);
                                notifier.ShowSuccess("Movie removed from favorites!");
                            }
                            context.SaveChanges();
                        }
                        else
                        {
                            addListEC = new AddListEC
                            {
                                Id_Person = selectedPerson.Id,
                                Id_ECMovie = SelectedMovie!.Rank,
                                IsFavorite = true
                            };

                            context.AddListECs.Add(addListEC);
                            context.SaveChanges();
                            notifier.ShowSuccess("Movie marked as favorite!");
                        }
                    }
                },
                pre => SelectedMovie != null);
    }

    private void UpdateMovies(int num)
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

        Moviess = new ObservableCollection<EditorChoiceDTO>(dtoList);
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
