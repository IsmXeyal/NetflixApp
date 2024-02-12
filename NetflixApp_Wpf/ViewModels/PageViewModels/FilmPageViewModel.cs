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

public class FilmPageViewModel : NotificationService
{
    public FilmListPageView? FilmList { get; set; }
    public Person? CurrentPerson { get; set; }

    public ICommand? BackCommand { get; set; }
    public ICommand? ExitAppCommand { get; set; }

    private ObservableCollection<EditorChoiceDTO>? add_view;

    public ObservableCollection<EditorChoiceDTO>? Add_view
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
    public FilmPageViewModel(FilmListPageView filmlist, Person? currentPerson, string? commandd)
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
                    var movieView = new MovieView_(currentPerson!, 0);
                    FilmList?.NavigationService?.Navigate(movieView);
                },
                pre => true);

        if (Commandd == "GoList")
        {
            EditorChoiceRepository editorChoice = new();
            ICollection<EditorChoice> selection = editorChoice!.GetAllWithAddListECs()!;
            IEnumerable<EditorChoiceDTO> dtoList = selection
                .Where(ec => ec.AddListECs!.Any(l => (l.Id_ECMovie == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == false && l.IsBoth == false)
                        || (l.Id_ECMovie == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsBoth == true)))
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

            Add_view = new ObservableCollection<EditorChoiceDTO>(dtoList);
        }
        else if (Commandd == "Heart")
        {
            EditorChoiceRepository editorChoice = new();
            ICollection<EditorChoice> selection = editorChoice!.GetAllWithAddListECs()!;
            IEnumerable<EditorChoiceDTO> dtoList = selection
                .Where(ec => ec.AddListECs!.Any(l => l.Id_ECMovie == ec.Id && l.Id_Person == CurrentPerson!.Id && l.IsFavorite == true))
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

            Add_view = new ObservableCollection<EditorChoiceDTO>(dtoList);
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
