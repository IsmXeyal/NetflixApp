using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void Remove(int id);
    T? GetById(int id);
    ICollection<T>? GetAll();
    void SaveChanges();
}
