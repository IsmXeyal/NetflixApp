using NetflixAppBusinessLogicLayer.Services;

namespace NetflixApp_Wpf.DTOs;

public class CommentDTO : NotificationService
{
    private string? _username;
    private DateTime _createDate;
    private string? _description;

    public string? Username { get => _username; set { _username = value; OnPropertyChanged(); } }
    public DateTime CreatedDate { get => _createDate; set { _createDate = value!; OnPropertyChanged(); } }
    public string? Description { get => _description; set { _description = value; OnPropertyChanged(); } }
}
