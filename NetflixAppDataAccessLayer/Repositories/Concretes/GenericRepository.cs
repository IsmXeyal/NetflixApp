using NetflixAppDataAccessLayer.Contexts;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    internal readonly NetflixDbContext? _context;

    public GenericRepository()
    {
        _context = new NetflixDbContext();
    }

    public void Add(T entity)
    {
        if (entity is null) throw new Exception("Entity is NUll");
        _context?.Set<T>().Add(entity);
    }

    public ICollection<T>? GetAll() => _context?.Set<T>().ToList();

    public T? GetById(int id)
    {
        if (id <= 0) throw new Exception("Id is not valid");
        var entity = _context?.Set<T>().FirstOrDefault(x => x.Id == id);
        return entity;
    }

    public void Remove(T entity)
    {
        if (entity is null) throw new Exception("Entity is NUll");
        _context?.Set<T>().Remove(entity);
    }

    public void Remove(int id)
    {
        if (id <= 0) throw new Exception("Id is not valid");
        var entity = _context?.Set<T>().FirstOrDefault(x => x.Id == id);
        if (entity is null) throw new Exception("Entity is NUll");
        _context?.Set<T>().Remove(entity);
    }

    public void SaveChanges() => _context?.SaveChanges();

    public void Update(T entity)
    {
        if (entity is null) throw new Exception("Entity is NUll");
        _context?.Set<T>().Update(entity);
    }
}
