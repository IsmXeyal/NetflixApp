using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class CommentEcRepository : GenericRepository<CommentEc>, ICommentEcRepository
{
    public ICollection<CommentEc>? GetAllWithEditorChoices()
    {
        return _context?.CommentEcs.Include(x => x.EditorChoice).ToList();
    }
}
