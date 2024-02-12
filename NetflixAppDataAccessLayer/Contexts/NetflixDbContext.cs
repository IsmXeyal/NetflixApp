using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Contexts;

#nullable disable
public class NetflixDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var ConStr = new ConfigurationManager()
            .AddJsonFile("AppSettingsCon.json")
            .Build()
            .GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(ConStr);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<EditorChoice> EditorChoices { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<MostPopularMovie> MostPopularMovies { get; set; }
    public virtual DbSet<MostPopularTvShow> MostPopularTvShows { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Top250Movie> Top250Movies { get; set; }
    public virtual DbSet<Top250TvShow> Top250TvShows { get; set; }
    public virtual DbSet<AddListEC> AddListECs { get; set; }
    public virtual DbSet<AddListMPM> AddListMPMs { get; set; }
    public virtual DbSet<AddListMpT> AddListMpTs { get; set; }
    public virtual DbSet<AddListTM> AddListTMs { get; set; }
    public virtual DbSet<AddListTT> AddListTTs { get; set; }
    public virtual DbSet<CommentEc> CommentEcs { get; set; }
    public virtual DbSet<CommentMPM> CommentMPMs { get; set; }
    public virtual DbSet<CommentMPT> CommentMPTs { get; set; }
    public virtual DbSet<CommentTM> CommentTMs { get; set; }
    public virtual DbSet<CommentTT> CommentTTs { get; set; }
}
