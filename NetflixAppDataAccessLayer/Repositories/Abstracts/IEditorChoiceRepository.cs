using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IEditorChoiceRepository : IGenericRepository<EditorChoice>
{
    ICollection<EditorChoice>? GetAllWithGenres();
    ICollection<EditorChoice>? GetAllWithAddListECs();
    ICollection<EditorChoice>? GetAllWithLanguages();
    ICollection<EditorChoice>? GetAllWithComments();
}
