using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class EditorChoiceRepository : GenericRepository<EditorChoice>, IEditorChoiceRepository
{
    public ICollection<EditorChoice>? GetAllWithAddListECs()
    {
        return _context?.EditorChoices.Include(x => x.AddListECs).ToList();
    }

    public ICollection<EditorChoice>? GetAllWithComments()
    {
        return _context?.EditorChoices.Include(x => x.Comments).ToList();
    }

    public ICollection<EditorChoice>? GetAllWithGenres()
    {
        return _context?.EditorChoices.Include(x => x.Genres).ToList();
    }

    public ICollection<EditorChoice>? GetAllWithLanguages()
    {
        return _context?.EditorChoices.Include(x => x.Languages).ToList();
    }
}
