using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ICommentRepository : IGenericRepository<Comment>
{
    ICollection<Comment>? GetAllWithEditorChoices();
    ICollection<Comment>? GetAllWithMostPopularMovies();
    ICollection<Comment>? GetAllWithMostPopularTvShows();
    ICollection<Comment>? GetAllWithTop250Movies();
    ICollection<Comment>? GetAllWithTop250TvShows();
}
